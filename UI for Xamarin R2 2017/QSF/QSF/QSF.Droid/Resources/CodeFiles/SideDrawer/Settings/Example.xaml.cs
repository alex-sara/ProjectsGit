using System;
using System.Collections.Generic;
using System.Linq;
using Telerik.XamarinForms.DataControls.ListView;
using Xamarin.Forms;

namespace Examples.SideDrawer.Settings
{
    public partial class Example : ContentPage
    {
        public Example()
        {
            InitializeComponent();
            MainViewModel vm;
            this.BindingContext = vm = new MainViewModel();
            this.transitionLabel.Text = "SlideAlong";

            this.drawer.DrawerLength = (Examples.Helpers.DeviceHelper.ScreenWidth / Examples.Helpers.DeviceHelper.PixelDensity) * 0.8;
            
            if (Device.OS == TargetPlatform.Android || Device.OS == TargetPlatform.WinPhone || Device.OS == TargetPlatform.Windows)
            {
                this.transitionsList.ItemsSource = vm.Transitions;
                this.transitionsList.SelectedItems.Add(vm.Transitions[0].ToString());
            }
            else if (Device.OS == TargetPlatform.iOS)
            {
                this.transitionsList.ItemsSource = vm.TransitionsIos;
                this.transitionsList.SelectedItems.Add(vm.TransitionsIos[0].ToString());
            }

            var backClicked = new TapGestureRecognizer();
            backClicked.Tapped += backClicked_Tapped;

            this.drawerOpener.GestureRecognizers.Add(backClicked);
            this.drawerItems.ItemsSource = new List<string>() { "Home", "About", "Settings", "User profile" };
            this.UpdateButtonsState(ButtonPosition.Left);

            if (Device.OS == TargetPlatform.iOS)
            {
                Grid.SetColumnSpan(this.title, 2);
                Grid.SetColumn(this.title, 0);
                this.title.HorizontalOptions = LayoutOptions.Center;
                this.drawerOpener.Padding = new Thickness(8, 0, 16, 0);
                this.transitionsList.HeightRequest = 250;
            }

            transitionsList.PressedItemStyle = new ListViewItemStyle() { BackgroundColor = Color.FromRgba(30 / 255, 50 / 255, 63 / 255, 0.1) };
            transitionsList.SelectedItemStyle = new ListViewItemStyle() { BackgroundColor = Color.FromRgba(30 / 255, 50 / 255, 63 / 255, 0.1) };
            this.transitionLabel.Text = "SlideAlong";
        }

        private void UpdateButtonsState(ButtonPosition position)
        {
            switch (position)
            {
                case ButtonPosition.Left:
                    l_but.BackgroundColor = Color.FromHex("FF6E40");
                    t_but.BackgroundColor = Color.FromHex("5A595B");
                    r_but.BackgroundColor = Color.FromHex("5A595B");
                    b_but.BackgroundColor = Color.FromHex("5A595B");
                    break;
                case ButtonPosition.Top:
                    l_but.BackgroundColor = Color.FromHex("5A595B");
                    t_but.BackgroundColor = Color.FromHex("FF6E40");
                    r_but.BackgroundColor = Color.FromHex("5A595B");
                    b_but.BackgroundColor = Color.FromHex("5A595B");
                    break;
                case ButtonPosition.Right:
                    l_but.BackgroundColor = Color.FromHex("5A595B");
                    t_but.BackgroundColor = Color.FromHex("5A595B");
                    r_but.BackgroundColor = Color.FromHex("FF6E40");
                    b_but.BackgroundColor = Color.FromHex("5A595B");
                    break;
                case ButtonPosition.Bottom:
                    l_but.BackgroundColor = Color.FromHex("5A595B");
                    t_but.BackgroundColor = Color.FromHex("5A595B");
                    r_but.BackgroundColor = Color.FromHex("5A595B");
                    b_but.BackgroundColor = Color.FromHex("FF6E40");
                    break;
                default:
                    break;
            }
        }

        void backClicked_Tapped(object sender, EventArgs e)
        {
            this.drawer.IsOpen = !this.drawer.IsOpen;
        }

        void Top_Clicked(object sender, EventArgs e)
        {
            this.drawer.DrawerLocation = Telerik.XamarinForms.Primitives.SideDrawer.SideDrawerLocation.Top;
            this.UpdateDrawerVerticalLength();
            this.UpdateButtonsState(ButtonPosition.Top);
        }

        void Left_Clicked(object sender, EventArgs e)
        {
            this.drawer.DrawerLocation = Telerik.XamarinForms.Primitives.SideDrawer.SideDrawerLocation.Left;
            this.UpdateDrawerHorizontalLength();
            this.UpdateButtonsState(ButtonPosition.Left);
        }

        void Right_Clicked(object sender, EventArgs e)
        {
            this.drawer.DrawerLocation = Telerik.XamarinForms.Primitives.SideDrawer.SideDrawerLocation.Right;
            this.UpdateDrawerHorizontalLength();
            this.UpdateButtonsState(ButtonPosition.Right);
        }

        void Bottom_Clicked(object sender, EventArgs e)
        {
            this.drawer.DrawerLocation = Telerik.XamarinForms.Primitives.SideDrawer.SideDrawerLocation.Bottom;
            this.UpdateDrawerVerticalLength();
            this.UpdateButtonsState(ButtonPosition.Bottom);
        }

        private void UpdateDrawerVerticalLength()
        {
            this.drawer.DrawerLength = (Examples.Helpers.DeviceHelper.ScreenWidth / Examples.Helpers.DeviceHelper.PixelDensity) * 0.8;
        }

        private void UpdateDrawerHorizontalLength()
        {
            this.drawer.DrawerLength = (Examples.Helpers.DeviceHelper.ScreenWidth / Examples.Helpers.DeviceHelper.PixelDensity) * 0.8;
        }

        void Tapped(object sender, Telerik.XamarinForms.DataControls.ListView.ItemTapEventArgs e)
        {
            switch (e.Item.ToString())
            {
                case "SlideAlong": this.drawer.DrawerTransitionType = Telerik.XamarinForms.Primitives.SideDrawerTransitionType.SlideAlong; this.transitionLabel.Text = "SlideAlong"; break;
                case "SlideInOnTop": this.drawer.DrawerTransitionType = Telerik.XamarinForms.Primitives.SideDrawerTransitionType.SlideInOnTop; this.transitionLabel.Text = "SlideInOnTop"; break;
                case "Push": this.drawer.DrawerTransitionType = Telerik.XamarinForms.Primitives.SideDrawerTransitionType.Push; this.transitionLabel.Text = "Push"; break;
                case "Reveal": this.drawer.DrawerTransitionType = Telerik.XamarinForms.Primitives.SideDrawerTransitionType.Reveal; this.transitionLabel.Text = "Reveal"; break;
                case "ReverseSlideOut": this.drawer.DrawerTransitionType = Telerik.XamarinForms.Primitives.SideDrawerTransitionType.ReverseSlideOut; this.transitionLabel.Text = "ReverseSlideOut"; break;
                case "ScaleUp": this.drawer.DrawerTransitionType = Telerik.XamarinForms.Primitives.SideDrawerTransitionType.ScaleUp; this.transitionLabel.Text = "ScaleUp"; break;
                default: this.drawer.DrawerTransitionType = Telerik.XamarinForms.Primitives.SideDrawerTransitionType.Fade; this.transitionLabel.Text = "Fade"; break;
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

        private enum ButtonPosition { Left = 0, Top = 1, Right = 2, Bottom = 3}
    }
}