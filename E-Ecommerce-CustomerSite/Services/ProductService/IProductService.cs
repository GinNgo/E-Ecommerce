
using E_Ecommerce_Shared.DTO;

namespace E_Ecommerce_CustomerSite.Services.ProductService
{
    public interface IProductService
    {
        public Task<List<ProductsDto>> GetAllProductsAsync();
    }
}

