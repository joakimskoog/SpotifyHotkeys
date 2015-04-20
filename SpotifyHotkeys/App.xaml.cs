using System;
using System.Reflection;
using System.Windows;
using System.Windows.Input;
using Hardcodet.Wpf.TaskbarNotification;
using SpotifyHotkeys.Attributes;
using SpotifyHotkeys.Core;
using SpotifyHotkeys.Hotkeys;
using SpotifyHotkeys.ViewModels;
using SpotifyHotkeys.Views;
using SpotifyWebHelperAPI;

namespace SpotifyHotkeys
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        private ISpotifyActionService _spotifyActionService;
        private IHotKeyManager _hotkeyManager;
        private NotifyIconViewModel _notifyIconViewModel;
        private TaskbarIcon _taskbarIcon;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            try
            {

                var spotifWebHelper = SpotifyWebHelperApi.Create();

                var assembly = typeof(App).Assembly;

                var description = assembly.GetCustomAttribute<AssemblyDescriptionAttribute>();
                var author = assembly.GetCustomAttribute<AssemblyAuthorAttribute>();
                var link = assembly.GetCustomAttribute<AssemblyLinkAttribute>();

                var aboutFactory = new AboutWindowAdapter(author.Author, description.Description,
                    assembly.GetName().Version.ToString(), link.Link);

                AddHotkeys();
                _spotifyActionService = new UnmanagedSpotifyActionService();

                _taskbarIcon = FindResource("NotifyIcon") as TaskbarIcon;
                _notifyIconViewModel = new NotifyIconViewModel(aboutFactory,
                    new SettingsWindowAdapter(_spotifyActionService, _hotkeyManager), spotifWebHelper, "SpotifyHotkeys");
                _taskbarIcon.DataContext = _notifyIconViewModel;
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Failed to start SpotifyHotkeys. Please make sure that Spotify is up and running!\n\n" +
                              "If Spotify is up and running, please report the following stack trace here: " +
                              "https://github.com/joakimskoog/SpotifyHotkeys/issues \n\nStack trace: {0}", ex.StackTrace),"Error");
                Current.Shutdown();
            }
        }

        private void AddHotkeys()
        {
            _hotkeyManager = new HotkeyManager();
            _hotkeyManager.AddHotkey(new HotKey(Key.Right, KeyModifier.Ctrl | KeyModifier.Shift, OnNextTrackHotkeyActivated),
                "NextTrack");
            _hotkeyManager.AddHotkey(new HotKey(Key.Left, KeyModifier.Ctrl | KeyModifier.Shift, OnPreviousTrackHotkeyActivated),
                "PreviousTrack");
            _hotkeyManager.AddHotkey(new HotKey(Key.Space, KeyModifier.Ctrl | KeyModifier.Shift, OnPausePlayHotkeyActivated),
                "PausePlay");
        }

        private void OnPausePlayHotkeyActivated(HotKey hotKey)
        {
            _spotifyActionService.TogglePlay();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
            if (_hotkeyManager != null)
            {
                _hotkeyManager.RemoveAllHotkeys();
            }
        }

        private void OnNextTrackHotkeyActivated(HotKey hotKey)
        {
            _spotifyActionService.NextTrack();
            _notifyIconViewModel.UpdateCurrentInformation();
            _taskbarIcon.ShowBalloonTip("Next track", _notifyIconViewModel.CurrentInformation, BalloonIcon.None);
        }

        private void OnPreviousTrackHotkeyActivated(HotKey hotKey)
        {
            _spotifyActionService.PreviousTrack();
            _notifyIconViewModel.UpdateCurrentInformation();
            _taskbarIcon.ShowBalloonTip("Previous track", _notifyIconViewModel.CurrentInformation, BalloonIcon.None);
        }
    }
}