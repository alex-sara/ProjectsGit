using System;
using System.Linq;

using Xamarin.Forms;

namespace Examples.Pages
{
    public partial class AboutPageUWP : ContentPage
    {
        public AboutPageUWP()
        {
            InitializeComponent();

            this.contentLabel.Text = "Progress® Telerik® UI for Xamarin is a suite of components for building great Xamarin.Forms apps for the most popular mobile platforms including iOS, from a single shared C# code base. With Progress® Telerik® UI for Xamarin you can easily implement various functionalities in your Xamarin.Forms projects and achieve the same scenarios across different platforms.";

            var backLableTapped = new TapGestureRecognizer();
            backLableTapped.Tapped += backButtonClicked;
            this.backLableHolder.GestureRecognizers.Add(backLableTapped);

            var backButtonTapped = new TapGestureRecognizer();
            backButtonTapped.Tapped += backButtonClicked;
            this.backButton.GestureRecognizers.Add(backButtonTapped);
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