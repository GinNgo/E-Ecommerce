using E_Ecommerce_Backend.Models;
using E_Ecommerce_Shared.DTO;
using E_Ecommerce_Shared.DTO.Admin;
using E_Ecommerce_Shared.DTO.Product;
using E_Ecommerce_Shared.DTO.Products;
using Microsoft.AspNetCore.Mvc;

namespace E_Ecommerce_Backend.Services.ProductService
{
    public interface IProductService
    {
        public Task<List<ProductAdmin>> GetAllProductsAsync();
        public Task<List<ProductAdmin>> GetAllProductsTrashAsync();
        public Task<ProductPagingDto> GetAllProductsPaingAsync(PagingRequestDto pagingRequestDto);
        public Task<ProductsDto> GetProductAsync(int id);
        public Task<ProductPagingDto> GetProductByCatIdAsync(PagingRequestDto pagingRequestDto);
        public Task<ProductPagingDto> GetProductBySearchAsync(PagingRequestDto pagingRequestDto);
        public Task<ProductsDto> PostProductRatingAsync(RatingDto ratingDto, int userId);
        public Task<int> PostProductAsync(ProductCreate product);
        public Task<Boolean> PutProductTrashAsync(List<int> ids);
        public Task<Boolean> DeletedProdutAsync(List<int> ids);
    }
}
