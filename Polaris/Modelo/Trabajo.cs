namespace Polaris.Modelo
{
    public class Trabajo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public string TipoTrabajo { get; set; }

        public List<string> Participantes { get; set; } = new();
        public string? Descripcion { get; set; }
        public DateTime FechaInicioTrabajo { get; set; } = DateTime.Now;
        public DateTime FechaInicioRegistro { get; set; } = DateTime.Now;
        public DateTime? FechaFinTrabajo { get; set; } = DateTime.Now.AddDays(7);
        public DateTime? FechaFinRegistro { get; set; } = DateTime.Now.AddDays(3);
        public Trabajo Clone() => (Trabajo)this.MemberwiseClone();
    }
}
