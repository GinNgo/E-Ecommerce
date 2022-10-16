using E_Ecommerce_Backend.Data;
using E_Ecommerce_Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace E_Ecommerce_Backend.Services.CategoryService
{
    public class CategoryService:ICategoryService
    {
        private readonly EcommecreDbContext _context;
        public CategoryService(EcommecreDbContext ecommecreDbContext)
        {
            _context = ecommecreDbContext;
        }
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
             var result = await _context.Categories.ToListAsync();
            
            return result;
        }
    }
}
