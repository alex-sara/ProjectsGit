using System.ComponentModel;

namespace Examples.TabView.RestaurantMenu
{
    public class RestaurantMenuItem : INotifyPropertyChanged
    {
        private string name;
        private string image;
        private bool isSaved;

        public RestaurantMenuItem(string name, string image)
        {
            this.name = name;
            this.image = image;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public string Name
        {
            get
            {
                return this.name;
            }
        }

        public string Image
        {
            get
            {
                return this.image;
            }
        }

        public bool IsSaved
        {
            get
            {
                return this.isSaved;
            }
            set
            {
                if (this.isSaved != value)
                {
                    this.isSaved = value;
                    this.RaisePropertyChanged("IsSaved");
                }
            }
        }

        private void RaisePropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
