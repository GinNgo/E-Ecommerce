
using Microsoft.AspNetCore.Mvc;

namespace E_Ecommerce_CustomerSite.Components
{
    public class FooterViewComponent : ViewComponent
    {
 
        public FooterViewComponent( )
        {
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
     
            return View("Footer");
        }
    }
}
