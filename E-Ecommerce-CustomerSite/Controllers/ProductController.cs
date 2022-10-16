using E_Ecommerce_CustomerSite.Services.ProductService;
using Microsoft.AspNetCore.Mvc;

namespace E_Ecommerce_CustomerSite.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Product()
        {
            var products = await _productService.GetAllProductsAsync();

            return View(products);
        }
       
    }
}
