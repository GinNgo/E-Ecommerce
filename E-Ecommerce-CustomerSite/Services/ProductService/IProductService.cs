
using E_Ecommerce_Shared.DTO;

namespace E_Ecommerce_CustomerSite.Services.ProductService
{
    public interface IProductService
    {
        public Task<List<ProductsDto>> GetAllProductsAsync();
        public Task<ProductsDto> GetProductsByIdAsync(int id);
        public Task<ProductPagingDto> GetProductsByCatIdAsync(int id, int pageIndex, int pageSize);
        public Task<ProductPagingDto> GetProductsBySearchAsync(string query, int pageIndex, int pageSize);
 
    }
}

