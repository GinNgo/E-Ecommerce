using E_Ecommerce_CustomerSite.Services.CategoryService;
using E_Ecommerce_CustomerSite.Services.ProductService;
using E_Ecommerce_Shared.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace E_Ecommerce_CustomerSite.Pages
{
    public class DetailModel : PageModel
    {
        private readonly IProductService _productService;
        private readonly ICategoriesService _categoriesService;
        public ProductsDto? Pro { get; set; }
        public DetailModel(IProductService productService, ICategoriesService categoriesService)
        {
            _productService = productService;
            _categoriesService = categoriesService;
        }

        public void OnPost()
        {
            var emailAddress = Request.Form["star"];
            Console.WriteLine("emailAddress");
        }
        public async Task<IActionResult> OnGet(int Id)
        {
           Pro = new ProductsDto();
           Pro = await _productService.GetProductsByIdAsync(Id);
            
            ViewData["BreadBrum"] = await _categoriesService.GetBreadbrum(Pro.CategoryId);
            return Page();
        }

    }
}
