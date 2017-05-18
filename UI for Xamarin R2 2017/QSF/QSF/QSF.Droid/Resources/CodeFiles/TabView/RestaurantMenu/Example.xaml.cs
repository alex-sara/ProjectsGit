using Xamarin.Forms;

namespace Examples.TabView.RestaurantMenu
{
    public partial class Example : ContentPage
    {
        public Example()
        {
            InitializeComponent();

            this.BindingContext = new RestaurantViewModel();
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

        protected override bool OnBackButtonPressed()
        {
            Navigation.PopAsync();
            return true;
        }
    }
}