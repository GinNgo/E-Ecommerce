using E_Ecommerce_Backend.Models;
using Microsoft.AspNetCore.Mvc;
using E_Ecommerce_Shared.DTO;

namespace E_Ecommerce_Backend.Services.CategoryService
{
    public interface ICategoriesService
    {
        public Task<List<CategoriesDto>> GetCategories();
    }
}
