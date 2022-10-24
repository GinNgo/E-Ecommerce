using AutoMapper;
using E_Ecommerce_Backend.Data;
using E_Ecommerce_Backend.Models;
using E_Ecommerce_Backend.Service.ProductService;
using E_Ecommerce_Shared.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace E_Ecommerce_Backend.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly EcommecreDbContext _context;
        private readonly IMapper _mapper;

        public ProductService(EcommecreDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<ProductsDto>> GetAllProductsAsync()
        {
            var products = await _context.Products.Include(c => c.Brand).Include(c => c.Categories).Include(c => c.Origin).ToListAsync();
            var productsDto = _mapper.Map<List<Product> ,List <ProductsDto>>(products);
            return productsDto ?? new List<ProductsDto>();
        }
    }
}
