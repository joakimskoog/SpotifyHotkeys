namespace SpotifyHotkeys.Core
{
    /// <summary>
    /// Service that is responsible for performing various actions on the Spotify client.
    /// </summary>
    public interface ISpotifyActionService
    {
        /// <summary>
        /// Either starts playing a track or pauses the currently playing track.
        /// </summary>
        void TogglePlay();

        /// <summary>
        /// Mutes Spotify.
        /// </summary>
        void Mute();

        /// <summary>
        /// Increases the volume of Spotify.
        /// </summary>
        void IncreaseVolume();

        /// <summary>
        /// Decreases the volume of Spotify.
        /// </summary>
        void DecreaseVolume();

        /// <summary>
        /// Stops the track playing.
        /// </summary>
        void Stop();

        /// <summary>
        /// Changes to the next track.
        /// </summary>
        void NextTrack();

        /// <summary>
        /// Changes to the previous track.
        /// </summary>
        void PreviousTrack();
    }
}