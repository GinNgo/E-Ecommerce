using AutoMapper;
using E_Ecommerce_Backend.Data;
using E_Ecommerce_Backend.Models;
using E_Ecommerce_Shared.DTO.CategoryDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace E_Ecommerce_Backend.Services.CategoryService
{
    public class CategoriesService:ICategoriesService
    {
        private readonly EcommecreDbContext _context;
        private readonly IMapper _mapper;

        public CategoriesService(EcommecreDbContext ecommecreDbContext,IMapper mapper)
        {
            _context = ecommecreDbContext;
            _mapper = mapper;
        }
        public async Task<List<CategoriesDto>> GetCategories()
        {
             var categories = await _context.Categories.ToListAsync();
            
            return _mapper.Map<List<CategoriesDto>>(categories);
        }
    }
}
