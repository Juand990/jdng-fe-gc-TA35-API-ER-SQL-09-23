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
    public class CientificosController : ControllerBase
    {
        private readonly CientProyContext _context;

        public CientificosController(CientProyContext context)
        {
            _context = context;
        }

        // GET: api/Cientificos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cientificos>>> GetCientificos()
        {
          if (_context.Cientificos == null)
          {
              return NotFound();
          }
            return await _context.Cientificos.ToListAsync();
        }

        // GET: api/Cientificos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cientificos>> GetCientificos(string id)
        {
          if (_context.Cientificos == null)
          {
              return NotFound();
          }
            var cientificos = await _context.Cientificos.FindAsync(id);

            if (cientificos == null)
            {
                return NotFound();
            }

            return cientificos;
        }

        // PUT: api/Cientificos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCientificos(string id, Cientificos cientificos)
        {
            if (id != cientificos.DNI)
            {
                return BadRequest();
            }

            _context.Entry(cientificos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CientificosExists(id))
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

        // POST: api/Cientificos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cientificos>> PostCientificos(Cientificos cientificos)
        {
          if (_context.Cientificos == null)
          {
              return Problem("Entity set 'CientProyContext.Cientificos'  is null.");
          }
            _context.Cientificos.Add(cientificos);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CientificosExists(cientificos.DNI))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCientificos", new { id = cientificos.DNI }, cientificos);
        }

        // DELETE: api/Cientificos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCientificos(string id)
        {
            if (_context.Cientificos == null)
            {
                return NotFound();
            }
            var cientificos = await _context.Cientificos.FindAsync(id);
            if (cientificos == null)
            {
                return NotFound();
            }

            _context.Cientificos.Remove(cientificos);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CientificosExists(string id)
        {
            return (_context.Cientificos?.Any(e => e.DNI == id)).GetValueOrDefault();
        }
    }
}
