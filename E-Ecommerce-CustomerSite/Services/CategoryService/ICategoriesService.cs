using E_Ecommerce_Shared.DTO.CategoryDto;
using Microsoft.AspNetCore.Mvc;

namespace E_Ecommerce_CustomerSite.Services.CategoryService
{
    public interface ICategoriesService
    {
        public Task<List<CategoriesDto>> GetAllCategories();
    }
}
