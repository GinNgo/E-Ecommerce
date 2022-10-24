using AutoMapper;
using E_Ecommerce_Backend.Data;
using E_Ecommerce_Backend.Models;
using E_Ecommerce_Shared.DTO;
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
            var categoriesDto = _mapper.Map<List<Category>,List<CategoriesDto>>(categories);
            categoriesDto = SubCategories(categoriesDto);
            return categoriesDto;
        }

        public List<CategoriesDto> SubCategories(List<CategoriesDto> categoriesDtos, int ParentId = 0)
        {
            var categories = new List<CategoriesDto>();
            foreach(var category in categoriesDtos)
            {
                if (category.ParentId.Equals(ParentId))
                { 
                    List<CategoriesDto> categoriesDtos1 = new List<CategoriesDto>(categoriesDtos);
                    categoriesDtos1.Remove(category);
                    var child = SubCategories(categoriesDtos, category.CategoryId);
                    category.Child = child;
                    categories.Add(category);
                }
            }
            return categories;
        }
    }
}
