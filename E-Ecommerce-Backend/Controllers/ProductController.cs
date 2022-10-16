using E_Ecommerce_Backend.Service.ProductService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Ecommerce_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet("GetAllProduct")]
        public async Task<IActionResult> GetAllProductsAsync()
        {
            var data =await _productService.GetAllProductsAsync();
            return Ok(data);
        }
    }
}
