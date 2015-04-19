using System;
using SpotifyHotkeys.Core;
using SpotifyHotkeys.Hotkeys;

namespace SpotifyHotkeys.ViewModels
{
    public class SettingsViewModel : ViewModelBase
    {
        private readonly ISpotifyActionService _spotifyActionService;
        private readonly IHotKeyManager _hotkeyManager;

        public SettingsViewModel(ISpotifyActionService spotifyActionService, IHotKeyManager hotkeyManager)
        {
            if (spotifyActionService == null) throw new ArgumentNullException("spotifyActionService");
            if (hotkeyManager == null) throw new ArgumentNullException("hotkeyManager");
            _spotifyActionService = spotifyActionService;
            _hotkeyManager = hotkeyManager;
        }
    }
}