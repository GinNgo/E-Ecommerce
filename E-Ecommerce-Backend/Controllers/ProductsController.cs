using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using E_Ecommerce_Backend.Data;
using E_Ecommerce_Backend.Models;
using E_Ecommerce_Backend.Services.ProductService;
using E_Ecommerce_Shared.DTO;


namespace E_Ecommerce_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly EcommecreDbContext _context;
        private readonly IProductService _productService;

        public ProductsController(EcommecreDbContext context,IProductService productService)
        {
            _context = context;
            _productService = productService;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<List<ProductsDto>>> GetProducts()
        {
            try
            {

                var ListPro = await _productService.GetAllProductsAsync();
                return Ok(ListPro);
            }
            catch
            {
                return BadRequest();
            }

         
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductsDto>> GetProduct(int id)
        {
            var product = await _productService.GetProductAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }
        // GET: api/Products/5
        [HttpGet("GetProductByCat")]
        public async Task<ProductPagingDto> GetProductProductByCat([FromQuery(Name ="id")]int id, [FromQuery(Name = "pageIndex")] int pageIndex, [FromQuery(Name = "pageSize")] int pageSize)
        {
            var products = await _productService.GetProductByCatIdAsync(id,pageIndex, pageSize);

            return products;
        }
       
        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.ProductId)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
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
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduct", new { id = product.ProductId }, product);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.ProductId == id);
        }
    }
}
