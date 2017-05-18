using System.ComponentModel;
using System.Linq;

namespace Examples.TabView.RestaurantMenu
{
    public class RestaurantViewModel
    {
        private static string exploreSectionName = "Explore";
        private static string savedSectionName = "Saved";
        private static string shoppingListSectionName = "Shopping list";

        public RestaurantViewModel()
        {
            this.Explore = new RestaurantExploreSectionViewModel(exploreSectionName, "tabView_Restaurant_Explore.png", "tabView_Restaurant_Explore_Selected.png");
            this.Saved = new RestaurantFlatSectionViewModel(savedSectionName, "tabView_Restaurant_Saved.png", "tabView_Restaurant_Saved_Selected.png");
            this.ShoppingList = new RestaurantFlatSectionViewModel(shoppingListSectionName, "tabView_Restaurant_ShoppingList.png", "tabView_Restaurant_ShoppingList_Selected.png");

            this.AttachIsSavedListeners();

            this.Explore.BreakfastItems[1].IsSaved = true;
            this.Explore.MainItems[0].IsSaved = true;
            this.Explore.DessertItems[0].IsSaved = true;

            this.ShoppingList.Items.Add(this.Explore.BreakfastItems[1]);
            this.ShoppingList.Items.Add(this.Explore.MainItems[1]);
        }

        public RestaurantExploreSectionViewModel Explore { get; set; }        
        public RestaurantFlatSectionViewModel Saved { get; set; }
        public RestaurantFlatSectionViewModel ShoppingList { get; set; }

        private void AttachIsSavedListeners()
        {
            foreach (RestaurantMenuItem item in this.Explore.BreakfastItems)
            {
                item.PropertyChanged += this.Item_PropertyChanged;
            }

            foreach (RestaurantMenuItem item in this.Explore.MainItems)
            {
                item.PropertyChanged += this.Item_PropertyChanged;
            }

            foreach (RestaurantMenuItem item in this.Explore.DessertItems)
            {
                item.PropertyChanged += this.Item_PropertyChanged;
            }

            foreach (RestaurantMenuItem item in this.Explore.DrinksItems)
            {
                item.PropertyChanged += this.Item_PropertyChanged;
            }
        }

        private void Item_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(RestaurantMenuItem.IsSaved))
            {
                RestaurantMenuItem item = (RestaurantMenuItem)sender;
                if (item.IsSaved)
                {
                    this.Saved.Items.Add(item);
                }
                else
                {
                    this.Saved.Items.Remove(item);
                }
            }
        }
    }
}
