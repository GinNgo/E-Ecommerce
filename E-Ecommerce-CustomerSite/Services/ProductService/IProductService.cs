
using E_Ecommerce_Shared.DTO;
using E_Ecommerce_Shared.DTO.Product;

namespace E_Ecommerce_CustomerSite.Services.ProductService
{
    public interface IProductService
    {
        public Task<List<ProductsDto>> GetAllProductsAsync();
        public Task<ProductsDto> GetProductsByIdAsync(int id);
        public Task<ProductPagingDto> GetProductsByCatIdAsync(PagingRequestDto pagingRequestDto);
        public Task<ProductPagingDto> GetProductsBySearchAsync(PagingRequestDto pagingRequestDto);
        public Task<ProductsDto> PostProductsRatingAsync(RatingDto ratingDto);
        public Task<ProductPagingDto> GetProductPagingAsync(PagingRequestDto pagingRequestDto);
    }
}

