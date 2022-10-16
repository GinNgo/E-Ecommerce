using E_Ecommerce_Backend.Models;

using E_Ecommerce_Shared.DTO.ProductDto;
using Microsoft.AspNetCore.Mvc;

namespace E_Ecommerce_Backend.Service.ProductService
{
    public interface IProductService
    {
        public Task<List<ProductDto>> GetAllProductsAsync();
    }
}
