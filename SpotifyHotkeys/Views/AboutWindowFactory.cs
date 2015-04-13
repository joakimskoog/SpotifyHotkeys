using System;
using SpotifyHotkeys.ViewModels;

namespace SpotifyHotkeys.Views
{
    public class AboutWindowFactory : IWindowFactory
    {
        private readonly string _author;
        private readonly string _description;
        private readonly string _version;

        public AboutWindowFactory(string author, string description, string version)
        {
            if (author == null) throw new ArgumentNullException("author");
            if (description == null) throw new ArgumentNullException("description");
            if (version == null) throw new ArgumentNullException("version");
            _author = author;
            _description = description;
            _version = version;
        }

        public void ShowWindow()
        {
            var view = new AboutWindow();
            var viewModel = new AboutViewModel(_author, _description, _version);
            view.DataContext = viewModel;

            view.Show();
        }
    }
}