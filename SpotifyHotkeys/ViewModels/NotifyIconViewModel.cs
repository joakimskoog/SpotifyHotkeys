using System;
using System.Windows;
using System.Windows.Input;
using SpotifyHotkeys.Views;

namespace SpotifyHotkeys.ViewModels
{
    public class NotifyIconViewModel
    {
        private readonly IWindowFactory _aboutWindowFactory;
        private readonly IWindowFactory _settingsWindowFactory;

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

        private void ExecuteOpenSettingsWindow(object obj)
        {
            _settingsWindowFactory.ShowWindow();
        }

        private void ExecuteOpenAboutWindow(object obj)
        {
            _aboutWindowFactory.ShowWindow();
        }

        #endregion

        public NotifyIconViewModel(IWindowFactory aboutWindowFactory, IWindowFactory settingsWindowFactory)
        {
            if (aboutWindowFactory == null) throw new ArgumentNullException("aboutWindowFactory");
            if (settingsWindowFactory == null) throw new ArgumentNullException("settingsWindowFactory");
            _aboutWindowFactory = aboutWindowFactory;
            _settingsWindowFactory = settingsWindowFactory;
        }

        #region Command methods

        private void ExecuteExit(object param)
        {
            Application.Current.Shutdown();
        }

        #endregion
    }
}