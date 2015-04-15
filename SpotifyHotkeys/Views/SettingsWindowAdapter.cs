using SpotifyHotkeys.ViewModels;

namespace SpotifyHotkeys.Views
{
    public class SettingsWindowAdapter : IWindow
    {
        public void Show()
        {
            var view = new SettingsWindow();
            var viewModel = new SettingsViewModel();
            view.DataContext = viewModel;

            view.Show();
        }
    }
}