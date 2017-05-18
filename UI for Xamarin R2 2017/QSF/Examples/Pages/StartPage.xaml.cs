using System;
using System.Collections.ObjectModel;
using System.Linq;
using Telerik.XamarinForms.DataControls.ListView;
using Xamarin.Forms;

namespace Examples
{
    public partial class StartPage : ContentPage
    {
        public static Example CurrentlyOpenedExample { get; set; }
        public static ObservableCollection<Example> ExamplesListCache { get; set; }

        private StartPageViewModel vm;
        private ExamplesLoader examplesLoader;

        public StartPage(ExamplesLoader loader, double screenWidth, double screenHeight, double pixelDensity)
        {
            this.examplesLoader = loader;
            Examples.Helpers.DeviceHelper.ScreenWidth = screenWidth;
            Examples.Helpers.DeviceHelper.ScreenHeight = screenHeight;
            Examples.Helpers.DeviceHelper.PixelDensity = pixelDensity;
            InitializeComponent();
            this.BindingContext = vm = new StartPageViewModel(examplesLoader);

            var toggleDrawer = new TapGestureRecognizer();
            toggleDrawer.Tapped += drawerButtonClicked;

            this.drawerOpenerHost.GestureRecognizers.Add(toggleDrawer);

            var seeAllClicked = new TapGestureRecognizer();
            seeAllClicked.Tapped += seeAllButton_Clicked;

            this.seeAllButton.GestureRecognizers.Add(seeAllClicked);

            if (Device.OS == TargetPlatform.Android)
            {
                this.headerLabel.HorizontalOptions = LayoutOptions.Start;
                this.headerLabel.VerticalOptions = LayoutOptions.Center;
                this.seeAllText.Text = "SEE ALL";
                Grid.SetColumnSpan(this.seeAllText, 2);
                this.seeAllText.HorizontalOptions = LayoutOptions.End;
                this.homeScreenDrawer.DrawerLength = 220;
            }
            else if (Device.OS == TargetPlatform.iOS)
            {
                this.headerLabel.HorizontalOptions = LayoutOptions.Center;
                this.headerLabel.VerticalOptions = LayoutOptions.Center;
                this.seeAllText.Text = "See All";
                this.homeScreenDrawer.DrawerLength = 230;
            }
            else if (Device.OS == TargetPlatform.Windows)
            {
                this.headerLabel.HorizontalOptions = LayoutOptions.Start;
                this.headerLabel.VerticalOptions = LayoutOptions.Center;
                this.seeAllText.Text = "SEE ALL";
                Grid.SetColumnSpan(this.seeAllText, 2);
                this.seeAllText.HorizontalOptions = LayoutOptions.End;
                this.homeScreenDrawer.DrawerLength = 220;
            }

            allControlsList.PressedItemStyle = new ListViewItemStyle() { BackgroundColor = Color.FromRgba(30 / 255, 50 / 255, 63 / 255, 0.1) };
        }

        async void ControlTapped(object sender, Telerik.XamarinForms.DataControls.ListView.ItemTapEventArgs e)
        {
            var controlToLoad = vm.AllControlsList.ToList().Find( c => c.Name.Equals((e.Item as QSFControl).Name));
            var availableExamplesPage = new AvailableExamplesPage(controlToLoad);
            NavigationPage.SetHasNavigationBar(availableExamplesPage, false);
            await Navigation.PushAsync(availableExamplesPage);
        }

        async void ExampleTapped(object sender, Telerik.XamarinForms.DataControls.ListView.ItemTapEventArgs e)
        {
            var exampleToNavigate = PageFactory.GetPage((e.Item as Example).Control + "." + (e.Item as Example).Title);
            StartPage.CurrentlyOpenedExample = e.Item as Example;
            StartPage.ExamplesListCache = vm.FeaturedExamplesList;
            NavigationPage.SetHasNavigationBar(exampleToNavigate, false);
            await Navigation.PushAsync(exampleToNavigate);
        }

        async void seeAllButton_Clicked(object sender, EventArgs e)
        {
            var featuredExamplesPage = new AvailableExamplesPage(vm.FeaturedExamplesList, false);
            NavigationPage.SetHasNavigationBar(featuredExamplesPage, false);
            await Navigation.PushAsync(featuredExamplesPage);
        }

        void drawerButtonClicked(object sender, EventArgs e)
        {
           homeScreenDrawer.IsOpen = true;
        }

        void LinkTapped(object sender, Telerik.XamarinForms.DataControls.ListView.ItemTapEventArgs e)
        {
            homeScreenDrawer.IsOpen = false;
            switch (e.Item.ToString())
            {
                case "Product Page": Device.OpenUri(new Uri("http://www.telerik.com/xamarin-ui")); break;
                case "Documentation": Device.OpenUri(new Uri("http://docs.telerik.com/devtools/xamarin/")); break;
                case "SDK Examples": Device.OpenUri(new Uri("https://github.com/telerik/xamarin-sdk")); break;
                case "Send Feedback": Device.OpenUri(new Uri("https://github.com/telerik/xamarin-sdk")); break;
                default: // About
                    var aboutPage = new Examples.Pages.AboutPage();
                    NavigationPage.SetHasNavigationBar(aboutPage, false);
                    Navigation.PushAsync(aboutPage);
                    break;
            }
        }

        protected override bool OnBackButtonPressed()
        {
            if (homeScreenDrawer.IsOpen)
            {
                homeScreenDrawer.IsOpen = false;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}