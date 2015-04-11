using System.Windows;
using System.Windows.Input;
using SpotifyHotkeys.Core;
using SpotifyHotkeys.Hotkeys;

namespace SpotifyHotkeys
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        private ISpotifyActionService _spotifyActionService;
        private HotKey _nextTrackHotkey;
        private HotKey _previousTrackHotkey;

        private void App_OnStartup(object sender, StartupEventArgs e)
        {
            /* For now it is sufficient to hard code the hotkeys and have all the logic here.
             * Later on we want to have a UI for changing hotkeys and maybe also some sort of
             * notifications when the track is changed.
             */
            
            _spotifyActionService = new UnmanagedSpotifyActionService();
            _nextTrackHotkey = new HotKey(Key.Right, KeyModifier.Ctrl | KeyModifier.Shift, OnNextTrackHotkeyActivated);
            _previousTrackHotkey = new HotKey(Key.Left, KeyModifier.Ctrl | KeyModifier.Shift, OnPreviousTrackHotkeyActivated);
        }

        private void OnNextTrackHotkeyActivated(HotKey hotKey)
        {
            _spotifyActionService.NextTrack();
        }

        private void OnPreviousTrackHotkeyActivated(HotKey hotKey)
        {
            _spotifyActionService.PreviousTrack();
        }

        private void App_OnExit(object sender, ExitEventArgs e)
        {
            _nextTrackHotkey.Dispose();
            _previousTrackHotkey.Dispose();
        }
    }
}