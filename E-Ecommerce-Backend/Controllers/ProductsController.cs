using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using E_Ecommerce_Backend.Data;
using E_Ecommerce_Shared.DTO.ProductDto;

namespace E_Ecommerce_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly EcommecreDbContext _context;

        public ProductsController(EcommecreDbContext context)
        {
            _context = context;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductsDto>>> GetProductsDto()
        {
            return await _context.ProductsDto.ToListAsync();
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductsDto>> GetProductsDto(int id)
        {
            var productsDto = await _context.ProductsDto.FindAsync(id);

            if (productsDto == null)
            {
                return NotFound();
            }

            return productsDto;
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductsDto(int id, ProductsDto productsDto)
        {
            if (id != productsDto.Id)
            {
                return BadRequest();
            }

            _context.Entry(productsDto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductsDtoExists(id))
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

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProductsDto>> PostProductsDto(ProductsDto productsDto)
        {
            _context.ProductsDto.Add(productsDto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductsDto", new { id = productsDto.Id }, productsDto);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductsDto(int id)
        {
            var productsDto = await _context.ProductsDto.FindAsync(id);
            if (productsDto == null)
            {
                return NotFound();
            }

            _context.ProductsDto.Remove(productsDto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductsDtoExists(int id)
        {
            return _context.ProductsDto.Any(e => e.Id == id);
        }
    }
}
