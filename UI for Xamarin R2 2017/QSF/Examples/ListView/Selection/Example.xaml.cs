using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using Telerik.XamarinForms.DataControls.ListView;
using Xamarin.Forms;

namespace Examples.ListView.Selection
{
    public partial class Example : ContentPage
    {
        public Example()
        {
            InitializeComponent();
            var vm = new MainViewModel();
            this.BindingContext = vm;
            this.list.ItemTapped += list_ItemTapped;
            this.list.SelectionChanged += list_SelectionChanged;
            this.tab.SelectionChanged += tab_SelectionChanged;
            var tapRecognizer = new TapGestureRecognizer();
            this.disabledTabsLayer.GestureRecognizers.Add(tapRecognizer);
            this.SetProperText();
            this.tab.SelectedItems.Add(vm.AvailableTabs[0]);
        }

        public Example(ObservableCollection<BusinessItem> itemSource)
        {
            InitializeComponent();
            this.BindingContext = new MainViewModel(itemSource);
            this.list.ItemTapped += list_ItemTapped;
            this.list.SelectionChanged += list_SelectionChanged;
            this.tab.SelectionChanged += tab_SelectionChanged;
            this.selectedItemsCounter.Text = "Selected 0";
            this.SetProperText();
        }

        private void SetProperText()
        {
            if (Device.OS == TargetPlatform.Android || Device.OS == TargetPlatform.Windows)
            {
                this.editTextButton.Text = "EDIT";
            }
            else if (Device.OS == TargetPlatform.iOS)
            {
                this.editTextButton.Text = "Edit";
            }
        }

        void tab_SelectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (this.tab.SelectedItems.Count != 0)
            {
                if (this.tab.SelectedItems[0].ToString().Equals("ALL"))
                {
                    this.list.FilterDescriptors.Clear();
                }
                else
                {
                    this.list.FilterDescriptors.Add(new DelegateFilterDescriptor() { Filter = this.Filter });
                }
            }
        }

        void backButtonClicked(object sender, EventArgs e)
        {
            this.tab.SelectionChanged += tab_SelectionChanged;
            this.navBar.BackgroundColor = Color.FromHex("FFF2ED");
            this.textHolder.IsVisible = true;
            this.leadLable.IsVisible = true;
            this.buttonsHolder.IsVisible = false;
            this.backButtonHolder.IsVisible = false;
            this.selectedItemsCounter.IsVisible = false;
            this.list.SelectionMode = SelectionMode.Single;
            this.list.IsItemSwipeEnabled = true;
            this.tab.InputTransparent = false;
            this.disabledTabsLayer.IsVisible = false;
            this.UpdateListItemStateStyle(false);
        }

        void editClicked(object sender, EventArgs e)
        {
            this.list.SelectedItems.Clear();
            this.tab.SelectionChanged -= tab_SelectionChanged;
            this.selectedItemsCounter.Text = "Selected " + this.list.SelectedItems.Count.ToString();
            this.navBar.BackgroundColor = Color.FromHex("5D4037");
            this.textHolder.IsVisible = false;
            this.leadLable.IsVisible = false;
            this.buttonsHolder.IsVisible = true;
            this.backButtonHolder.IsVisible = true;
            this.selectedItemsCounter.IsVisible = true;
            this.tab.InputTransparent = true;
            this.disabledTabsLayer.BackgroundColor = Color.FromRgba(93, 64, 55, 120);
            this.disabledTabsLayer.IsVisible = true;
            this.UpdateListItemStateStyle(true);
            this.list.SelectionMode = SelectionMode.Multiple;

        }
        private void UpdateListItemStateStyle(bool isSelectedStateVisible)
        {
            if (isSelectedStateVisible)
            {
                this.list.SelectedItemStyle = new ListViewItemStyle() { BackgroundColor = Color.FromHex("C2B0A9"), BorderColor = Color.FromHex("D2C7C3"), BorderLocation = Telerik.XamarinForms.Common.Location.All, BorderWidth = 1 };
            }
            else
            {
                this.list.SelectedItemStyle = new ListViewItemStyle() { BackgroundColor = Color.FromHex("E4D8D4"), BorderColor = Color.FromHex("D2C7C3"), BorderLocation = Telerik.XamarinForms.Common.Location.All, BorderWidth = 1 };
            }
        }

