using Xamarin.Forms;

namespace Examples.Rating.RestaurantReview
{
    public partial class Example : ContentPage
    {
        public Example()
        {
            InitializeComponent();
        }

        private void TapGestureRecognizer_Tapped(object sender, System.EventArgs e)
        {
            var reviewPage = new NewReview();
            NavigationPage.SetHasNavigationBar(reviewPage, false);
            Navigation.PushAsync(reviewPage);
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
    }
}