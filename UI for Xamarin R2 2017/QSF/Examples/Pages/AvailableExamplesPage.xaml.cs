using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace Examples
{
    public partial class AvailableExamplesPage : ContentPage
    {
        public ObservableCollection<Example> AvailableExamplesList { get; set; }
        public ObservableCollection<string> InformationMenuList { get; set; }
        private QSFControl loadedControl = null;

        public AvailableExamplesPage(QSFControl control)
        {
            InitializeComponent();
            this.loadedControl = control;
            this.InitializePage(control.Examples);
        }

        public AvailableExamplesPage(ObservableCollection<Example> examplesToLoad, bool isSidedrawerVisible = true)
        {
            InitializeComponent();
            this.InitializePage(examplesToLoad);
            this.drawerOpenerHost.IsVisible = isSidedrawerVisible;
        }

        private void InitializePage(IList<Example> examplesToLoad)
        {
            this.AvailableExamplesList = new ObservableCollection<Example>();
            this.InformationMenuList = new ObservableCollection<string>() { "Info", "Documentation" };

            var toggleDrawer = new TapGestureRecognizer();
            toggleDrawer.Tapped += drawerButtonClicked;

            this.drawerOpenerHost.GestureRecognizers.Add(toggleDrawer);

            if (Device.OS == TargetPlatform.Android || Device.OS == TargetPlatform.Windows)
            {
                this.navigationLabel.HorizontalOptions = LayoutOptions.Start;
                this.homeScreenDrawer.DrawerLength = 110;
            }
            else if (Device.OS == TargetPlatform.iOS)
            {
                this.navigationLabel.HorizontalOptions = LayoutOptions.Center;
                Grid.SetColumnSpan(this.navigationLabel, 3);
                Grid.SetColumn(this.navigationLabel, 0);
                this.homeScreenDrawer.DrawerLength = 120;
            }

            bool areControlsSame = true;
            for (int i = 0; i < examplesToLoad.Count; i++)
            {
                this.AvailableExamplesList.Add(examplesToLoad[i]);
                if (areControlsSame)
                {
                    if (examplesToLoad.Count > 1 && i + 1 < examplesToLoad.Count && !examplesToLoad[i].Control.Equals(examplesToLoad[i + 1].Control))
                    {
                        areControlsSame = false;
                    }
                }
            }
            this.navigationLabel.Text = areControlsSame == false ? "All examples" : this.AvailableExamplesList.First().Control;
            this.BindingContext = this;

            var backClicked = new TapGestureRecognizer();
            backClicked.Tapped += backButtonClicked;
            this.backButton.GestureRecognizers.Add(backClicked);

            var definition = this.examplesList.LayoutDefinition as Telerik.XamarinForms.DataControls.ListView.ListViewGridLayout;

            var padding = Device.OnPlatform(6, 16, 16);

            definition.SpanCount = (int)Math.Floor(((Examples.Helpers.DeviceHelper.ScreenWidth / Examples.Helpers.DeviceHelper.PixelDensity) - padding * 3 /*total horizontal spacing between items*/) / 150 /*image width*/);

            if (Examples.Helpers.DeviceHelper.ScreenWidth / Examples.Helpers.DeviceHelper.PixelDensity >= 750)
            {
                definition.SpanCount -= 1;
            }
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
                case "Info":
                    ContentPage pageToNavigate = null;
                    if (this.loadedControl == null)
                    {
                        pageToNavigate = new Examples.Pages.ControlInfoPage("What should be displayed when no specific control is selected?", "No control Loaded");
                    }
                    else
                    {
                        pageToNavigate = new Examples.Pages.ControlInfoPage(this.loadedControl.Description, this.loadedControl.Name);
                    }

                    NavigationPage.SetHasNavigationBar(pageToNavigate, false);
                    Navigation.PushAsync(pageToNavigate);
                    break;
                default: // Documentation
                    string uri = "http://docs.telerik.com/devtools/xamarin/controls/" + this.loadedControl.Name.ToLower() + "/" + this.loadedControl.Name.ToLower() + "-overview";
                    Device.OpenUri(new Uri(uri));
                    break;
            }
        }

        async void ExampleTapped(object sender, Telerik.XamarinForms.DataControls.ListView.ItemTapEventArgs e)
        {
            var exampleToNavigate = PageFactory.GetPage((e.Item as Example).Control + "." + (e.Item as Example).Title);
            StartPage.CurrentlyOpenedExample = e.Item as Example;
            StartPage.ExamplesListCache = this.AvailableExamplesList;
            NavigationPage.SetHasNavigationBar(exampleToNavigate, false);
            await Navigation.PushAsync(exampleToNavigate);
        }

        void backButtonClicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        protected override bool OnBackButtonPressed()
        {
            Navigation.PopAsync();
            return true;
        }
    }
}