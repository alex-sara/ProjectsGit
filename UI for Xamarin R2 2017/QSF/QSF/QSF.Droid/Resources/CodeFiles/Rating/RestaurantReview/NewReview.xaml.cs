using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Examples.Rating.RestaurantReview
{
    public partial class NewReview : ContentPage
    {
        public NewReview()
        {
            InitializeComponent();
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}