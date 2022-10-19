using E_Ecommerce_Backend.Models;
using E_Ecommerce_Backend.Service.ProductService;
using E_Ecommerce_Shared.DTO;
using Microsoft.AspNetCore.Mvc;

namespace E_Ecommerce_Backend.Services.ProductService
{
    public class ProductService : IProductService
    {
        public async Task<List<ProductsDto>> GetAllProductsAsync()
        {
            // connect database
            // query products
            var result =  new List<ProductsDto>()
            {
                new ProductsDto(){ Id = 1, Name = "Product 1", Quantity = 10 },
                new ProductsDto(){ Id = 2, Name = "Product 2", Quantity = 9 },
                new ProductsDto(){ Id = 3, Name = "Product 3", Quantity = 8 }
            };
          
            return  result;
        }
    }
}
