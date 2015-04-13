using System.Collections.Concurrent;
using System.Collections.Generic;

namespace SpotifyHotkeys.Hotkeys
{
    public class HotkeyManager : IHotKeyManager
    {
        private readonly IDictionary<string, HotKey> _hotkeys;

        public HotkeyManager()
        {
            _hotkeys = new ConcurrentDictionary<string, HotKey>();
        }
 
        public void AddHotkey(HotKey hotkey, string name)
        {
            RemoveHotkey(name);
            _hotkeys.Add(name, hotkey);
        }

        public void RemoveHotkey(string name)
        {
            if (_hotkeys.ContainsKey(name))
            {
                var hotkeyToRemove = _hotkeys[name];
                hotkeyToRemove.Dispose();
                _hotkeys.Remove(name);
            }
        }

        public void RemoveAllHotkeys()
        {
            foreach (var name in _hotkeys.Keys)
            {
                RemoveHotkey(name);
            }
        }
    }
}