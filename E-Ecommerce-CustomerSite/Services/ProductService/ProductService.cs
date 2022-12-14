using E_Ecommerce_CustomerSite.Extensions;
using E_Ecommerce_CustomerSite.Service;
using E_Ecommerce_Shared.DTO;
using E_Ecommerce_Shared.Constants;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using System;
using System.Net.Http.Json;
using System.Text;
using E_Ecommerce_Shared.DTO.Product;

namespace E_Ecommerce_CustomerSite.Services.ProductService
{
    public class ProductService : BaseService, IProductService
    {
        public ProductService(IHttpClientFactory clientFactory, IHttpContextAccessor httpContextAccessor) : base(clientFactory, httpContextAccessor)
        {
        }

        public async Task<List<ProductsDto>> GetAllProductsAsync()
        {
            var products = await httpClient.GetAsJsonAsync<List<ProductsDto>>("Products");

            return products ?? new List<ProductsDto>();
        }

        public async Task<ProductPagingDto> GetProductsBySearchAsync(PagingRequestDto pagingRequestDto)
        {
            var products = await httpClient.PostAsJsonAsync<PagingRequestDto, ProductPagingDto>($"Products/GetProductBySearch/", pagingRequestDto);
            return products ?? new ProductPagingDto();
        }
        public async Task<ProductPagingDto> GetProductPagingAsync(PagingRequestDto pagingRequestDto)
        {
            var products = await httpClient.PostAsJsonAsync<PagingRequestDto, ProductPagingDto>($"Products/GetProductPaging/", pagingRequestDto);
            return products ?? new ProductPagingDto();
        }
        public async Task<ProductPagingDto> GetProductsByCatIdAsync(PagingRequestDto pagingRequestDto)
        {


            var products = await httpClient.PostAsJsonAsync<PagingRequestDto, ProductPagingDto>("Products/GetProductByCat/", pagingRequestDto);


            return products ?? new ProductPagingDto();


        }

        public async Task<ProductsDto> GetProductsByIdAsync(int id)
        {
            var product = await httpClient.GetAsJsonAsync<ProductsDto>("Products/" + id);

            return product ?? new ProductsDto();
        }

        public async Task<ProductsDto> PostProductsRatingAsync(RatingDto ratingDto)
        {
            var product = await httpClient.PostAsJsonAsync<RatingDto, ProductsDto>("Products/PostProductRating/", ratingDto);


            return product ?? new ProductsDto();
        }
    }
}
