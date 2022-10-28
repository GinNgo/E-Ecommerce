using E_Ecommerce_CustomerSite.Services.CategoryService;
using E_Ecommerce_CustomerSite.Services.ProductService;
using E_Ecommerce_Shared.Constants;
using E_Ecommerce_Shared.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using testRazor.Pages;

namespace E_Ecommerce_CustomerSite.Pages
{
    public class CategoryModel : PageModel
    {
        private readonly IProductService _productService;
        private readonly ICategoriesService _categoriesService;
        public int pageIndex { get; set; } = 1;
        public int pageSize { get; set; } = ConfigurationConstants.LIMIT;
        public int totalProducts { get; set; }
        public List<ProductsDto> productsDtos { get; set; }
        public CategoryModel(IProductService productService, ICategoriesService categoriesService)
        {
            _productService = productService;
            _categoriesService = categoriesService; 
        }
        public async Task<IActionResult> OnGet(int id,int p=1,int s = ConfigurationConstants.LIMIT)
        {
            pageIndex=p;
            pageSize=s;
            productsDtos = await _productService.GetProductsByCatIdAsync(id, pageIndex, pageSize);
            totalProducts = await _productService.GetTotalProByCatAsync(id);
            ViewData["BreadBrum"] = await _categoriesService.GetBreadbrum(id);
            return Page();
        }
    }
}
