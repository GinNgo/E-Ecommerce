using E_Ecommerce_Shared.DTO.ProductDto;
using Microsoft.AspNetCore.Mvc;

namespace E_Ecommerce_CustomerSite.Services.CategoryService
{
    public interface ICategoryService
    {
        public Task<IActionResult<IEnumerable<CategoryDto>>>
    }
}
