namespace Examples.TabView.RestaurantMenu
{
    public abstract class RestaurantSectionViewModel : ViewModelBase
    {
        private bool isSelected;
        private string name;
        private string icon;
        private string normalIcon;
        private string selectedIcon;

        public RestaurantSectionViewModel(string name, string normalIcon, string selectedIcon)
        {
            this.name = name;
            this.normalIcon = normalIcon;
            this.selectedIcon = selectedIcon;
            this.icon = this.normalIcon;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
        }

        public string Icon
        {
            get
            {
                return this.icon;
            }
            private set
            {
                if (this.icon != value)
                {
                    this.icon = value;
                    this.OnPropertyChanged();
                }
            }
        }

        public bool IsSelected
        {
            get
            {
                return this.isSelected;
            }
            set
            {
                if (this.isSelected != value)
                {
                    this.isSelected = value;
                    this.OnPropertyChanged();
                    this.OnIsSelectedChanged();
                }
            }
        }
        
        private void OnIsSelectedChanged()
        {
            this.Icon = this.isSelected ? this.selectedIcon : this.normalIcon;
        }
    }
}
