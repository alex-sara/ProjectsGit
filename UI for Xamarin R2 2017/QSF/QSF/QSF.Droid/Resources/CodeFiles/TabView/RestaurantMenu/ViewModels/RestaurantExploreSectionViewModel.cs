using System.Collections.Generic;

namespace Examples.TabView.RestaurantMenu
{
    public class RestaurantExploreSectionViewModel : RestaurantSectionViewModel
    {
        private List<RestaurantMenuItem> breakfastItems;
        private List<RestaurantMenuItem> mainItems;
        private List<RestaurantMenuItem> dessertItems;
        private List<RestaurantMenuItem> drinksItems;

        public RestaurantExploreSectionViewModel(string name, string normalIcon, string selectedIcon)
            : base(name, normalIcon, selectedIcon)
        {
            this.breakfastItems = GetBreakfastItems();
            this.mainItems = GetMainItems();
            this.dessertItems = GetDessertItems();
            this.drinksItems = GetDrinksItems();
        }

        public List<RestaurantMenuItem> BreakfastItems
        {
            get
            {
                return this.breakfastItems;
            }
        }

        public List<RestaurantMenuItem> MainItems
        {
            get
            {
                return this.mainItems;
            }
        }

        public List<RestaurantMenuItem> DessertItems
        {
            get
            {
                return this.dessertItems;
            }
        }

        public List<RestaurantMenuItem> DrinksItems
        {
            get
            {
                return this.drinksItems;
            }
        }

        private static List<RestaurantMenuItem> GetBreakfastItems()
        {
            List<RestaurantMenuItem> items = new List<RestaurantMenuItem>();
            items.Add(new RestaurantMenuItem("French Bread", "tabView_Restaurant_FrenchBread.png"));
            items.Add(new RestaurantMenuItem("Healthy Breakfast", "tabView_Restaurant_HealthyBreakfast.png"));
            items.Add(new RestaurantMenuItem("Indian", "tabView_Restaurant_Indian.png"));
            items.Add(new RestaurantMenuItem("Sausages", "tabView_Restaurant_Sausages.png"));

            return items;
        }

        private static List<RestaurantMenuItem> GetMainItems()
        {
            List<RestaurantMenuItem> items = new List<RestaurantMenuItem>();
            items.Add(new RestaurantMenuItem("Bulgarian Tortilla", "tabView_Restaurant_BulgarianTortilla.png"));
            items.Add(new RestaurantMenuItem("Mediterranean Fish", "tabView_Restaurant_MediterraneanFish.png"));
            items.Add(new RestaurantMenuItem("Pork With Blueberries", "tabView_Restaurant_PorkWithBlueberries.png"));
            items.Add(new RestaurantMenuItem("Spinach Potato Nest Bites", "tabView_Restaurant_SpinachPotatoNestBites.png"));

            return items;
        }

        private static List<RestaurantMenuItem> GetDessertItems()
        {
            List<RestaurantMenuItem> items = new List<RestaurantMenuItem>();
            items.Add(new RestaurantMenuItem("American Pancakes", "tabView_Restaurant_AmericanPancakes.png"));
            items.Add(new RestaurantMenuItem("Belgian Chocolate", "tabView_Restaurant_BelgianChocolate.png"));
            items.Add(new RestaurantMenuItem("Blueberry Waffle", "tabView_Restaurant_BlueberryWaffle.png"));
            items.Add(new RestaurantMenuItem("Tiramisu", "tabView_Restaurant_Tiramisu.png"));

            return items;
        }

        private static List<RestaurantMenuItem> GetDrinksItems()
        {
            List<RestaurantMenuItem> items = new List<RestaurantMenuItem>();
            items.Add(new RestaurantMenuItem("Ale", "tabView_Restaurant_Ale.png"));
            items.Add(new RestaurantMenuItem("Lager", "tabView_Restaurant_Lager.png"));
            items.Add(new RestaurantMenuItem("White Wine", "tabView_Restaurant_WhiteWine.png"));
            items.Add(new RestaurantMenuItem("Wine", "tabView_Restaurant_Wine.png"));

            return items;
        }
    }
}
