using E_Ecommerce_Backend.Services.UserService;
using E_Ecommerce_Shared.DTO.Register;
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
        public async Task<IActionResult> Post(UserSignUp user)
        {
            await _userService.CreateUser(user);
            return NoContent();
        }
    }
}
