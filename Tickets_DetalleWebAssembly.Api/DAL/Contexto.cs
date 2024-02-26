using Microsoft.EntityFrameworkCore;
using TicketsDetalle_WebAssembly.Models;

namespace Tickets_DetalleWebAssembly.DAL
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }
        public DbSet<Tickets> Tickets { get; set; }
        public DbSet<Tickets_Detalle> Tickets_Detalle { get; set; }
    }
}
