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
        public ProductsDto? Pro = new ProductsDto();
        public DetailModel(IProductService productService, ICategoriesService categoriesService)
        {
            _productService = productService;
            _categoriesService = categoriesService;
        }
        public List<CategoriesDto>? categoriesDtos = new List<CategoriesDto>();
        public async Task<IActionResult> OnPostRating(int Id)
        {
            int score = int.Parse(Request.Form["star"]);
            var name = Request.Form["name"];
            var email = Request.Form["email"];
            var comment = Request.Form["comment"];
            RatingDto ratingDto = new RatingDto()
            {
                Score = score,
                Name = name,
                Email = email,
                Comment = comment
            };
           
            Pro = await _productService.GetProductsByIdAsync(Id);

            categoriesDtos = await _categoriesService.GetBreadbrum(Pro.CategoryId);
            return Page();
        }
        public async Task<IActionResult> OnGet(int Id)
        {

            Pro = await _productService.GetProductsByIdAsync(Id);

            categoriesDtos = await _categoriesService.GetBreadbrum(Pro.CategoryId);
            return Page();
        }

    }
}
