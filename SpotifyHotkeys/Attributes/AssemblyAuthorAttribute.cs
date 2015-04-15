using System;

namespace SpotifyHotkeys.Attributes
{
    public sealed class AssemblyAuthorAttribute : Attribute
    {
        public string Author { get; private set; }

        public AssemblyAuthorAttribute(string author)
        {
            if (author == null) throw new ArgumentNullException("author");
            Author = author;
        }
    }
}