using AspNetCoreHero.ToastNotification.Abstractions;
using E_Ecommerce_CustomerSite.Services.UserService;
using E_Ecommerce_Shared.DTO.Register;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace E_Ecommerce_CustomerSite.Pages
{
    public class SignUpModel : PageModel
    {
        private readonly INotyfService _notyf;
        private readonly IUserService _userService;
        public SignUpModel(INotyfService notyf, IUserService userService)
        {
            _notyf = notyf;
            _userService= userService;
        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostSignUp()
        {
            var fullName = Request.Form["fullName"];
            var phone = Request.Form["phone"];
            var email = Request.Form["email"];
            var username = Request.Form["username"];
            var password = Request.Form["password"];
            UserSignUp userSignUp = new UserSignUp()
            {
                Email = email,
                Phone = phone,
                FullName= fullName,
                UserName= username,
                Password= password

            };
            bool success= await _userService.SignUpAsync(userSignUp);
            if (success)
            {
                _notyf.Success("Thêm thaÌnh công");
            }
            else
            {
                _notyf.Error("TaÌi khoaÒn ðaÞ tôÌn taòi");
            }
            

            return Page();
        }
    }
}
