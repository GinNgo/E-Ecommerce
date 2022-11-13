using E_Ecommerce_Backend.Services.UserService;
using E_Ecommerce_Shared.DTO.Register;
using E_Ecommerce_Shared.DTO.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

using Microsoft.AspNetCore.Mvc;

namespace E_Ecommerce_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost]
        public async Task<Boolean> Post(UserSignUp user)
        {
             var respon= await _userService.CreateUser(user);
            return respon;
        }
        [HttpGet]

        public async Task<List<UserInfo>> GetCustomerAsync()
        {
            var customers=await _userService.GetUserInfoAsync();
            return customers;
        }
        [HttpGet("Username")]
        [Authorize]
        public  string GetUsernameAsync()
        {
            var Username = User.Claims.FirstOrDefault(u=>u.Type== "FullName")?.Value;

            return  Username;
            
        }
    }
}
