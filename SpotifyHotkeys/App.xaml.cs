using System.Windows;
using System.Windows.Input;
using Hardcodet.Wpf.TaskbarNotification;
using SpotifyHotkeys.Core;
using SpotifyHotkeys.Hotkeys;
using SpotifyHotkeys.ViewModels;
using SpotifyHotkeys.Views;

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

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            /* For now it is sufficient to hard code the hotkeys and have all the logic here.
             * Later on we want to have a UI for changing hotkeys and maybe also some sort of
             * notifications when the track is changed.
             */

            _spotifyActionService = new UnmanagedSpotifyActionService();
            _nextTrackHotkey = new HotKey(Key.Right, KeyModifier.Ctrl | KeyModifier.Shift, OnNextTrackHotkeyActivated);
            _previousTrackHotkey = new HotKey(Key.Left, KeyModifier.Ctrl | KeyModifier.Shift, OnPreviousTrackHotkeyActivated);

            var notifyIcon = FindResource("NotifyIcon") as TaskbarIcon;
            notifyIcon.DataContext = new NotifyIconViewModel();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
            _nextTrackHotkey.Dispose();
            _previousTrackHotkey.Dispose();
        }

        private void OnNextTrackHotkeyActivated(HotKey hotKey)
        {
            _spotifyActionService.NextTrack();
        }

        private void OnPreviousTrackHotkeyActivated(HotKey hotKey)
        {
            _spotifyActionService.PreviousTrack();
        }
    }
}