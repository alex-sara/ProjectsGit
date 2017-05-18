using Examples.SideDrawer.Recipes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Examples.ListView.Layouts
{
    public class MainViewModel
    {
        public ObservableCollection<Recipe> Items { get; set; }
        public ObservableCollection<ImageSource> LayoutOptions { get; set; }
        public MainViewModel()
        {
            this.Items = new ObservableCollection<Recipe>()
            {
                new Recipe("Breakfast0.png", "Breakfast food", "by kkendra", "BREAKFAST"),
                new Recipe("Breakfast1.png", "Sandwich", "by diddo", "BREAKFAST"),
                new Recipe("Breakfast2.png", "Sandwich", "by diddo", "BREAKFAST"),
                new Recipe("Breakfast3.png", "Sandwich", "by kkendra", "BREAKFAST"),
                new Recipe("Sandwich0.png", "Sandwich", "by diddo", "SANDWICH"),
                new Recipe("Sandwich1.png", "Sandwich", "by diddo", "SANDWICH"),
                new Recipe("Sandwich2.png", "Sandwich", "by kkendra", "SANDWICH"),
                new Recipe("Sandwich3.png", "Sandwich", "by kkendra", "SANDWICH"),
                new Recipe("Desserts0.png", "Dessert", "by diddo", "DESSERT"),
                new Recipe("Desserts2.png", "Dessert", "by diddo", "DESSERT"),
                new Recipe("Desserts3.png", "Dessert", "by kkendra", "DESSERT"),
                new Recipe("Desserts1.png", "Dessert", "by kkendra", "DESSERT"),
                new Recipe("Paleo0.png", "Paleo", "by kkendra", "PALEO"),
                new Recipe("Paleo2.png", "Paleo", "by diddo", "PALEO"),
                new Recipe("Paleo3.png", "Paleo", "by kkendra", "PALEO"),
                new Recipe("Paleo1.png", "Paleo", "by diddo", "PALEO"),
                new Recipe("Cocktails0.png", "Cocktail", "by kkendra", "COCKTAIL"),
                new Recipe("Cocktails2.png", "Cocktail", "by kkendra", "COCKTAIL"),
                new Recipe("Cocktails3.png", "Cocktail", "by diddo", "COCKTAIL"),
                new Recipe("Cocktails1.png", "Cocktail", "by diddo", "COCKTAIL"),
            };
            this.LayoutOptions = new ObservableCollection<ImageSource>()
            {
                ImageSource.FromFile("gridLayout.png"),
                ImageSource.FromFile("linearLayout.png")
            };
        }
    }
}