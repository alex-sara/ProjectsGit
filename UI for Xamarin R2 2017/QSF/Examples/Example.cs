using System;
using Xamarin.Forms;

namespace Examples
{
    public class Example
    {
        public string Title { get; set; }
        public string ExcludeFrom { get; set; }
        public string UserFriendlyTitle { get; set; }
        public string PageName { get; set; }
        public bool IsFeatured { get; set; }        
        private string image;
        public string Image
        {
            get
            {
                return this.image;
            }
                
            set
            {
                this.image = value;
                this.ImageSourceUri = ImageSource.FromFile(value);
            }
        }
        public ImageSource ImageSourceUri { get; set; }
        public string Control { get; set; }
        public string Description { get; set; }
    }
}
