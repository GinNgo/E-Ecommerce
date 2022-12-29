using E_Ecommerce_CustomerSite.Models;
using E_Ecommerce_CustomerSite.Services.CategoryService;
using E_Ecommerce_CustomerSite.Services.ProductService;
using E_Ecommerce_Shared.DTO;
using E_Ecommerce_Shared.DTO.Categories;
using E_Ecommerce_Shared.DTO.Product;
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
       public  ScoreRatingViewModel ScoreRating = new ScoreRatingViewModel();
        public async Task<IActionResult> OnPostRating(int Id)
        {
            var token = HttpContext.Session.GetString("JWToken");
            if(token == null)
            {
             
                return RedirectToPage("./Login");
            }
            else
            {
                int score = int.Parse(Request.Form["star"]);

                var comment = Request.Form["comment"];
                RatingDto ratingDto = new RatingDto()
                {
                    Score = score,
                    Comment = comment,
                    CreateDate = DateTime.UtcNow,
                    ProductId = Id
                };

                Pro = await _productService.PostProductsRatingAsync(ratingDto);
                if (Pro.Rating!.Count > 0)
                {
                    foreach (var rating in Pro.Rating!)
                    {
                        ScoreRating.total += rating.Score;
                        switch (rating.Score)
                        {
                            case 1: ScoreRating.one++; ScoreRating.countTotal++; break;
                            case 2: ScoreRating.two++; ScoreRating.countTotal++; break;
                            case 3: ScoreRating.three++; ScoreRating.countTotal++; break;
                            case 4: ScoreRating.four++; ScoreRating.countTotal++; break;
                            case 5: ScoreRating.five++; ScoreRating.countTotal++; break;
                        }
                    }
                }
                else
                {
                    ScoreRating.countTotal = 1;
                    ScoreRating.total = 0;
                    ScoreRating.one = 0;
                    ScoreRating.one = 0;
                    ScoreRating.one = 0;
                    ScoreRating.one = 0;
                    ScoreRating.one = 0;
                }

                categoriesDtos = await _categoriesService.GetBreadbrum(Pro.Categories!.FirstOrDefault()!.CategoryId);
                if (Pro != null)
                {
                    return Redirect("/Detail/" + Pro.ProductId);
                }
                return Page();
            }
           
        }
        public async Task<IActionResult> OnGet(int Id)
        {
                  
        Pro = await _productService.GetProductsByIdAsync(Id);
            if (Pro.Rating!.Count > 0)
            {
                foreach (var rating in Pro.Rating!)
                {
                    ScoreRating.total += rating.Score;
                    switch (rating.Score)
                    {
                        case 1: ScoreRating.one++; ScoreRating.countTotal++; break;
                        case 2: ScoreRating.two++; ScoreRating.countTotal++; break;
                        case 3: ScoreRating.three++; ScoreRating.countTotal++; break;
                        case 4: ScoreRating.four++; ScoreRating.countTotal++; break;
                        case 5: ScoreRating.five++; ScoreRating.countTotal++; break;
                    }

                }
            }
            else
            {
                ScoreRating.countTotal = 1;
                ScoreRating.total = 0;
                ScoreRating.one = 0;
                ScoreRating.one = 0;
                ScoreRating.one = 0;
                ScoreRating.one = 0;
                ScoreRating.one = 0;
            }
         
            
           
            categoriesDtos = await _categoriesService.GetBreadbrum(Pro.Categories!.FirstOrDefault()!.CategoryId);
            return Page();
        }

    }
}
