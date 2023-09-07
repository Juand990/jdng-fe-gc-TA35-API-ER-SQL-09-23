using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TA35_04.Models;

namespace TA35_04.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvestigadoresController : ControllerBase
    {
        private readonly InvesContext _context;

        public InvestigadoresController(InvesContext context)
        {
            _context = context;
        }

        // GET: api/Investigadores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Investigadores>>> GetInvestigadores()
        {
          if (_context.Investigadores == null)
          {
              return NotFound();
          }
            return await _context.Investigadores.ToListAsync();
        }

        // GET: api/Investigadores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Investigadores>> GetInvestigadores(string id)
        {
          if (_context.Investigadores == null)
          {
              return NotFound();
          }
            var investigadores = await _context.Investigadores.FindAsync(id);

            if (investigadores == null)
            {
                return NotFound();
            }

            return investigadores;
        }

        // PUT: api/Investigadores/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInvestigadores(string id, Investigadores investigadores)
        {
            if (id != investigadores.DNI)
            {
                return BadRequest();
            }

            _context.Entry(investigadores).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvestigadoresExists(id))
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

        // POST: api/Investigadores
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Investigadores>> PostInvestigadores(Investigadores investigadores)
        {
          if (_context.Investigadores == null)
          {
              return Problem("Entity set 'InvesContext.Investigadores'  is null.");
          }
            _context.Investigadores.Add(investigadores);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (InvestigadoresExists(investigadores.DNI))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetInvestigadores", new { id = investigadores.DNI }, investigadores);
        }

        // DELETE: api/Investigadores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInvestigadores(string id)
        {
            if (_context.Investigadores == null)
            {
                return NotFound();
            }
            var investigadores = await _context.Investigadores.FindAsync(id);
            if (investigadores == null)
            {
                return NotFound();
            }

            _context.Investigadores.Remove(investigadores);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InvestigadoresExists(string id)
        {
            return (_context.Investigadores?.Any(e => e.DNI == id)).GetValueOrDefault();
        }
    }
}
