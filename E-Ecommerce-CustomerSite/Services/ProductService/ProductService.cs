using E_Ecommerce_CustomerSite.Extensions;
using E_Ecommerce_CustomerSite.Service;
using E_Ecommerce_Shared.DTO;
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
            var products = await httpClient.GetAsJsonAsync<List<ProductsDto>>("Products");
           
            return products ?? new List<ProductsDto>();
        }

        public async Task<ProductsDto> GetProductsByIdAsync(int Id)
        {
            var product =await  httpClient.GetAsJsonOneProAsync<ProductsDto>("Products/"+ Id);

            return product ?? new ProductsDto();
        }

      

    }
}
