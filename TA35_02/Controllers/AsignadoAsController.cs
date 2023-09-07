using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TA35_02.Models;

namespace TA35_02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsignadoAsController : ControllerBase
    {
        private readonly CientProyContext _context;

        public AsignadoAsController(CientProyContext context)
        {
            _context = context;
        }

        // GET: api/AsignadoAs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AsignadoA>>> GetAsignadoA()
        {
          if (_context.AsignadoA == null)
          {
              return NotFound();
          }
            return await _context.AsignadoA.ToListAsync();
        }

        // GET: api/AsignadoAs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AsignadoA>> GetAsignadoA(string id)
        {
          if (_context.AsignadoA == null)
          {
              return NotFound();
          }
            var asignadoA = await _context.AsignadoA.FindAsync(id);

            if (asignadoA == null)
            {
                return NotFound();
            }

            return asignadoA;
        }

        // PUT: api/AsignadoAs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsignadoA(string id, AsignadoA asignadoA)
        {
            if (id != asignadoA.CientificoDni)
            {
                return BadRequest();
            }

            _context.Entry(asignadoA).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AsignadoAExists(id))
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

        // POST: api/AsignadoAs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AsignadoA>> PostAsignadoA(AsignadoA asignadoA)
        {
          if (_context.AsignadoA == null)
          {
              return Problem("Entity set 'CientProyContext.AsignadoA'  is null.");
          }
            _context.AsignadoA.Add(asignadoA);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AsignadoAExists(asignadoA.CientificoDni))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAsignadoA", new { id = asignadoA.CientificoDni }, asignadoA);
        }

        // DELETE: api/AsignadoAs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsignadoA(string id)
        {
            if (_context.AsignadoA == null)
            {
                return NotFound();
            }
            var asignadoA = await _context.AsignadoA.FindAsync(id);
            if (asignadoA == null)
            {
                return NotFound();
            }

            _context.AsignadoA.Remove(asignadoA);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AsignadoAExists(string id)
        {
            return (_context.AsignadoA?.Any(e => e.CientificoDni == id)).GetValueOrDefault();
        }
    }
}
