using System;
using Examples.Helpers;
using Xamarin.Forms;

namespace Examples.ZipLibrary.CreateArchive
{
    public partial class Example : ContentPage
    {
        public Example()
        {
            this.InitializeComponent();

            var viewModel = new MainViewModel();
            viewModel.OnNavigateBackRequested += this.OnNavigateBackRequested;
            this.BindingContext = viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var rootGrid = this.Content as Grid;
            if (ExampleHelper.SetImageButtonOnTop(ref rootGrid))
            {
                this.Content = rootGrid;
            }
        }

        private void OnNavigateBackRequested(object sender, EventArgs e)
        {
            NavigationHelper.NavigateBackFromExample(this);
        }
    }
}
