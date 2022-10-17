using E_Ecommerce_Shared.DTO.CategoryDto;
using Microsoft.AspNetCore.Mvc;

namespace E_Ecommerce_CustomerSite.Services.CategoryService
{
    public interface ICategoryService
    {
        public Task<List<CategoryDto>> GetAllCategorirs();
    }
}
