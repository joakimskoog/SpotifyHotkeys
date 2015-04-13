namespace SpotifyHotkeys.Hotkeys
{
    public interface IHotKeyManager
    {
        void AddHotkey(HotKey hotkey, string name);

        void RemoveHotkey(string name);

        void RemoveAllHotkeys();
    }
}