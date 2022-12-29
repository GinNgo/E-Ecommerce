using E_Ecommerce_CustomerSite.Services.UserService;
using Microsoft.AspNetCore.Mvc;

namespace E_Ecommerce_CustomerSite.Pages.Shared.Components.Header
{
    [ViewComponent]
    public class HeaderViewComponent : ViewComponent
    {
        private readonly IUserService _userService;
     
        public HeaderViewComponent(IUserService userService) {
            _userService = userService;
           
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewBag.Token = HttpContext.Session.GetString("JWToken");
            if(ViewBag.Token!=null) 
              ViewBag.Username =await _userService.GetUserNameAsync();
          
            return View();
        }
    }
}
