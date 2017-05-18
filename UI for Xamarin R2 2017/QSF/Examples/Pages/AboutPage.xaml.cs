using System;
using System.Linq;

using Xamarin.Forms;

namespace Examples.Pages
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();

            this.contentLabel.Text = "Progress® Telerik® UI for Xamarin is a suite of components for building great Xamarin.Forms apps for the most popular mobile platforms including iOS, from a single shared C# code base. With Progress® Telerik® UI for Xamarin you can easily implement various functionalities in your Xamarin.Forms projects and achieve the same scenarios across different platforms.";

            if (Device.OS == TargetPlatform.iOS)
            {
                var devModeTapGestureRecognizer = new TapGestureRecognizer();

                devModeTapGestureRecognizer.Tapped += DevModeTapGestureRecognizer_Tapped;
                devModeTapGestureRecognizer.NumberOfTapsRequired = 5;
                this.contentLabel.GestureRecognizers.Add(devModeTapGestureRecognizer);
            }

            //var backLableTapped = new TapGestureRecognizer();
            //backLableTapped.Tapped += backButtonClicked;
            //this.backLableHolder.GestureRecognizers.Add(backLableTapped);

            if (Device.OS == TargetPlatform.Android)
            {
                this.backLableHolder.Padding = new Thickness(16, 0, 0, 0);
            }

            if (Device.OS == TargetPlatform.iOS)
            {
                Grid.SetColumn(this.backLableHolder, 0);
                Grid.SetColumnSpan(this.backLableHolder, 2);

                this.backLabel.HorizontalOptions = LayoutOptions.Center;
            }
        }

        private void DevModeTapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            var service = DependencyService.Get<IDevModeService>();

            if (service != null)
            {
                service.EnableDevMode();
            }
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