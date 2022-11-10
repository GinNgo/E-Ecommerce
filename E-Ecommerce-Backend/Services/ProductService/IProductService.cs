using E_Ecommerce_Shared.DTO;
using E_Ecommerce_Shared.DTO.Admin;
using E_Ecommerce_Shared.DTO.Product;
using Microsoft.AspNetCore.Mvc;

namespace E_Ecommerce_Backend.Services.ProductService
{
    public interface IProductService
    {
        public Task<List<ProductAdmin>> GetAllProductsAsync();
        public Task<ProductPagingDto> GetAllProductsPaingAsync(PagingRequestDto pagingRequestDto);
        public Task<ActionResult<ProductsDto>> GetProductAsync(int id);
        public Task<ProductPagingDto> GetProductByCatIdAsync(PagingRequestDto pagingRequestDto);
        public Task<ProductPagingDto> GetProductBySearchAsync(PagingRequestDto pagingRequestDto);
        public Task<ProductsDto> PostProductRatingAsync(RatingDto ratingDto);


    }
}
