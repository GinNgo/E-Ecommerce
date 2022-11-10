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
using E_Ecommerce_Shared.DTO.Admin;

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

        [HttpGet("adminTrash")]
        public async Task<List<CategoryAdmin>> GetCategoriesAdminTrashAsync()
        {
            var categories = await _categoryService.GetCategoriesAdminTrashAsync();
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
        [HttpPut]
        public async Task<IActionResult> PutCategory(Category category)
        {


            var result = await _categoryService.PutCategoryAsync(category);
            if (result == true)
                return Ok(true);
            else
            {
                return BadRequest(false);
            }
        }

        [HttpPut("Trash")]
        public async Task<IActionResult> PutCategoryTrash(List<int> ids)
        {


            var result = await _categoryService.PutCategoryTrashAsync(ids);
            if (result == true)
                return Ok(true);
            else
            {
                return BadRequest(false);
            }
        }

        // POST: api/Category
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Category>> PostCategory(Category category)
        {
            var result = await _categoryService.PostCategoryAsync(category);
            if (result == true)
                return Ok(true);
            else
            {
                return BadRequest(false);
            }

        }

        // DELETE: api/Category/5
        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(List<int> ids)
        {
            var result = await _categoryService.DeletedCategoryAsync(ids);
            if (result == true)
                return Ok(true);
            else
            {
                return BadRequest(false);
            }
        }

        private bool CategoryExists(int id)
        {
            return _context.Categories.Any(e => e.CategoryId == id);
        }
    }
}
