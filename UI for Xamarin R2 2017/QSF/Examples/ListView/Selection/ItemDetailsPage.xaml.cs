using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Telerik.XamarinForms.DataControls;
using Xamarin.Forms;

namespace Examples.ListView.Selection
{
    public partial class ItemDetailsPage : ContentPage
    {
        private RadListView list;
        private BusinessItem tappedItem;
        public ItemDetailsPage(IEnumerable<object> availableActions, RadListView list, BusinessItem tappedItem)
        {
            InitializeComponent();
            this.list = list;
            var backClicked = new TapGestureRecognizer();
            backClicked.Tapped += backClicked_Tapped;
            this.backButton.GestureRecognizers.Add(backClicked);
            this.Content.BindingContext = this.tappedItem = tappedItem;
        }

        void FavoriteButtonClicked(object sender, EventArgs e)
        {
            tappedItem.IsFavourite = !tappedItem.IsFavourite;
        }

        void DeleteButtonClicked(object sender, EventArgs e)
        {
            (list.ItemsSource as ObservableCollection<BusinessItem>).Remove(this.tappedItem);
            var example = new Example(list.ItemsSource as ObservableCollection<BusinessItem>);
            NavigationPage.SetHasNavigationBar(example, false);
            Navigation.PushAsync(example);
        }
        void backClicked_Tapped(object sender, EventArgs e)
        {
            Navigation.PopAsync();
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
            list.SelectedItems.Clear();
            Navigation.PopAsync();
            return true;
        }
    }
}
