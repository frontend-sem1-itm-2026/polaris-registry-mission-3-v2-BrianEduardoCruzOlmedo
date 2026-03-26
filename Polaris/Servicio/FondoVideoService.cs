using Polaris.Data;

namespace Polaris.Servicio
{
    public class FondoVideoService
    {
        public TiposProyectos tiposProyectos { get; set; } = TiposProyectos.PolariX;
        public string linkVideo() => linksVideo[(int)tiposProyectos];

        public event Action OnChange;

        public void UpdateData(TiposProyectos newData)
        {
            tiposProyectos = newData;
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
        

        public List<string> linksVideo { get; set; } = new() {
            "https://www.youtube.com/embed/wnhvanMdx4s?autoplay=1&mute=1&controls=0&loop=1",
            "https://www.youtube.com/embed/nGnX6GkrOgk?autoplay=1&mute=1&controls=0&loop=1",
            "https://www.youtube.com/embed/Jk88_BaEi00?autoplay=1&mute=1&controls=0&loop=1"
        };

    }
}