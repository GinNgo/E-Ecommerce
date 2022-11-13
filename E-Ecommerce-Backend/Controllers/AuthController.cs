using E_Ecommerce_Backend.Data;
using E_Ecommerce_Backend.Models;
using E_Ecommerce_Backend.Services.UserService;
using E_Ecommerce_Shared.DTO.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace E_Ecommerce_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IUserService _service;
       public AuthController( IConfiguration configuration,IUserService userService)
        {
            _configuration= configuration;
            _service = userService;
        }
        [HttpPost]
        public async Task<IActionResult> Post(UserDto userDto)
        {
            if(userDto != null && userDto.Username!=null&&userDto.Password!=null)
            {
                var user = await _service.GetUser(userDto.Username, userDto.Password);
                var jwt = _configuration.GetSection("Jwt").Get<Jwt>();
                if(user != null)
                {
                    var claims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub,jwt.Subject!),
                        new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat,DateTime.UtcNow.ToString()),
                        new Claim("UserId",user.UserId.ToString()),
                        new Claim("FullName",user.FullName!),
                       
                    };
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.key!));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                                    jwt.Issuer,
                                    jwt.Audience,
                                    claims,
                                    expires: DateTime.Now.AddMinutes(20),
                                    signingCredentials:signIn
                        );
                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }
                else
                {
                    return BadRequest("Invalid Credentials");
                }
            }
            else
            {
                return BadRequest("Invalid Credentials");
            }
        }
    }
}
