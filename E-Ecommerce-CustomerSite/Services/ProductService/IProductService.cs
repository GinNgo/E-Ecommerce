
using E_Ecommerce_Shared.DTO;

namespace E_Ecommerce_CustomerSite.Services.ProductService
{
    public interface IProductService
    {
        public Task<List<ProductsDto>> GetAllProductsAsync();
        public Task<ProductsDto> GetProductsByIdAsync(int id);
        public  Task<List<ProductsDto>> GetProductsByCatIdAsync(int id ,int pageIndex, int pageSize);
        public Task<int> GetTotalProByCatAsync(int id);
    }
}

