using E_Ecommerce_CustomerSite.Services.ProductService;
using E_Ecommerce_Shared.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace E_Ecommerce_CustomerSite.Pages
{
    public class DetailModel : PageModel
    {
        private readonly IProductService _productService;

        public ProductsDto Pro { get; set; }
        public DetailModel(IProductService productService)
        {
            _productService = productService;
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

            return Page();
        }

    }
}
