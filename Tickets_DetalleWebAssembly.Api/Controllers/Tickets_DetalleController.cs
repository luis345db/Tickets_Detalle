using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TicketsDetalle_WebAssembly.Models;
using Tickets_DetalleWebAssembly.DAL;

namespace Tickets_DetalleWebAssembly.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsDetallesController : ControllerBase
    {
        private readonly Contexto _context;

        public TicketsDetallesController(Contexto context)
        {
            _context = context;
        }

        // GET: api/TicketsDetalles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tickets_Detalle>>> GetTicketsDetalle()
        {
            return await _context.Tickets_Detalle.ToListAsync();
        }

        // GET: api/TicketsDetalles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tickets_Detalle>> GetTicketsDetalle(int id)
        {
            var ticketsDetalle = await _context.Tickets_Detalle.FindAsync(id);

            if (ticketsDetalle == null)
            {
                return NotFound();
            }

            return ticketsDetalle;
        }

        // PUT: api/TicketsDetalles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTicketsDetalle(int id, Tickets_Detalle ticketsDetalle)
        {
            if (id != ticketsDetalle.DetalleId)
            {
                return BadRequest();
            }

            _context.Entry(ticketsDetalle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TicketsDetalleExists(id))
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

        // POST: api/TicketsDetalles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tickets_Detalle>> PostTicketsDetalle(Tickets_Detalle ticketsDetalle)
        {
            _context.Tickets_Detalle.Add(ticketsDetalle);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTicketsDetalle", new { id = ticketsDetalle.DetalleId }, ticketsDetalle);
        }

        // DELETE: api/TicketsDetalles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTicketsDetalle(int id)
        {
            var ticketsDetalle = await _context.Tickets_Detalle.FindAsync(id);
            if (ticketsDetalle == null)
            {
                return NotFound();
            }

            _context.Tickets_Detalle.Remove(ticketsDetalle);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TicketsDetalleExists(int id)
        {
            return _context.Tickets_Detalle.Any(e => e.DetalleId == id);
        }
    }
}
