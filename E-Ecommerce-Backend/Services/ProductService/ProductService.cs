using AutoMapper;
using E_Ecommerce_Backend.Data;
using E_Ecommerce_Backend.Models;

using E_Ecommerce_Backend.Services.CategoryService;
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
        private readonly ICategoriesService _categoriesService;

        public ProductService(EcommecreDbContext context, IMapper mapper, ICategoriesService categoriesService)
        {
            _context = context;
            _mapper = mapper;
            _categoriesService = categoriesService;
        }
        public async Task<List<ProductsDto>> GetAllProductsAsync()
        {
            var products = await _context.Products.Include(c => c.Brand).Include(c => c.Categories).Include(c => c.Origin).ToListAsync();
            var productsDto = _mapper.Map<List<Product>, List<ProductsDto>>(products);
            return productsDto ?? new List<ProductsDto>();
        }

        public async Task<ActionResult<ProductsDto>> GetProductAsync(int id)
        {
            ProductsDto productsDto = new ProductsDto();
            var product = await _context.Products.Include(c => c.Brand).Include(c => c.Categories).Include(c => c.Origin).Where(e => e.ProductId == id).FirstOrDefaultAsync();
            if (product != null)
            {
                productsDto = _mapper.Map<Product, ProductsDto>(product);
            }
            return productsDto;
        }
        public async Task<ProductPagingDto> GetProductByCatIdAsync( int id, int pageIndex,int pageSize)
        {

            ProductPagingDto ProductPagingDto = new ProductPagingDto();

            List<int> ListId = await _categoriesService.GetCategoriesIdChild(id);
            ProductPagingDto.totalCount = await GetTotalProByCatAsync(ListId);

            if (ListId.Count > 1)
            {
             foreach(var i in ListId)
                {
                    if (ProductPagingDto.products.Count == 10)
                    {
                        break;
                    }
                    var products = _context.Products
                     .Include(c => c.Brand)
                     .Include(c => c.Categories)
                     .Include(c => c.Origin)
                     .Where(e => e.CategoryId == i)
                     .Skip((pageSize - ProductPagingDto.products.Count) * (pageIndex - 1) )
                     .Take(pageSize)
                     .AsQueryable();
                     
                   var Listproducts = products.ToList();
                    if (Listproducts != null)
                    {
                        var result = _mapper.Map<List<Product>, List<ProductsDto>>(Listproducts);
                        result.ForEach(pro =>
                        {
                            ProductPagingDto.products.Add(pro);
                        });
                    }
                };
            }
            else
            {
                var products = await _context.Products
                       .Include(c => c.Brand)
                     .Include(c => c.Categories)
                     .Include(c => c.Origin)
                     .Where(e => e.CategoryId == id)
                    .Skip(pageSize * (pageIndex - 1)).Take(pageSize)
                    .ToListAsync();
                if (products != null)
                {
                    ProductPagingDto.products = _mapper.Map<List<Product>, List<ProductsDto>>(products);
                }
            }

            return ProductPagingDto;
        }

        public async Task<int>GetTotalProByCatAsync(List<int> ListId)
        {
            int total = 0;
      
            if (ListId.Count > 1)
            {
                ListId.ForEach(e =>
                {
                    var numberPro = _context.Products
                    .Where(i => i.CategoryId == e).Count();
                    total += numberPro;
                });
            }
            else
            {
                var numberPro = await _context.Products.Where(i => i.CategoryId == ListId.First()).CountAsync();
                total += numberPro;
            }
            return total;
        }
    }
}
