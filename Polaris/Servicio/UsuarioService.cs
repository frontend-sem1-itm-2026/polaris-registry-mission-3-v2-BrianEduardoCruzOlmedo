using BlazorBootstrap;
using Polaris.Data;
using Polaris.Modelo;

namespace Polaris.Servicio
{
    public class UsuarioService
    {
        private readonly HttpClient _http; 
        private bool _estaInicializado = false;
        public Usuario? Usuario {  get; private set; } = null;
        public UsuarioService(HttpClient http)
        {
            _http = http;
        }
        public async Task Inicializar()
        {
            if (_estaInicializado) return;

            usuarios = new List<Usuario> {
                new Usuario{
                    Id = "1", Proyecto = (int)TiposProyectos.Mentes_en_Orbita,
                    Name = "Federico Guzman", Email="fede@mail.com",
                    Password = "Fm1$123456",
                    Carrera = 2,
                    FechaNac = new DateOnly(2000, 12, 10),
                    GenPolaris = 2,
                    Instituto = "ITM",
                    Interes_Polaris = true,
                    Semestre = 2,
                },
                    
                new Usuario{
                    Id = "2", Proyecto = (int)TiposProyectos.PolariX,
                    Name = "Antonio Guzman", Email="Santi@mail.com",
                    Password = "Am2$567456",
                    Carrera = 2,
                    FechaNac = new DateOnly(2000, 12, 10),
                    GenPolaris = 2,
                    Instituto = "ITM",
                    Interes_Polaris = true,
                    Semestre = 2, },
                new Usuario{
                    Id = "3", Proyecto = (int)TiposProyectos.Mentes_en_Orbita,
                    Name = "Chalino Sanchez", Email="Chalino@mail.com",
                    Password = "Cc3$890456",
                    Carrera = 2,
                    FechaNac = new DateOnly(2000, 12, 10),
                    GenPolaris = 2,
                    Instituto = "ITM",
                    Interes_Polaris = true,
                    Semestre = 2, },
                new Usuario{
                    Id = "A", Proyecto = (int)TiposProyectos.Hydronautas,
                    Name = "Vicente Fernandez", Email="Chente@mail.com",
                    Password = "VnA$234456",
                    Carrera = 2,
                    FechaNac = new DateOnly(2000, 12, 10),
                    GenPolaris = 2,
                    Instituto = "ITM",
                    Interes_Polaris = true,
                    Semestre = 2, },
            };
            await Task.Delay(200);
            _estaInicializado = true;
        }
        public List<Usuario> usuarios { get; set; } = new();
        public async Task<(string title, string msj, bool state)> RegistrarUsuario(Usuario usuario)
        {
            await Inicializar();
            if (usuarios.Any(u=> u.Email == usuario.Email))
            {
                return ("Registro no Realizado",
                    @"Este Usuario ya existe prueba iniciando sesion",
                    false);
            }
            else
            {
                usuarios.Add(usuario);
                return ("Registro Existoso", 
                    @"Ahora intenta iniciando Sesion ", 
                    true);
            }

        }
        public async Task<bool> ExisteCorreo(string correo)
        {
            await Inicializar();
            return usuarios.Any(u => u.Email == correo);
        }
        public async Task<(string title, string msj, bool state)> IngresarUsuario(Usuario usuario)
        {
            await Inicializar();
            if (usuarios.Any(u => u.Email == usuario.Email))
            {
                var user = usuarios.FirstOrDefault(u =>
                    u.Password == usuario.Password &&
                        u.Email == usuario.Email);
                if (user != null)
                {
                    Usuario = user;
                    return ($"Hola Bienvenido {user.Name}", @"Vaya ya te extrañabamos ;)",
                    true);

                }
                else
                {
                    return ("Contraseña Incorrecta", @"Te sugiero en ir caminar y relajarte",
                    false);
                }
            }
            else
            {
                return ("Ingreso sin exito", @"Este usuario no existe 
                                                        Prueba mejor registrandote",
                    false);
            }

        }
        // UPDATE (Actualizar)
        public async Task<(string title, string msj, bool state)> ActualizarUsuario(Usuario usuarioModificado)
        {
            await Inicializar();

            // Buscamos al usuario por su ID
            var usuarioExistente = usuarios.FirstOrDefault(u => u.Id == usuarioModificado.Id);

            if (usuarioExistente != null)
            {
                // Actualizamos los datos mínimos que pide la rúbrica
                usuarioExistente.Name = usuarioModificado.Name;
                usuarioExistente.Email = usuarioModificado.Email;
                // Puedes agregar más campos aquí si lo necesitan (como Rol_actual)

                return ("Actualización Exitosa", "Los datos del miembro han sido modificados.", true);
            }
            else
            {
                return ("Error al actualizar", "No se encontró el usuario especificado en el sistema.", false);
            }
        }

        // DELETE (Eliminar)
        public async Task<(string title, string msj, bool state)> EliminarUsuario(string id)
        {
            await Inicializar();

            // Buscamos al usuario por su ID
            var usuario = usuarios.FirstOrDefault(u => u.Id == id);

            if (usuario != null)
            {
                usuarios.Remove(usuario);
                return ("Eliminación Exitosa", "El miembro ha sido borrado del sistema.", true);
            }
            else
            {
                return ("Error al eliminar", "No se encontró el usuario a eliminar.", false);
            }
        }
    }
}
