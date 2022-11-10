using E_Ecommerce_Backend.Models;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Printing;
using E_Ecommerce_Shared.DTO.Categories;
using E_Ecommerce_Shared.DTO.Admin;

namespace E_Ecommerce_Backend.Services.CategoryService
{
    public interface ICategoriesService
    {
        public Task<List<CategoriesDto>> GetCategoriesAsync();
        public  Task<CategoryAdmin> GetOneCategoryAsync(int id);
        public Task<List<int>> GetCategoriesIdChild(int id);
        public  Task<List<CategoriesDto>> GetBreadCrumb(int id);
        public Task<List<CategoryAdmin>> GetCategoriesAdminAsync();
        public Task<List<CategoryParent>> GetCategoriesParentAsync();
        public Task<List<CategoryAdmin>> GetCategoriesAdminTrashAsync();
        public Task<Boolean> PutCategoryTrashAsync(List<int> ids);
        public  Task<Boolean> PostCategoryAsync(Category category);
        public Task<Boolean> PutCategoryAsync(Category category);
        public Task<Boolean> DeletedCategoryAsync(List<int> ids);
    }
}
