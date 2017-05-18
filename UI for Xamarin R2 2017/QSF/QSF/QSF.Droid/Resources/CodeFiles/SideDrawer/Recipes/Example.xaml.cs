using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Examples.SideDrawer.Recipes
{
    public partial class Example : ContentPage
    {
        MainViewModel vm;
        public Example()
        {
            InitializeComponent();

            this.BindingContext = vm = new MainViewModel();

            this.drawer.DrawerLength = (Examples.Helpers.DeviceHelper.ScreenWidth / Examples.Helpers.DeviceHelper.PixelDensity) * 0.8; 
            
            var backClicked = new TapGestureRecognizer();
            backClicked.Tapped += backClicked_Tapped;

            this.drawerOpener.GestureRecognizers.Add(backClicked);

            if (Device.OS == TargetPlatform.iOS)
            {
                Grid.SetColumnSpan(this.title, 2);
                Grid.SetColumn(this.title, 0);
                this.title.HorizontalOptions = LayoutOptions.Center;
                this.drawerOpener.Padding = new Thickness(8, 0, 16, 0);
            }
        }

        void backClicked_Tapped(object sender, EventArgs e)
        {
            this.drawer.IsOpen = true;
        }

        void drawerList_SelectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                switch (e.NewItems[0].ToString())
                {
                    case "Sandwitch": vm.Load("Sandwitch"); break;
                    case "Desserts": vm.Load("Desserts"); break;
                    case "Paleo": vm.Load("Paleo"); break;
                    case "Cocktails": vm.Load("Cocktails"); break;
                    default: vm.Load("Breakfast"); break;
                }
                this.drawer.IsOpen = false;
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var rootGrid = this.Content as Grid;
            if (Examples.Helpers.ExampleHelper.SetImageButtonOnTop(ref rootGrid))
            {
                this.Content = rootGrid;
            }
        }

        void Tapped(object sender, Telerik.XamarinForms.DataControls.ListView.ItemTapEventArgs e)
        {
            vm.Load(e.Item.ToString());
        }
    }
}
