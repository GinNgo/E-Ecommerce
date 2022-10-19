using Microsoft.AspNetCore.Mvc;

namespace E_Ecommerce_CustomerSite.Components
{
    public class HeaderViewComponent:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            
            return View("Header");  
        }
    }
}
