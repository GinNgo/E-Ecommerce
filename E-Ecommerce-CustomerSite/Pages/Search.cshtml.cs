using E_Ecommerce_CustomerSite.Models;
using E_Ecommerce_CustomerSite.Services.ProductService;
using E_Ecommerce_Shared.Constants;
using E_Ecommerce_Shared.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace E_Ecommerce_CustomerSite.Pages
{
    public class SearchModel : PageModel
    {
        public string? Keyword { get; set; }
        private readonly IProductService _productService;

        public ProductViewModel productViewModel = new ProductViewModel();
        public PagingRequestDto pagingRequestDto = new PagingRequestDto();
        public SearchModel(IProductService productService)
        {
            _productService = productService;
     
        }
        public async Task<IActionResult> OnGet([FromQuery(Name ="q")]string query, int p = 1, int s = ConfigurationConstants.LIMIT)
        {
             
                pagingRequestDto.Search = query;
                 pagingRequestDto.pageIndex = p;
                pagingRequestDto.pageSize = s;
         
            var ProductPaing = await _productService.GetProductsBySearchAsync(pagingRequestDto);
            productViewModel.pageIndex = p;
            productViewModel.pageSize = s;
            productViewModel.productsDtos = ProductPaing.products;
            productViewModel.totalCount = ProductPaing.totalCount;

            return Page();
        }
    }
}
