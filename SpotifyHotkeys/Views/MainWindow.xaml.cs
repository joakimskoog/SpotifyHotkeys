using System.Windows;
using SpotifyHotkeys.Core;

namespace SpotifyHotkeys.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ISpotifyActionService _spotifyService = new UnmanagedSpotifyActionService();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            _spotifyService.PreviousTrack();
        }

        private void NextClick(object sender, RoutedEventArgs e)
        {
            _spotifyService.NextTrack();
        }
    }
}
