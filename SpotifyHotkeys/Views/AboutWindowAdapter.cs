using System;
using SpotifyHotkeys.ViewModels;

namespace SpotifyHotkeys.Views
{
    public class AboutWindowAdapter : IWindow
    {
        private readonly string _author;
        private readonly string _description;
        private readonly string _version;
        private readonly string _link;

        public AboutWindowAdapter(string author, string description, string version, string link)
        {
            if (author == null) throw new ArgumentNullException("author");
            if (description == null) throw new ArgumentNullException("description");
            if (version == null) throw new ArgumentNullException("version");
            if (link == null) throw new ArgumentNullException("link");
            _author = author;
            _description = description;
            _version = version;
            _link = link;
        }

        public void Show()
        {
            var view = new AboutWindow();
            var viewModel = new AboutViewModel(_author, _description, _version, _link);
            view.DataContext = viewModel;

            view.Show();
        }
    }
}