
using E_Ecommerce_Shared.DTO.ProductDto;

namespace E_Ecommerce_CustomerSite.Services.ProductService
{
    public interface IProductService
    {
        public Task<List<ProductDto>> GetAllProductsAsync();
    }
}

