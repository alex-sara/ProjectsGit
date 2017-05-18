using System;
using System.ComponentModel;
using System.Linq;

namespace Examples.ListView.Selection
{
    public class BusinessItem : INotifyPropertyChanged
    {
        public string Date { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        private bool isFavourite = false;

        public bool IsFavourite
        {
            get
            {
                return this.isFavourite;
            }
            set
            {
                if (this.isFavourite != value)
                {
                    this.isFavourite = value;
                    this.OnPropertyChanged("IsFavourite");
                }
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}