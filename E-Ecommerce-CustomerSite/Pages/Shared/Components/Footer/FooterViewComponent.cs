using Microsoft.AspNetCore.Mvc;

namespace E_Ecommerce_CustomerSite.Pages.Shared.Components.Footer
{
    public class FooterViewComponent : ViewComponent
    {

        public FooterViewComponent()
        {
        }

        public IViewComponentResult Invoke()
        {

            return View();
        }
    }
}
