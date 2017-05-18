using System;
using System.Linq;

using Xamarin.Forms;

namespace Examples.Pages
{
    public partial class ControlInfoPageUWP : ContentPage
    {
        public ControlInfoPageUWP(string controlDescription, string loadedControl)
        {
            InitializeComponent();

            this.contentLabel.Text = controlDescription;
            this.backLabel.Text = loadedControl;

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
    }
}