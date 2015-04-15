using System;

namespace SpotifyHotkeys.Attributes
{
    public sealed class AssemblyLinkAttribute : Attribute
    {
        public string Link { get; private set; }

        public AssemblyLinkAttribute(string link)
        {
            if (link == null) throw new ArgumentNullException("link");
            Link = link;
        }
    }
}