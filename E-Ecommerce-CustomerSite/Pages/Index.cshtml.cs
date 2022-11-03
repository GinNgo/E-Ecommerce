using E_Ecommerce_CustomerSite.Services.CategoryService;
using E_Ecommerce_CustomerSite.Services.ProductService;
using E_Ecommerce_Shared.DTO;
using E_Ecommerce_Shared.DTO.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace E_Ecommerce_CustomerSite.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IProductService _productService;
      

        public IndexModel(IProductService productService)
        {
            _productService = productService;
           
        }
        public ProductPagingDto productsNew = new ProductPagingDto();
        public ProductPagingDto productsSuggest = new ProductPagingDto();
        public async Task<IActionResult> OnGet()
        {
            PagingRequestDto pagingProductNew = new PagingRequestDto()
            {
                pageIndex = 1,
                pageSize = 8,
                sort = 1
            };
            PagingRequestDto pagingProductSuggest = new PagingRequestDto()
            {
                pageIndex = 1,
                pageSize = 12,
                sort = 1
            };
            productsNew = await  _productService.GetProductPagingAsync(pagingProductNew);
            productsSuggest = await _productService.GetProductPagingAsync(pagingProductSuggest);
            return Page();
        }
       
       

    }
}