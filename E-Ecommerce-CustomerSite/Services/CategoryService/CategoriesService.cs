using E_Ecommerce_CustomerSite.Service;
using E_Ecommerce_CustomerSite.Extensions;
using E_Ecommerce_Shared.DTO.Categories;

namespace E_Ecommerce_CustomerSite.Services.CategoryService
{
    public class CategoriesService :BaseService, ICategoriesService
    {
        public CategoriesService(IHttpClientFactory clientFactory, IHttpContextAccessor httpContextAccessor) : base(clientFactory, httpContextAccessor)
        {
        }

        public async Task<List<CategoriesDto>> GetAllCategories()
        {
            var categories = await httpClient.GetAsJsonAsync<List<CategoriesDto>>("Categories");
            return categories?? new List<CategoriesDto>();
        }

        public async Task<List<CategoriesDto>> GetBreadbrum(int id)
        {
            var categories = await httpClient.GetAsJsonAsync<List<CategoriesDto>>("Categories/GetBreadBrum/"+id);
            return categories ?? new List<CategoriesDto>();
        }
    }
}
