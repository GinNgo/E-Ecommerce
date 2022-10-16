using E_Ecommerce_Shared.DTO.ProductDto;
using E_Ecommerce_Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_Ecommerce_Backend.Services.CategoryService
{
    public interface ICategoryService
    {
        public Task<ActionResult<IEnumerable<Category>>> GetCategories();
    }
}
