using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Polaris.Modelo
{
    public class Usuario
    {
        public string Id { get; set; }
        public byte[]? Foto { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
        public int Proyecto { get; set; }
        public string Telefono { get; set; } = "";
        public DateOnly FechaNac { get; set; }

        public string Instituto { get; set; }
        public int Carrera { get; set; }
        public int Semestre { get; set; }
        public int GenPolaris { get; set; }
        public List<int> Habilidades { get; set; }
        public string Lugar_actual { get; set; }
        public string Rol_actual { get; set; }
        public bool Interes_Polaris { get; set; } = false;
    }
}
