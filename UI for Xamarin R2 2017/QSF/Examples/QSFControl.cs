using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Examples
{
    public class QSFControl
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ExcludeFrom { get; set; }
        public List<Example> Examples { get; set; }
        public bool IsExcludedFromCurrentOS { get; set; }

        public ImageSource ImageSourceUri { get; set; }

        public QSFControl()
        {
            this.Examples = new List<Example>();
        }
    }
}