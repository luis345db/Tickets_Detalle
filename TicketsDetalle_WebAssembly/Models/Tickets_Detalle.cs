using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TicketsDetalle_WebAssembly.Models
{
    public class Tickets_Detalle
    {
        
            [Key]
            public int DetalleId { get; set; }
            [Required(ErrorMessage = "Este campo es requerido")]
            [ForeignKey("TicketId")]
            public int TicketId { get; set; }
            [Required(ErrorMessage = "Este campo es requerido")]
            public string? Emisor { get; set; }
            [Required(ErrorMessage = "Este campo es requerido")]
            public string? Mensaje { get; set; }
    }
}
