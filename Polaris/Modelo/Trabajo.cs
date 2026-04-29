using System.ComponentModel.DataAnnotations;

namespace Polaris.Modelo
{
    public class Trabajo
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del proyecto es obligatorio")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "El nombre debe tener entre 3 y 100 caracteres")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "Debe seleccionar una categoría")]
        public string TipoTrabajo { get; set; } = string.Empty;

        [Required(ErrorMessage = "La descripción es necesaria para los tripulantes")]
        public string? Descripcion { get; set; }

        public List<string> Participantes { get; set; } = new();

        [Required]
        public DateTime FechaInicioTrabajo { get; set; } = DateTime.Now;

        [Required]
        public DateTime FechaInicioRegistro { get; set; } = DateTime.Now;

        public DateTime? FechaFinTrabajo { get; set; } = DateTime.Now.AddDays(7);
        public DateTime? FechaFinRegistro { get; set; } = DateTime.Now.AddDays(3);

        public Trabajo Clone() => (Trabajo)this.MemberwiseClone();
    }
}