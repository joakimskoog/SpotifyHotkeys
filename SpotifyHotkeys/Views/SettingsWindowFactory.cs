using SpotifyHotkeys.ViewModels;

namespace SpotifyHotkeys.Views
{
    public class SettingsWindowFactory : IWindowFactory
    {
        public void ShowWindow()
        {
            var view = new SettingsWindow();
            var viewModel = new SettingsViewModel();
            view.DataContext = viewModel;

            view.Show();
        }
    }
}