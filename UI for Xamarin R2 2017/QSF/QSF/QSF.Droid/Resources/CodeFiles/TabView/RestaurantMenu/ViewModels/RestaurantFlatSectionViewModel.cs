using System.Collections.ObjectModel;

namespace Examples.TabView.RestaurantMenu
{
    public class RestaurantFlatSectionViewModel : RestaurantSectionViewModel
    {
        private ObservableCollection<RestaurantMenuItem> items;

        public RestaurantFlatSectionViewModel(string name, string normalIcon, string selectedIcon)
            : base(name, normalIcon, selectedIcon)
        {
            this.items = new ObservableCollection<RestaurantMenuItem>();
        }

        public ObservableCollection<RestaurantMenuItem> Items
        {
            get
            {
                return this.items;
            }
        }
    }
}
