using Examples;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Examples
{
    public partial class AllFeaturedExamplesPage : ContentPage
    {
        public ObservableCollection<Example> FeaturedExamplesList { get; set; }
        public ObservableCollection<string> InformationMenuList { get; set; }

        public AllFeaturedExamplesPage(ObservableCollection<Example> featuredExamplesList = null)
        {
            StartPage.ExamplesListCache = this.FeaturedExamplesList = featuredExamplesList;
            this.InformationMenuList = new ObservableCollection<string>()
            { 
                "Option 1",
                "Option 2",
                "Option 3"
            };
            this.BindingContext = this;
            InitializeComponent();

            this.backgroundGradientImage.Source = ImageSource.FromFile("background_normal.png");

            this.backButton.Source = ImageSource.FromFile("ic_arrow_back.png");
            var backClicked = new TapGestureRecognizer();
            backClicked.Tapped += backButtonClicked;
            this.backButton.GestureRecognizers.Add(backClicked); 
            
            var toggleDrawer = new TapGestureRecognizer();
            toggleDrawer.Tapped += drawerButtonClicked;

            this.drawerOpener.Source = ImageSource.FromFile("ic_menu.png");
            this.drawerOpener.GestureRecognizers.Add(toggleDrawer);

            //int totalItemSpacing = 6 + 12 + 16; //these values are set by design
            //var definition = this.examplesList.LayoutDefinition as Telerik.XamarinForms.DataControls.ListView.ListViewGridLayout;
            //definition.ItemLength = Examples.Pages.DeviceHelper.ScreenHeight / 3 - totalItemSpacing;
        }

        async void ExampleTapped(object sender, Telerik.XamarinForms.DataControls.ListView.ItemTapEventArgs e)
        {
            var exampleToNavigate = PageFactory.GetPage((e.Item as Example).Control + "." + (e.Item as Example).Title);
            StartPage.CurrentlyOpenedExample = e.Item as Example;
            NavigationPage.SetHasNavigationBar(exampleToNavigate, false);
            await Navigation.PushAsync(exampleToNavigate, false);
        }

        void drawerButtonClicked(object sender, EventArgs e)
        {
            infoDrawer.IsOpen = !infoDrawer.IsOpen;
        }

        void backButtonClicked(object sender, EventArgs e)
        {
            Navigation.PopAsync(false);
        }

        void LinkTapped(object sender, Telerik.XamarinForms.DataControls.ListView.ItemTapEventArgs e)
        {
            if (e.Item.ToString().Equals("Info"))
            {
                //Navigation.PushAsync(new ControlInfoPage(), false);
            }
            else
            {
                Device.OpenUri(new Uri(string.Format("http://docs.telerik.com/devtools/xamarin/controls/{0}/{0}-overview", "A")));
            }
        }

        protected override bool OnBackButtonPressed()
        {
            if (infoDrawer.IsOpen)
            {
                infoDrawer.IsOpen = false;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}