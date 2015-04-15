using System;
using SpotifyHotkeys.Core;
using SpotifyHotkeys.Hotkeys;
using SpotifyHotkeys.ViewModels;

namespace SpotifyHotkeys.Views
{
    public class SettingsWindowAdapter : IWindow
    {
        private readonly ISpotifyActionService _spotifyActionService;
        private readonly IHotKeyManager _hotkeyManager;


        public SettingsWindowAdapter(ISpotifyActionService spotifyActionService, IHotKeyManager hotkeyManager)
        {
            if (spotifyActionService == null) throw new ArgumentNullException("spotifyActionService");
            if (hotkeyManager == null) throw new ArgumentNullException("hotkeyManager");
            _spotifyActionService = spotifyActionService;
            _hotkeyManager = hotkeyManager;
        }

        public void Show()
        {
            var view = new SettingsWindow();
            var viewModel = new SettingsViewModel(_spotifyActionService, _hotkeyManager);
            view.DataContext = viewModel;

            view.Show();
        }
    }
}