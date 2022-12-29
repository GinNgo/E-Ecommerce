using AspNetCoreHero.ToastNotification.Abstractions;
using E_Ecommerce_CustomerSite.Services.UserService;
using E_Ecommerce_Shared.DTO.Register;
using E_Ecommerce_Shared.DTO.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace E_Ecommerce_CustomerSite.Pages
{
    public class LoginModel : PageModel
    {

        private readonly INotyfService _notyf;
        private readonly IUserService _userService;
        public LoginModel(INotyfService notyf, IUserService userService)
        {
            _notyf = notyf;
            _userService = userService;
        }
      
        public void OnGet()
        {
         
        }
     
        public async Task<IActionResult> OnPostLogin()
        {
           
            var username = Request.Form["username"];
            var password = Request.Form["password"];
            UserDto user = new UserDto()
            {
                Username = username,
                Password = password

            };
            var token = await _userService.LoginAsync(user);
            if(token== "Invalid Credentials")
            {
                _notyf.Error("–„ng nh‚Úp th‚Ït baÚi");
            }
            else
            {
                HttpContext.Session.SetString("JWToken", token);
                _notyf.Success("–„ng nh‚Úp thaÃnh cÙng");
                return RedirectToPage("/") ;
            }
        


            return Page();
        }
    }
}
