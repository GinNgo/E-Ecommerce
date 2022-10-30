using E_Ecommerce_CustomerSite.Extensions;
using E_Ecommerce_CustomerSite.Service;
using E_Ecommerce_Shared.DTO;
using E_Ecommerce_Shared.Constants;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using System;
using System.Net.Http.Json;
using System.Text;

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

        public async Task<ProductPagingDto> GetProductsBySearchAsync(string query, int pageIndex, int pageSize)
        {


            var products = await httpClient.GetAsJsonAsync<ProductPagingDto>($"Products/GetProductBySearch/?q={query}&pageIndex={pageIndex}&pageSize={pageSize}");


            return products ?? new ProductPagingDto();


        }
        public async Task<ProductPagingDto> GetProductsByCatIdAsync(int id, int pageIndex, int pageSize)
        {


            var products = await httpClient.GetAsJsonAsync<ProductPagingDto>($"Products/GetProductByCat/?id={id}&pageIndex={pageIndex}&pageSize={pageSize}");


            return products ?? new ProductPagingDto();


        }

        public async Task<ProductsDto> GetProductsByIdAsync(int id)
        {
            var product = await httpClient.GetAsJsonOneProAsync<ProductsDto>("Products/" + id);

            return product ?? new ProductsDto();
        }

       
    }
}
