using E_Ecommerce_Backend.Models;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Printing;
using E_Ecommerce_Shared.DTO.Categories;

namespace E_Ecommerce_Backend.Services.CategoryService
{
    public interface ICategoriesService
    {
        public Task<List<CategoriesDto>> GetCategoriesAsync();
        public Task<List<int>> GetCategoriesIdChild(int id);
        public  Task<List<CategoriesDto>> GetBreadCrumb(int id);
        public Task<List<CategoryAdmin>> GetCategoriesAdminAsync();
        public Task<List<CategoryParent>> GetCategoriesParentAsync();
        public  Task<Boolean> PostCategory(Category category);
    }
}
