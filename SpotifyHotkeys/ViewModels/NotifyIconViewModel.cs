using System;
using System.Windows;
using System.Windows.Input;
using SpotifyHotkeys.Views;

namespace SpotifyHotkeys.ViewModels
{
    public class NotifyIconViewModel
    {
        private readonly IWindow _aboutWindow;
        private readonly IWindow _settingsWindow;

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

        public NotifyIconViewModel(IWindow aboutWindow, IWindow settingsWindow)
        {
            if (aboutWindow == null) throw new ArgumentNullException("aboutWindow");
            if (settingsWindow == null) throw new ArgumentNullException("settingsWindow");
            _aboutWindow = aboutWindow;
            _settingsWindow = settingsWindow;
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