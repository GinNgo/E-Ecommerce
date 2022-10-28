using E_Ecommerce_Shared.DTO;
using Microsoft.AspNetCore.Mvc;

namespace E_Ecommerce_CustomerSite.Services.CategoryService
{
    public interface ICategoriesService
    {
        public Task<List<CategoriesDto>> GetAllCategories();
        public Task<List<CategoriesDto>> GetBreadbrum(int id);
    }
}
