using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace Examples.SideDrawer.Recipes
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Recipe> recipes;

        public ObservableCollection<Recipe> Recipes
        {
            get { return recipes; }
            set
            {
                recipes = value;
                this.OnPropertyChanged("Recipes");
            }
        }

        public List<string> Categories { get; set; }

        public MainViewModel()
        {
            this.Categories = new List<string>() { "Breakfast", "Sandwiches", "Desserts", "Paleo", "Cocktails" };

            this.Recipes = new ObservableCollection<Recipe>()
            {
                new Recipe("Breakfast0.png", "Breakfast", "kkendra"),
                new Recipe("Breakfast1.png", "Breakfast", "diddo"),
                new Recipe("Breakfast2.png", "Breakfast", "kkendra"),
                new Recipe("Breakfast3.png", "Breakfast", "diddo"),
            };
        }

        internal void Load(string itemsToLoad)
        {
            switch (itemsToLoad)
            {
                case "Sandwiches":
                    this.Recipes = new ObservableCollection<Recipe>()
                    {
                        new Recipe("Sandwich0.png", "Sandwich", "by diddo", "SANDWICH"),
                        new Recipe("Sandwich1.png", "Sandwich", "by diddo", "SANDWICH"),
                        new Recipe("Sandwich2.png", "Sandwich", "by kkendra", "SANDWICH"),
                        new Recipe("Sandwich3.png", "Sandwich", "by kkendra", "SANDWICH"),
                    };
                    break;
                case "Desserts":
                    this.Recipes = new ObservableCollection<Recipe>()
                    {
                        new Recipe("Desserts0.png", "Dessert", "by diddo", "DESSERT"),
                        new Recipe("Desserts2.png", "Dessert", "by diddo", "DESSERT"),
                        new Recipe("Desserts3.png", "Dessert", "by kkendra", "DESSERT"),
                        new Recipe("Desserts1.png", "Dessert", "by kkendra", "DESSERT"),
                    };
                    break;
                case "Paleo":
                    this.Recipes = new ObservableCollection<Recipe>()
                    {
                        new Recipe("Paleo0.png", "Paleo", "by kkendra", "PAELO"),
                        new Recipe("Paleo2.png", "Paleo", "by diddo", "PAELO"),
                        new Recipe("Paleo3.png", "Paleo", "by kkendra", "PAELO"),
                    };
                    break;
                case "Cocktails":
                    this.Recipes = new ObservableCollection<Recipe>()
                    {
                        new Recipe("Cocktails0.png", "Cocktail", "by kkendra", "COCKTAIL"),
                        new Recipe("Cocktails2.png", "Cocktail", "by kkendra", "COCKTAIL"),
                        new Recipe("Cocktails3.png", "Cocktail", "by diddo", "COCKTAIL"),
                        new Recipe("Cocktails1.png", "Cocktail", "by diddo", "COCKTAIL"),
                    };
                    break;
                default:
                    this.Recipes = new ObservableCollection<Recipe>()
                    {
                        new Recipe("Breakfast0.png", "Breakfast food", "by kkendra", "BREAKFAST"),
                        new Recipe("Breakfast1.png", "Sandwich", "by diddo", "BREAKFAST"),
                        new Recipe("Breakfast2.png", "Sandwich", "by diddo", "BREAKFAST"),
                        new Recipe("Breakfast3.png", "Sandwich", "by kkendra", "BREAKFAST"),
                    };
                    break;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}