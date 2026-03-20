using System.ComponentModel.DataAnnotations;

namespace Polaris.Data
{
    public enum TiposHabilidades
    {

        [Display(Name = "Programación")]
        Programacion,
        [Display(Name = "Electrónica")]
        Electronica,
        [Display(Name = "Diseño CAD")]
        DiseñoCAD,
        [Display(Name = "Investigación")]
        Investigacion,
        [Display(Name = "Fivulgación")]
        Divulgacion,
    }
}
