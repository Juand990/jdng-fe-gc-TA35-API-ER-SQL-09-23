using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TA35_01.Models;

namespace TA35_01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuministrasController : ControllerBase
    {
        private readonly pieprosumContext _context;

        public SuministrasController(pieprosumContext context)
        {
            _context = context;
        }

        // GET: api/Suministras
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Suministra>>> GetSuministra()
        {
          if (_context.Suministra == null)
          {
              return NotFound();
          }
            return await _context.Suministra.ToListAsync();
        }

        // GET: api/Suministras/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Suministra>> GetSuministra(int id)
        {
          if (_context.Suministra == null)
          {
              return NotFound();
          }
            var suministra = await _context.Suministra.FindAsync(id);

            if (suministra == null)
            {
                return NotFound();
            }

            return suministra;
        }

        // PUT: api/Suministras/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSuministra(int id, Suministra suministra)
        {
            if (id != suministra.CodigoPieza)
            {
                return BadRequest();
            }

            _context.Entry(suministra).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SuministraExists(id))
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

        // POST: api/Suministras
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Suministra>> PostSuministra(Suministra suministra)
        {
          if (_context.Suministra == null)
          {
              return Problem("Entity set 'pieprosumContext.Suministra'  is null.");
          }
            _context.Suministra.Add(suministra);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SuministraExists(suministra.CodigoPieza))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSuministra", new { id = suministra.CodigoPieza }, suministra);
        }

        // DELETE: api/Suministras/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSuministra(int id)
        {
            if (_context.Suministra == null)
            {
                return NotFound();
            }
            var suministra = await _context.Suministra.FindAsync(id);
            if (suministra == null)
            {
                return NotFound();
            }

            _context.Suministra.Remove(suministra);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SuministraExists(int id)
        {
            return (_context.Suministra?.Any(e => e.CodigoPieza == id)).GetValueOrDefault();
        }
    }
}
