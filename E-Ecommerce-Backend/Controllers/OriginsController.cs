using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using E_Ecommerce_Backend.Data;
using E_Ecommerce_Backend.Models;

namespace E_Ecommerce_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OriginsController : ControllerBase
    {
        private readonly EcommecreDbContext _context;

        public OriginsController(EcommecreDbContext context)
        {
            _context = context;
        }

        // GET: api/Origins
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Origin>>> GetOrigins()
        {
            return await _context.Origins.ToListAsync();
        }

        // GET: api/Origins/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Origin>> GetOrigin(int id)
        {
            var origin = await _context.Origins.FindAsync(id);

            if (origin == null)
            {
                return NotFound();
            }

            return origin;
        }

        // PUT: api/Origins/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrigin(int id, Origin origin)
        {
            if (id != origin.OriginId)
            {
                return BadRequest();
            }

            _context.Entry(origin).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OriginExists(id))
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

        // POST: api/Origins
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Origin>> PostOrigin(Origin origin)
        {
            _context.Origins.Add(origin);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrigin", new { id = origin.OriginId }, origin);
        }

        // DELETE: api/Origins/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrigin(int id)
        {
            var origin = await _context.Origins.FindAsync(id);
            if (origin == null)
            {
                return NotFound();
            }

            _context.Origins.Remove(origin);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OriginExists(int id)
        {
            return _context.Origins.Any(e => e.OriginId == id);
        }
    }
}
