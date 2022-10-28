using E_Ecommerce_CustomerSite.Services.CategoryService;
using E_Ecommerce_CustomerSite.Services.ProductService;
using E_Ecommerce_Shared.DTO;
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
       
        public async Task<IActionResult> OnGet()
        {

            ViewData["ListPro"] = await  _productService.GetAllProductsAsync();
            
            return Page();
        }
       
       

    }
}