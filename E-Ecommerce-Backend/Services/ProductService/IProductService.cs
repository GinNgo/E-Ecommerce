﻿using E_Ecommerce_Backend.Models;
using E_Ecommerce_Shared.DTO;
using Microsoft.AspNetCore.Mvc;

namespace E_Ecommerce_Backend.Service.ProductService
{
    public interface IProductService
    {
        public Task<List<ProductsDto>> GetAllProductsAsync();
        public Task<ActionResult<ProductsDto>> GetProductAsync(int id);
    }
}
