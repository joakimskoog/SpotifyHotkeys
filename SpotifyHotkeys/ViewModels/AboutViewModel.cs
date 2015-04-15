using System;

namespace SpotifyHotkeys.ViewModels
{
    public class AboutViewModel
    {
        private readonly string _author;
        private readonly string _description;
        private readonly string _version;
        private string _link;

        public string Author { get { return _author; } }
        public string Description { get { return _description; } }
        public string Version { get { return _version; } }
        public string Link { get { return _link; } }

        public AboutViewModel(string author, string description, string version, string link)
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
    }
}