using E_Ecommerce_CustomerSite.Service;
using E_Ecommerce_Shared.DTO.CategoryDto;


namespace E_Ecommerce_CustomerSite.Services.CategoryService
{
    public class CategoryService :BaseService, ICategoryService
    {
        public CategoryService(IHttpClientFactory clientFactory) : base(clientFactory)
        {
        }

        public async Task<List<CategoryDto>> GetAllCategorirs()
        {
            var categories= await httpClient.
            return categories?? new List<CategoryDto>();
        }
    }
}
