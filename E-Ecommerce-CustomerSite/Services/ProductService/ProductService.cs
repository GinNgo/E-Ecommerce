using E_Ecommerce_CustomerSite.Service;
using E_Ecommerce_Shared.DTO.ProductDto;
using Newtonsoft.Json;

namespace E_Ecommerce_CustomerSite.Services.ProductService
{
    public class ProductService : BaseService, IProductService
    {
        public ProductService(IHttpClientFactory clientFactory) : base(clientFactory)
        {
        }

        public async Task<List<ProductsDto>> GetAllProductsAsync()
        {
            var response = await httpClient.GetAsync("api/product/GetAllProduct");
            var contents = await response.Content.ReadAsStringAsync();
            var products = JsonConvert.DeserializeObject<List<ProductsDto>>(contents);
            return products ?? new List<ProductsDto>();
        }

       
    }
}
