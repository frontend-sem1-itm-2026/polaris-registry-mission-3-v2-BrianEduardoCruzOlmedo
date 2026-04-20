namespace Polaris.Constants
{
    public static class EstadoEvento
    {
        public const string RegistroNoIniciado = "Planeacion";
        public const string RegistroAbierto = "Registro Abierto";
        public const string RegistroCerrado = "Registro Cerrado";
        public const string EnCurso = "En Curso";
        public const string Finalizado = "Finalizado";

        public static string Estado(DateTime fechaInicioRegistro, DateTime? fechaFinRegistro, DateTime fechaInicioEvento, DateTime? fechaFinEvento)
        {
            DateTime now = DateTime.Now;
            if (now < fechaInicioRegistro)
                return RegistroNoIniciado;
         
            else if (fechaInicioRegistro <=now && (fechaFinRegistro == null || now < fechaFinRegistro ))
                return RegistroAbierto;
            else if (fechaFinRegistro <= now  && now < fechaInicioEvento)
                return RegistroCerrado;
            else if (fechaInicioEvento <= now   && (fechaFinEvento == null || now <  fechaFinEvento))
                return EnCurso;
            else
                return Finalizado;
        }
        public static bool isRegistroAbierto(DateTime fechaInicioRegistro, DateTime? fechaFinRegistro)
        {
            DateTime now = DateTime.Now;
            if(fechaFinRegistro == null) return fechaInicioRegistro <= now; 
            return fechaInicioRegistro <= now && now < fechaFinRegistro;
        }
    }
}
