using E_Ecommerce_CustomerSite.Services.ProductService;
using Microsoft.AspNetCore.Mvc;

namespace E_Ecommerce_CustomerSite.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        public async Task<IActionResult> Product()
        {
            var products = await productService.GetAllProductsAsync();

            return View(products);
        }
       
    }
}
