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
    public class PiezasController : ControllerBase
    {
        private readonly pieprosumContext _context;

        public PiezasController(pieprosumContext context)
        {
            _context = context;
        }

        // GET: api/Piezas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Piezas>>> GetPiezas()
        {
          if (_context.Piezas == null)
          {
              return NotFound();
          }
            return await _context.Piezas.ToListAsync();
        }

        // GET: api/Piezas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Piezas>> GetPiezas(int id)
        {
          if (_context.Piezas == null)
          {
              return NotFound();
          }
            var piezas = await _context.Piezas.FindAsync(id);

            if (piezas == null)
            {
                return NotFound();
            }

            return piezas;
        }

        // PUT: api/Piezas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPiezas(int id, Piezas piezas)
        {
            if (id != piezas.Codigo)
            {
                return BadRequest();
            }

            _context.Entry(piezas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PiezasExists(id))
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

        // POST: api/Piezas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Piezas>> PostPiezas(Piezas piezas)
        {
          if (_context.Piezas == null)
          {
              return Problem("Entity set 'pieprosumContext.Piezas'  is null.");
          }
            _context.Piezas.Add(piezas);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPiezas", new { id = piezas.Codigo }, piezas);
        }

        // DELETE: api/Piezas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePiezas(int id)
        {
            if (_context.Piezas == null)
            {
                return NotFound();
            }
            var piezas = await _context.Piezas.FindAsync(id);
            if (piezas == null)
            {
                return NotFound();
            }

            _context.Piezas.Remove(piezas);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PiezasExists(int id)
        {
            return (_context.Piezas?.Any(e => e.Codigo == id)).GetValueOrDefault();
        }
    }
}
