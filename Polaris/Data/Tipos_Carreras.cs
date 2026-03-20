using System.ComponentModel.DataAnnotations;

namespace Polaris.Data
{
    
    public enum Tipos_Carreras
    {
        [Display(Name = "Ingieneria en Sistemas Computacionales")]
        ISC,
        [Display(Name = "Ingieneria Mecatronica")]
        IM,
        [Display(Name = "Ingieneria Gestion Empresarial")]
        IGE,
        [Display(Name = "Ingieneria Electronica")]
        IE,
        [Display(Name = "Ingieneria Electromecanica")]
        IEM,
        [Display(Name = "Ingieneria Civil")]
        IC,
        [Display(Name = "Ingieneria Ambiental")]
        IA,
        [Display(Name = "Ingieneria Quimica")]
        IQ,
        [Display(Name = "Licenciatura Ambiental")]
        LA,
        [Display(Name = "Licenciatura en Contabilidad")]
        LC,
        [Display(Name = "Maestria Administracion Industrial")]
        MAI,
        [Display(Name = "Maestria en SemiConductores")]
        MSC,
    }
}
