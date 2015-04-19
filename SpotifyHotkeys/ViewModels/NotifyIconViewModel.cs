using System;
using System.Windows;
using System.Windows.Input;
using SpotifyHotkeys.Views;
using SpotifyWebHelperAPI;

namespace SpotifyHotkeys.ViewModels
{
    public class NotifyIconViewModel : ViewModelBase
    {
        private readonly IWindow _aboutWindow;
        private readonly IWindow _settingsWindow;
        private readonly ISpotifyWebHelperCommunicationService _spotifyWebHelper;

        private string _currentInformation;
        public string CurrentInformation
        {
            get
            {
                return _currentInformation; 
                
            }
            set
            {
                _currentInformation = value;
                OnPropertyChanged("CurrentInformation");
            }
        }

        #region Commands

        private ICommand _exitCommand;
        public ICommand ExitCommand
        {
            get { return _exitCommand ?? (_exitCommand = new RelayCommand(ExecuteExit)); }
        }

        private ICommand _showAboutWindowCommand;
        public ICommand ShowAboutWindowCommand
        {
            get { return _showAboutWindowCommand ?? (_showAboutWindowCommand = new RelayCommand(ExecuteOpenAboutWindow)); }
        }

        private ICommand _showSettingsWindowCommand;
        public ICommand ShowSettingsWindowCommand
        {
            get
            {
                return _showSettingsWindowCommand ?? (_showSettingsWindowCommand = new RelayCommand(ExecuteOpenSettingsWindow));
            }
        }

        #endregion

        public NotifyIconViewModel(IWindow aboutWindow, IWindow settingsWindow, ISpotifyWebHelperCommunicationService spotifyWebHelper, string currentInformation)
        {
            if (aboutWindow == null) throw new ArgumentNullException("aboutWindow");
            if (settingsWindow == null) throw new ArgumentNullException("settingsWindow");
            if (spotifyWebHelper == null) throw new ArgumentNullException("spotifyWebHelper");
            if (currentInformation == null) throw new ArgumentNullException("currentInformation");
            _aboutWindow = aboutWindow;
            _settingsWindow = settingsWindow;
            _spotifyWebHelper = spotifyWebHelper;
            _currentInformation = currentInformation;
        }

        public void UpdateCurrentInformation()
        {
            try
            {
                var currentStatus = _spotifyWebHelper.GetStatus();

                var song = currentStatus.Track.TrackResource.Name;
                var performer = currentStatus.Track.ArtistResource.Name;

                CurrentInformation = string.Format("{0} by {1}", song, performer);
            }
            catch (Exception)
            {
                CurrentInformation = "Error retrieving status";
            }
        }

        #region Command methods

        private void ExecuteExit(object param)
        {
            Application.Current.Shutdown();
        }

        private void ExecuteOpenSettingsWindow(object obj)
        {
            _settingsWindow.Show();
        }

        private void ExecuteOpenAboutWindow(object obj)
        {
            _aboutWindow.Show();
        }

        #endregion
    }
}