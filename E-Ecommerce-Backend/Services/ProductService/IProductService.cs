using E_Ecommerce_Shared.DTO;
using Microsoft.AspNetCore.Mvc;

namespace E_Ecommerce_Backend.Services.ProductService
{
    public interface IProductService
    {
        public Task<List<ProductsDto>> GetAllProductsAsync();
        public Task<ProductPagingDto> GetAllProductsPaingAsync(PagingRequestDto pagingRequestDto);
        public Task<ActionResult<ProductsDto>> GetProductAsync(int id);
        public Task<ProductPagingDto> GetProductByCatIdAsync(PagingRequestDto pagingRequestDto);
        public Task<ProductPagingDto> GetProductProductBySearchAsync(PagingRequestDto pagingRequestDto);
        public Task<List<RatingDto>> PostProductRatingAsync(RatingDto ratingDto);


    }
}
