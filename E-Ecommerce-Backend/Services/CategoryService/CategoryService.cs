using AutoMapper;
using E_Ecommerce_Backend.Data;
using E_Ecommerce_Backend.Models;
using E_Ecommerce_Shared.DTO.CategoryDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace E_Ecommerce_Backend.Services.CategoryService
{
    public class CategoryService:ICategoryService
    {
        private readonly EcommecreDbContext _context;
        private readonly IMapper _mapper;

        public CategoryService(EcommecreDbContext ecommecreDbContext,IMapper mapper)
        {
            _context = ecommecreDbContext;
            _mapper = mapper;
        }
        public async Task<List<CategoryDto>> GetCategories()
        {
             var categories = await _context.Categories.ToListAsync();
            
            return _mapper.Map<List<CategoryDto>>(categories);
        }
    }
}
