using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Runtime.Serialization;

namespace Polaris.Data
{
    public enum TiposProyectos
    {
        [Display(Name = "PolariX")]
        PolariX,
        [Display(Name = "Mentes en Órbita")]
        Mentes_en_Orbita,
        [Display(Name = "Hydronautas")]
        Hydronautas
    }
    public static class EnumExtensions
    {
        public static string GetDisplayName(this Enum value)
        {
            return value.GetType()
                .GetMember(value.ToString())
                .FirstOrDefault()?
                .GetCustomAttribute<DisplayAttribute>()?
                .GetName() ?? value.ToString();
        }
    }
}
