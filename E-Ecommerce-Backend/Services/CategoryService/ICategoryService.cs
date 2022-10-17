using E_Ecommerce_Shared.DTO.CategoryDto;
using E_Ecommerce_Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_Ecommerce_Backend.Services.CategoryService
{
    public interface ICategoryService
    {
        public Task<List<CategoryDto>> GetCategories();
    }
}
