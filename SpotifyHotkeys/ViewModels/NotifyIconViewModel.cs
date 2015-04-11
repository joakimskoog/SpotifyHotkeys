using System.Windows;
using System.Windows.Input;

namespace SpotifyHotkeys.ViewModels
{
    public class NotifyIconViewModel
    {
        #region Commands

        private ICommand _exitCommand;
        public ICommand ExitCommand
        {
            get { return _exitCommand ?? (_exitCommand = new RelayCommand(ExecuteExit)); }
        }

        #endregion

        #region Command methods

        private void ExecuteExit(object param)
        {
            Application.Current.Shutdown();
        }

        #endregion
    }
}