        void list_SelectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (this.list.SelectionMode == SelectionMode.Multiple)
            {
                this.selectedItemsCounter.Text = "Selected " + this.list.SelectedItems.Count.ToString();
            }
        }

        private bool Filter(object arg)
        {
            var itemToFilter = arg as BusinessItem;
            return itemToFilter.IsFavourite;
        }

        void FavoriteButtonClicked(object sender, EventArgs e)
        {
            //TODO: Use sender.BIndingCOntext
            if (this.list.SelectionMode == SelectionMode.Multiple)
            {
                if (this.AreFavoriteStatesDifferent())
                {
                    if (this.list.SelectedItems.Count != 0)
                    {
                        foreach (BusinessItem item in this.list.SelectedItems)
                        {
                            item.IsFavourite = false;
                        }
                    }
                    else
                    {
                        ((sender as Button).BindingContext as BusinessItem).IsFavourite = false;
                    }
                }
                else
                {
                    if (this.list.SelectedItems.Count != 0)
                    {
                        foreach (BusinessItem item in this.list.SelectedItems)
                        {
                            item.IsFavourite = !item.IsFavourite;
                        }
                    }
                    else
                    {
                        return;
                    }
                }
                this.list.SelectedItems.Clear();
                this.ResetSortDescriptors();
            }
            else
            {
                ((sender as Button).BindingContext as BusinessItem).IsFavourite = !((sender as Button).BindingContext as BusinessItem).IsFavourite;
                list.EndItemSwipe(false);
                this.ResetSortDescriptors();
            }
        }

        private void ResetSortDescriptors()
        {
            ObservableCollection<SortDescriptorBase> localCache = this.list.SortDescriptors;
            this.list.SortDescriptors.Clear();
            foreach (SortDescriptorBase item in localCache)
            {
                this.list.SortDescriptors.Add(item);
            }
        }

        private bool AreFavoriteStatesDifferent()
        {
            bool? initialState = null;
            foreach (BusinessItem item in this.list.SelectedItems)
            {
                if (initialState == null)
                {
                    initialState = item.IsFavourite;
                    continue;
                }
                if (initialState == item.IsFavourite)
                {
                    continue;
                }
                if (initialState != item.IsFavourite)
                {
                    return true;
                }
            }
            return false;
        }

        void DeleteButtonClicked(object sender, EventArgs e)
        {
            //TODO: Use sender.BIndingCOntext
            if (this.list.SelectionMode == SelectionMode.Multiple)
            {
                if (list.SelectedItems.Count != 0)
                {
                    List<BusinessItem> selectedItems = new List<BusinessItem>();
                    foreach (var item in this.list.SelectedItems)
                    {
                        selectedItems.Add(item as BusinessItem);
                    }
                    foreach (BusinessItem item in selectedItems)
                    {
                        (this.list.ItemsSource as ObservableCollection<BusinessItem>).Remove(item);
                    }
                    this.selectedItemsCounter.Text = "Selected " + this.list.SelectedItems.Count.ToString();
                }
                else
                {
                    (this.list.ItemsSource as ObservableCollection<BusinessItem>).Remove((sender as Button).BindingContext as BusinessItem);
                }
            }
            else
            {
                (list.ItemsSource as ObservableCollection<BusinessItem>).Remove((sender as Button).BindingContext as BusinessItem);
                list.EndItemSwipe(false);
            }
        }

        void list_ItemTapped(object sender, ItemTapEventArgs e)
        {
            if (this.list.SelectionMode == Telerik.XamarinForms.DataControls.ListView.SelectionMode.Single && !this.list.IsSwipingInProgress && e.Item is BusinessItem)
            {
                var detailsPage = new ItemDetailsPage((this.BindingContext as MainViewModel).ItemDetailsPageAvailableActions, this.list, (BusinessItem)e.Item);
                NavigationPage.SetHasNavigationBar(detailsPage, false);
                Navigation.PushAsync(detailsPage);
            }
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
