using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TA35_03.Models;

namespace TA35_03.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaqRegistradorasController : ControllerBase
    {
        private readonly AlmacenContext _context;

        public MaqRegistradorasController(AlmacenContext context)
        {
            _context = context;
        }

        // GET: api/MaqRegistradoras
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MaqRegistradoras>>> GetMaquinas()
        {
          if (_context.Maquinas == null)
          {
              return NotFound();
          }
            return await _context.Maquinas.ToListAsync();
        }

        // GET: api/MaqRegistradoras/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MaqRegistradoras>> GetMaqRegistradoras(int id)
        {
          if (_context.Maquinas == null)
          {
              return NotFound();
          }
            var maqRegistradoras = await _context.Maquinas.FindAsync(id);

            if (maqRegistradoras == null)
            {
                return NotFound();
            }

            return maqRegistradoras;
        }

        // PUT: api/MaqRegistradoras/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMaqRegistradoras(int id, MaqRegistradoras maqRegistradoras)
        {
            if (id != maqRegistradoras.Codigo)
            {
                return BadRequest();
            }

            _context.Entry(maqRegistradoras).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MaqRegistradorasExists(id))
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

        // POST: api/MaqRegistradoras
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MaqRegistradoras>> PostMaqRegistradoras(MaqRegistradoras maqRegistradoras)
        {
          if (_context.Maquinas == null)
          {
              return Problem("Entity set 'AlmacenContext.Maquinas'  is null.");
          }
            _context.Maquinas.Add(maqRegistradoras);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMaqRegistradoras", new { id = maqRegistradoras.Codigo }, maqRegistradoras);
        }

        // DELETE: api/MaqRegistradoras/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMaqRegistradoras(int id)
        {
            if (_context.Maquinas == null)
            {
                return NotFound();
            }
            var maqRegistradoras = await _context.Maquinas.FindAsync(id);
            if (maqRegistradoras == null)
            {
                return NotFound();
            }

            _context.Maquinas.Remove(maqRegistradoras);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MaqRegistradorasExists(int id)
        {
            return (_context.Maquinas?.Any(e => e.Codigo == id)).GetValueOrDefault();
        }
    }
}
