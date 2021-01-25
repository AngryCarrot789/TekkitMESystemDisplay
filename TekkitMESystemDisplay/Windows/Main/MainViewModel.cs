using TekkitMESystemDisplay.Windows.Logger;
using TheRFramework.Utilities;

namespace TekkitMESystemDisplay.Windows.Main
{
    public class MainViewModel : BaseViewModel
    {
        public ThemesViewModel Themes { get; set; }
        public LoggerViewModel Logs { get; set; }

        // TekkitMESystemDisplay

        public MainViewModel()
        {
            Themes = new ThemesViewModel();
            Logs = new LoggerViewModel();
        }
    }
}
