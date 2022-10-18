using E_Ecommerce_CustomerSite.Service;
using E_Ecommerce_Shared.DTO.CategoryDto;
using E_Ecommerce_CustomerSite.Extensions;

namespace E_Ecommerce_CustomerSite.Services.CategoryService
{
    public class CategoriesService :BaseService, ICategoriesService
    {
        public CategoriesService(IHttpClientFactory clientFactory) : base(clientFactory)
        {
        }

        public async Task<List<CategoriesDto>> GetAllCategories()
        {
            var categories = await httpClient.GetAsJsonAsync<List<CategoriesDto>>("Categories");
            return categories?? new List<CategoriesDto>();
        }
    }
}
