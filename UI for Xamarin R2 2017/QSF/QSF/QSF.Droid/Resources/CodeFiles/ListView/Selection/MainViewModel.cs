using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace Examples.ListView.Selection
{
    public class MainViewModel
    {
        public ObservableCollection<BusinessItem> NewsCollection {get;set;}
        public ObservableCollection<string> AvailableTabs { get; set; }
        public ObservableCollection<ImageSource> ItemDetailsPageAvailableActions { get; set; }

        public MainViewModel()
        {
            this.ItemDetailsPageAvailableActions = new ObservableCollection<ImageSource>();
            this.ItemDetailsPageAvailableActions.Add(ImageSource.FromFile("ic_listview_selection_fav.png"));
            this.ItemDetailsPageAvailableActions.Add(ImageSource.FromFile("ic_listview_selection_delete.png"));
            this.AvailableTabs = new ObservableCollection<string>();
            this.AvailableTabs.Add("ALL");
            this.AvailableTabs.Add("FAVORITES");
            this.NewsCollection = new ObservableCollection<BusinessItem>();
            this.NewsCollection.Add(new BusinessItem()
            {
                Date = "Today",
                Title = "TESLA Announced brand new Model X",
                Content = "Statistics show that the earlier Model S was bought mostly by men. Only 13% of the buyers were women. When asked women point out as most important features of a car the safety, reliability and extra space. Here comes the Model X.",
                IsFavourite = true
            });
            this.NewsCollection.Add(new BusinessItem()
            {
                Date = "Today",
                Title = "70 kWh for $70k",
                Content = "Now, on to the awesome news of today. The 70 kWh version of the Model S in the single motor version at $70k costs $5k less than the dual motor version. Importantly, enough options are now standard that you will have bought a great car even if you pick the base version."
            });
            this.NewsCollection.Add(new BusinessItem()
            {
                Date = "Yesterday",
                Title = "90 kWh Pack",
                Content = "New buyers now have the option of upgrading the pack energy from 85 to 90 kWh for $3k, which provides about 6% increased range. For example, this takes our current longest range model, the 85D, to almost 300 miles of highway range at 65mph.",
                IsFavourite = true
            });
            this.NewsCollection.Add(new BusinessItem()
            {
                Date = "Yesterday",
                Title = "Luuudicrous Mode",
                Content = "That was combined with upgrading the main pack contactor to use inconel (a high temperature space-grade superalloy) instead of steel, so that it remains springy under the heat of heavy current. The net result is that we can safely increase the max pack output from 1300 to 1500 Amps.",
            });
        }
        public MainViewModel(ObservableCollection<BusinessItem> itemSource)
        {
            this.ItemDetailsPageAvailableActions = new ObservableCollection<ImageSource>();
            this.ItemDetailsPageAvailableActions.Add(ImageSource.FromFile("ic_listview_selection_fav.png"));
            this.ItemDetailsPageAvailableActions.Add(ImageSource.FromFile("ic_listview_selection_delete.png"));
            this.AvailableTabs = new ObservableCollection<string>();
            this.AvailableTabs.Add("ALL");
            this.AvailableTabs.Add("FAVORITES");
            this.NewsCollection = itemSource;
        }
    }
}