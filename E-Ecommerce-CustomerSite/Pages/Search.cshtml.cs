using E_Ecommerce_CustomerSite.Models;
using E_Ecommerce_CustomerSite.Services.ProductService;
using E_Ecommerce_Shared.Constants;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace E_Ecommerce_CustomerSite.Pages
{
    public class SearchModel : PageModel
    {
        public string? Keyword { get; set; }
        private readonly IProductService _productService;
  
        public ProductViewModel ProductViewModel { get; set; }
        public SearchModel(IProductService productService)
        {
            _productService = productService;
     
        }
        public async Task<IActionResult> OnGet([FromQuery(Name ="q")]string query, int p = 1, int s = ConfigurationConstants.LIMIT)
        {
            var ProductPaing = await _productService.GetProductsBySearchAsync(query, p, s);
            ProductViewModel.pageIndex = p;
            ProductViewModel.pageSize = s;
            ProductViewModel.productsDtos = ProductPaing.products;
            ProductViewModel.totalCount = ProductPaing.totalCount;

            return Page();
        }
    }
}
