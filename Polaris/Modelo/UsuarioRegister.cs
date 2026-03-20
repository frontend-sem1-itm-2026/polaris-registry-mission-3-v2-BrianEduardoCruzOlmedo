using Microsoft.AspNetCore.Components.Forms;
using Polaris.Data;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Polaris.Modelo
{
    public class UsuarioRegister
    {

        [DisplayName("Foto de Perfil")]
        public byte[]? Foto { get; set; }
        public async Task HandleFileSelection(IBrowserFile file)
        {
            var buffer = new byte[file.Size];
            using (var stream = file.OpenReadStream(maxAllowedSize: 1024 * 1024 * 5)) 
            {
                await stream.ReadAsync(buffer);
            }
            Foto = buffer;
        }
        public string ImagenSrc => Foto != null
            ? $"data:image/png;base64,{Convert.ToBase64String(Foto)}"
            : "img/default-profile.png";
        [DisplayName("Nombre Completo")]
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [MinLength(10, ErrorMessage = "El nombre debe tener al menos 10 caracteres")]
        public string Name { get; set; } = "";

        [DisplayName("Correo Electronico")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "El correo es obligatorio")]
        [EmailAddress(ErrorMessage = "El formato del Correo no es válido")]

        public string Email { get; set; } = "";
        [DisplayName("Contraseña")]
        [Required(ErrorMessage = "La contraseña es obligatoria")]

        [MinLength(8, ErrorMessage = "Debe de ser mas de 8 caracteres")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=(?:.*\d){2,})(?=.*[#$%^&*()_+\-=\[\]{};':""\\|,.<>\/?!]).{8,}$",
            ErrorMessage = "La contraseña debe tener al menos: 1 mayúscula, 1 minúscula, 2 números y un carácter especial.")]
        public string Password { get; set; } = "";

        [DisplayName("Repite la Contraseña")]
        [NotMapped]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Debes repetir la contraseña")]
        [Compare("Password", ErrorMessage = "Las contraseñas no coinciden")]
        [MinLength(8, ErrorMessage = "Debe de ser mas de 8 caracteres")]
        public string RPassword { get; set; } = "";

        [DisplayName("Proyecto de Interes")]
        [Required(ErrorMessage = "Por favor, selecciona un proyecto")]
        public int Proyecto { get; set; } = 0;
       
        
        [DisplayName("Numero Telefonico")]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "El Numero de telefono es obligatorio")]
        [RegularExpression(@"^\+?\d{10,11}$", ErrorMessage = "El formato del teléfono no es válido")]

        public string Telefono { get; set; } = "";
        [DisplayName("Fecha de nacimiento")]
        [DataType(DataType.Date)]
        [Range(typeof(DateTime), "1/1/1925", "12/31/2015",
            ErrorMessage = "La fecha debe estar entre {1} y {2}")]
        public DateOnly FechaNac { get; set; }


        [DisplayName("Nombre De Instituto")]
        [Required(ErrorMessage = "Por favor, selecciona un Instituto")]
        public string Instituto { get; set; }

        [DisplayName("Nombre de Carrera")]
        [Required(ErrorMessage = "Por favor, selecciona una carrera")]
        public int Carrera { get; set; }

        [DisplayName("# Semestre")]
        [Required(ErrorMessage = "Por favor, selecciona un semestre")]
        [RegularExpression(@"^\+?\d{1,12}$", ErrorMessage = "solo se permite de semestre 1-12")]

        public int Semestre { get; set; }



        [DisplayName("Generacion de Polaris")]
        [Required(ErrorMessage = "Por favor, selecciona una generacion")]
        public int GenPolaris { get; set; }

        [DisplayName("Habilidades")]
        [Required(ErrorMessage = "Por favor, selecciona un Habilidad por lo menos")]
        public TiposHabilidades[] Habilidades { get; set; } 
        [DisplayName("Lugar de estudio o trabajo actual")]
        public string Lugar_actual { get; set; } = "Sin Especificar";
        [DisplayName("Rol actual")]
        public string Rol_actual { get; set; } = "Sin Especificar";
        [DisplayName("Posee interes en colaborar con Polaris")]
        public bool Interes_Polaris { get; set; } = false;

    }
}
