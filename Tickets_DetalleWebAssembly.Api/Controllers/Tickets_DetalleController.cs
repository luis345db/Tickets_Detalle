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
    public class Tickets_DetalleController : ControllerBase
    {
        private readonly Contexto _context;

        public Tickets_DetalleController(Contexto context)
        {
            _context = context;
        }

        // GET: api/Tickets_Detalle
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tickets_Detalle>>> GetTickets_Detalle()
        {
            return await _context.Tickets_Detalle.ToListAsync();
        }

        // GET: api/Tickets_Detalle/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tickets_Detalle>> GetTickets_Detalle(int id)
        {
            var tickets_Detalle = await _context.Tickets_Detalle.FindAsync(id);

            if (tickets_Detalle == null)
            {
                return NotFound();
            }

            return tickets_Detalle;
        }

        // PUT: api/Tickets_Detalle/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTickets_Detalle(int id, Tickets_Detalle tickets_Detalle)
        {
            if (id != tickets_Detalle.DetalleId)
            {
                return BadRequest();
            }

            _context.Entry(tickets_Detalle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Tickets_DetalleExists(id))
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

        // POST: api/Tickets_Detalle
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tickets_Detalle>> PostTickets_Detalle(Tickets_Detalle tickets_Detalle)
        {
            _context.Tickets_Detalle.Add(tickets_Detalle);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTickets_Detalle", new { id = tickets_Detalle.DetalleId }, tickets_Detalle);
        }

        // DELETE: api/Tickets_Detalle/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTickets_Detalle(int id)
        {
            var tickets_Detalle = await _context.Tickets_Detalle.FindAsync(id);
            if (tickets_Detalle == null)
            {
                return NotFound();
            }

            _context.Tickets_Detalle.Remove(tickets_Detalle);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Tickets_DetalleExists(int id)
        {
            return _context.Tickets_Detalle.Any(e => e.DetalleId == id);
        }
    }
}
