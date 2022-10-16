using E_Ecommerce_Backend.Models;
using E_Ecommerce_Backend.Service.ProductService;
using E_Ecommerce_Shared.DTO.ProductDto;
using Microsoft.AspNetCore.Mvc;

namespace E_Ecommerce_Backend.Services.ProductService
{
    public class ProductService : IProductService
    {
        public async Task<List<ProductDto>> GetAllProductsAsync()
        {
            // connect database
            // query products
            var result = new List<ProductDto>()
            {
                new ProductDto(){ Id = 1, Name = "Product 1", Quantity = 10 },
                new ProductDto(){ Id = 2, Name = "Product 2", Quantity = 9 },
                new ProductDto(){ Id = 3, Name = "Product 3", Quantity = 8 }
            };
          
            return result;
        }
    }
}
