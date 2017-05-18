using System;
using Xamarin.Forms;

namespace Examples.DataForm.Reservations
{
    public partial class Example : ContentPage
    {
        public static MainViewModel vm = new MainViewModel();

        public Example()
        {
            InitializeComponent();
            this.BindingContext = vm;

            var addReservation = new TapGestureRecognizer();
            addReservation.Tapped += addReservationClicked;

            this.addReservationImage.GestureRecognizers.Add(addReservation);
            this.addReservationLabel.GestureRecognizers.Add(addReservation);

            this.dateHeader.Text = DateTime.Today.ToString("ddd, dd.MM");
            this.listView.LayoutDefinition.VerticalItemSpacing = Device.OnPlatform(15, 20, 20);
            this.listView.LayoutDefinition.ItemLength = Device.OnPlatform(42, 56, 56);
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

        private void addReservationClicked(object sender, EventArgs e)
        {
            var page = new DataFormPage();
            NavigationPage.SetHasNavigationBar(page, false);
            this.Navigation.PushAsync(page);
        }

        private void ReservationTap(object sender, Telerik.XamarinForms.DataControls.ListView.ItemTapEventArgs e)
        {
            var page = new DataFormPage(e.Item as Reservation);
            NavigationPage.SetHasNavigationBar(page, false);
            this.Navigation.PushAsync(page);
        }
    }
}