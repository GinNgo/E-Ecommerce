using E_Ecommerce_CustomerSite.Models;
using E_Ecommerce_Shared.DTO.Product;
using Microsoft.AspNetCore.Mvc;

namespace E_Ecommerce_CustomerSite.Pages.Shared.Components.RatingCart
{
    public class RatingCartViewComponent:ViewComponent
    {

 
        public IViewComponentResult Invoke(ProductsDto product)
        {
            return View(product);
        }
    }
}
