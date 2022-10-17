using E_Ecommerce_CustomerSite.Service;
using E_Ecommerce_Shared.DTO.CategoryDto;
using E_Ecommerce_CustomerSite.Extensions;

namespace E_Ecommerce_CustomerSite.Services.CategoryService
{
    public class CategoryService :BaseService, ICategoryService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public CategoryService(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _httpClientFactory = clientFactory;
        }

        public async Task<List<CategoryDto>> GetAllCategorirs()
        {
            var categories = await httpClient.GetAsJsonAsync<List<CategoryDto>>("Category");
            return categories?? new List<CategoryDto>();
        }
    }
}
