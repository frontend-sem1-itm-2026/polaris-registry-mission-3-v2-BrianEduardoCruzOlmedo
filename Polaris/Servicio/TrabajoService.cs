using Polaris.Constants;
using Polaris.Modelo;

namespace Polaris.Servicio
{
    public class TrabajoService
    {
        public List<Trabajo> Trabajos { get; set; } = new() {
            new(){
                Id = 1, Nombre = "Desarrollo de Software", TipoTrabajo = TipoEvento.Actividad,
                FechaInicioRegistro = DateTime.Parse("2024-01-01"),
                FechaFinRegistro = null ,
                FechaInicioTrabajo = DateTime.Now,
                FechaFinTrabajo = null,
                Participantes = new()
            },
            new(){
                Id = 2, Nombre = "Diseño Gráfico", TipoTrabajo = TipoEvento.Actividad,
                FechaInicioRegistro = DateTime.Parse("2024-01-01"),
                FechaFinRegistro = DateTime.Parse("2025-01-01") ,
                FechaInicioTrabajo = DateTime.Now,
                FechaFinTrabajo = null,
                Participantes = new(){"1", "3" }
            }, new(){
                Id = 3, Nombre = "Marketing Digital", TipoTrabajo = TipoEvento.Actividad,
                FechaInicioRegistro = DateTime.Parse("2024-01-01"),
                FechaFinRegistro = DateTime.Parse("2024-12-31") ,
                FechaInicioTrabajo = DateTime.Now.AddDays(-7),
                FechaFinTrabajo = DateTime.Now.AddDays(-1),
                Participantes = new(){"1", "2" }
            }
            };
        public void AgregarParticipante(int trabajoId, string participante)
        {
            var trabajo = Trabajos.FirstOrDefault(t => t.Id == trabajoId);
            if (trabajo != null)
            {
                if (!trabajo.Participantes.Contains(participante))
                {
                    trabajo.Participantes.Add(participante);
                }
            }
        }
        public void EliminarParticipante(int trabajoId, string participante)
        {
            var trabajo = Trabajos.FirstOrDefault(t => t.Id == trabajoId);
            if (trabajo != null)
            {
                trabajo.Participantes.Remove(participante);
            }


        }
        public List<Trabajo> ObtenerTrabajosAbiertos()
        {
            return Trabajos.ToList();
        }
        public Trabajo ObtenerTrabajoPorId(int id)
        {

            return Trabajos.FirstOrDefault(t => t.Id == id) ?? new();
        }
        public void AgregarTrabajo(Trabajo trabajo)
        {
            trabajo.Id = Trabajos.Count > 0 ? Trabajos.Max(t => t.Id) + 1 : 1;
            Trabajos.Add(trabajo);
        }
        public void ActualizarTrabajo(Trabajo trabajoActualizado)
        {
            var index = Trabajos.FindIndex(t => t.Id == trabajoActualizado.Id);
            if (index != -1)
            {
                Trabajos[index] = trabajoActualizado;
            }
        }

        public void EliminarTrabajo(int id)
        {
            var trabajo = Trabajos.FirstOrDefault(t => t.Id == id);
            if (trabajo != null)
            {
                Trabajos.Remove(trabajo);
            }
        }
    }
}
