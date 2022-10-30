using Microsoft.AspNetCore.Mvc;

namespace E_Ecommerce_CustomerSite.Pages.Shared.Components.Header
{
    [ViewComponent]
    public class HeaderViewComponent : ViewComponent
    {
   
        public IViewComponentResult Invoke()
        {

            return View();
        }
    }
}
