using System.ComponentModel.DataAnnotations;

namespace TicketsDetalle_WebAssembly.Models
{
    public class Tickets
    {
        [Key]
        public int TicketId { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        public DateTime Fecha { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Este campo es requerido")]
        public string? Asunto { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        public string? Descripcion { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [StringLength(30, ErrorMessage = "No puede exceder los 30 Caracteres")]
        public string? SolicitadoPor { get; set; }
    }
}
