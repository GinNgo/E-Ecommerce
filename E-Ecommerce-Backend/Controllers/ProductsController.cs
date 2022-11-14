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
using E_Ecommerce_Shared.DTO.Product;
using E_Ecommerce_Shared.DTO.Admin;
using Microsoft.AspNetCore.Authorization;

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
        public async Task<ActionResult<List<ProductAdmin>>> GetProducts()
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
        [HttpGet("AdminTrash")]
        public async Task<ActionResult<List<ProductAdmin>>> GetProductsTrash()
        {
            try
            {
                var ListPro = await _productService.GetAllProductsTrashAsync();
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
        [HttpPost("GetProductByCat")]
        public async Task<ProductPagingDto> GetProductProductByCat([FromBody] PagingRequestDto pagingRequestDto)
        {
            var products = await _productService.GetProductByCatIdAsync(pagingRequestDto);

            return products;
        }

        [HttpPost("GetProductBySearch")]
        public async Task<IActionResult> GetProductBySearchAsync([FromBody] PagingRequestDto pagingRequestDto)
        {
           
            var products = await _productService.GetProductBySearchAsync(pagingRequestDto);

            return Ok(products);
        }

        [HttpPost("GetProductPaging")]
        public async Task<IActionResult> GetProductPagingAsync([FromBody] PagingRequestDto pagingRequestDto)
        {

            var products = await _productService.GetAllProductsPaingAsync(pagingRequestDto);

            return Ok(products);
        }

        [HttpPost("PostProductRating")]
        [Authorize]
        public async Task<ProductsDto> PostProductRating([FromBody] RatingDto ratingDto)
        {
            var userId = int.Parse(User.Claims.FirstOrDefault(u => u.Type == "UserId")?.Value);
            var product = await _productService.PostProductRatingAsync(ratingDto, userId);

            return product;
        }

        [HttpPut("Trash")]
        public async Task<IActionResult> PutCategoryTrash(List<int> ids)
        {


            var result = await _productService.PutProductTrashAsync(ids);
            if (result == true)
                return Ok(true);
            else
            {
                return BadRequest(false);
            }
        }
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

        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(List<int> ids)
        {
            var result = await _productService.DeletedProdutAsync(ids);
            if (result == true)
                return Ok(true);
            else
            {
                return BadRequest(false);
            }
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
