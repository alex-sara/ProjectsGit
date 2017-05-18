using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Examples.AutoComplete.Tokens
{
    public class ImageInfo
    {
        private static char[] separators = new char[] { ' ' };

        public ImageInfo(string fileName, string description)
        {
            this.ImageFileName = fileName;

            string[] tokensArray = description.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            this.ImageTags = new HashSet<string>(tokensArray);
        }

        public string ImageFileName
        {
            get;
            private set;
        }

        public HashSet<string> ImageTags
        {
            get;
            private set;
        }
    }
}
