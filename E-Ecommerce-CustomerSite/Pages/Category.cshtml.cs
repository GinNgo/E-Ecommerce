using E_Ecommerce_CustomerSite.Models;
using E_Ecommerce_CustomerSite.Services.CategoryService;
using E_Ecommerce_CustomerSite.Services.ProductService;
using E_Ecommerce_Shared.Constants;
using E_Ecommerce_Shared.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace E_Ecommerce_CustomerSite.Pages
{
    public class CategoryModel : PageModel
    {
        private readonly IProductService _productService;
        private readonly ICategoriesService _categoriesService;
        public ProductViewModel ProductViewModel { get; set; }
        public CategoryModel(IProductService productService, ICategoriesService categoriesService)
        {
            _productService = productService;
            _categoriesService = categoriesService; 
        }
        public async Task<IActionResult> OnGet(int id,int p=1,int s = ConfigurationConstants.LIMIT)
        {
           var ProductPaging= await _productService.GetProductsByCatIdAsync(id, p, s);
            ProductViewModel.pageIndex =p;
            ProductViewModel.pageSize =s;
            ProductViewModel.productsDtos = ProductPaging.products;
            ProductViewModel.totalCount = ProductPaging.totalCount;
            ViewData["BreadBrum"] = await _categoriesService.GetBreadbrum(id);
            return Page();
        }
    }
}
