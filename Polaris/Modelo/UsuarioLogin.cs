using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Polaris.Modelo
{
    public class UsuarioLogin
    {

        [DisplayName("Correo Electronico")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "El correo es obligatorio")]
        [EmailAddress(ErrorMessage = "El formato del correo no es válido")]
        public string Email { get; set; }

        [DisplayName("Contraseña")]
        [Required(ErrorMessage = "La contraseña es obligatoria")]

        [MinLength(8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
