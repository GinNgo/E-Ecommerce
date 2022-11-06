using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using E_Ecommerce_Backend.Data;
using E_Ecommerce_Backend.Models;
using E_Ecommerce_Backend.Services.CategoryService;
using E_Ecommerce_Shared.DTO.Categories;

namespace E_Ecommerce_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly EcommecreDbContext _context;
        private readonly ICategoriesService _categoryService;

        public CategoriesController(EcommecreDbContext context, ICategoriesService categoryService)
        {
            _context = context;
            _categoryService = categoryService;
        }

        // GET: api/Category
        [HttpGet]
        public async Task<ActionResult<List<CategoriesDto>>> GetCategoriesAsync()
        {
            try
            {

                var categories = await _categoryService.GetCategoriesAsync();


                return Ok(categories);
            }
            catch
            {
                return BadRequest();
            }


        }

        [HttpGet("admin")]
        public async Task<List<CategoryAdmin>> GetCategoriesAdminAsync()
        {
                var categories = await _categoryService.GetCategoriesAdminAsync();
                return categories;
           
        }

        [HttpGet("catParentList")]
        public async Task<List<CategoryParent>> GetCategoriesParentAsync()
        {
            var categories = await _categoryService.GetCategoriesParentAsync();
            return categories;

        }
      
        // GET: api/Category/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryAdmin>> GetCategoryAsync(int id)
        {
            var category = await _categoryService.GetOneCategoryAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            return category;
        }

        [HttpGet("GetBreadBrum/{id}")]
        public async Task<ActionResult<List<CategoriesDto>>> GetBreadBrum(int id)
        {
            var ListBreadBrum = await _categoryService.GetBreadCrumb(id);

            if (ListBreadBrum == null)
            {
                return NotFound();
            }

            return ListBreadBrum;
        }


        [HttpGet("ChildId/{id}")]
        public async Task<ActionResult<List<int>>> GetChildCatId(int id)
        {
            var categoriesId = await _categoryService.GetCategoriesIdChild(id);

            if (categoriesId == null)
            {
                return NotFound();
            }

            return categoriesId;
        }
        // PUT: api/Category/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(int id, Category category)
        {
            if (id != category.CategoryId)
            {
                return BadRequest();
            }

            _context.Entry(category).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Category
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Category>> PostCategory(Category category)
        {
            var result =await _categoryService.PostCategory(category);
            if (result == true)
                return Ok(true);
            else
            {
                return BadRequest();
            }
         
        }

        // DELETE: api/Category/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CategoryExists(int id)
        {
            return _context.Categories.Any(e => e.CategoryId == id);
        }
    }
}
