﻿using System.Reflection;
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
        private IHotKeyManager _hotkeyManager;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            /* For now it is sufficient to hard code the hotkeys and have all the logic here.
             * Later on we want to have a UI for changing hotkeys and maybe also some sort of
             * notifications when the track is changed.
             */

            var assembly = typeof (App).Assembly;


            var aboutFactory = new AboutWindowFactory("author", "description", assembly.GetName().Version.ToString());

            AddHotkeys();          
            _spotifyActionService = new UnmanagedSpotifyActionService();

            var notifyIcon = FindResource("NotifyIcon") as TaskbarIcon;
            notifyIcon.DataContext = new NotifyIconViewModel(aboutFactory, new SettingsWindowFactory());
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
            _hotkeyManager.RemoveAllHotkeys();
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