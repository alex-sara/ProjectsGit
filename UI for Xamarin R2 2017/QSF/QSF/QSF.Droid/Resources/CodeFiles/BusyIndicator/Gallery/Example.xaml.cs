using Xamarin.Forms;

namespace Examples.BusyIndicator.Gallery
{
    public partial class Example : ContentPage
    {
        public Example()
        {
            InitializeComponent();

            this.BindingContext = new ViewModel();
        }

        private void Button_Clicked(object sender, System.EventArgs e)
        {
            this.Navigation.PopAsync();
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