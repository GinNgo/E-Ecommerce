using E_Ecommerce_CustomerSite.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_Ecommerce_CustomerSite.Pages.Shared.Components.Product
{
    public class ProductViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke(ProductViewModel productViewModel)
        {

            return View(productViewModel);
        }
    }
}
