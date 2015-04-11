using System;
using System.Runtime.InteropServices;

namespace SpotifyHotkeys.Core
{
    public class UnmanagedSpotifyActionService : ISpotifyActionService
    {
        #region Unmanaged

        private const uint WM_APPCOMMAND = 0x0319;

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        internal static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll", SetLastError = true)]
        internal static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        private IntPtr _spotifyWindowPointer;
        private IntPtr SpotifyWindowPointer
        {
            get
            {
                if (_spotifyWindowPointer == IntPtr.Zero)
                {
                    _spotifyWindowPointer = FindWindow("SpotifyMainWindow", null);
                }

                return _spotifyWindowPointer;
            }
        }

        #endregion

        public void TogglePlay()
        {
            SendMessage(SpotifyAction.PlayPause);
        }

        public void Mute()
        {
            SendMessage(SpotifyAction.Mute);
        }

        public void IncreaseVolume()
        {
            SendMessage(SpotifyAction.VolumeUp);
        }

        public void DecreaseVolume()
        {
            SendMessage(SpotifyAction.VolumeDown);
        }

        public void Stop()
        {
            SendMessage(SpotifyAction.Stop);
        }

        public void NextTrack()
        {
            SendMessage(SpotifyAction.NextTrack);
        }

        public void PreviousTrack()
        {
            SendMessage(SpotifyAction.PreviousTrack);
        }

        private void SendMessage(SpotifyAction action)
        {
            SendMessage(SpotifyWindowPointer, WM_APPCOMMAND, IntPtr.Zero, new IntPtr((long)action));
        }
    }

    internal enum SpotifyAction : long
    {
        PlayPause = 917504,
        Mute = 524288,
        VolumeDown = 589824,
        VolumeUp = 655360,
        Stop = 851968,
        PreviousTrack = 786432,
        NextTrack = 720896
    }
}