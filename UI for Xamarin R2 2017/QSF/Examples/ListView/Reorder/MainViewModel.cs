using System;
using System.Collections.ObjectModel;

namespace Examples.ListView.Reorder
{
    public class MainViewModel
    {
        public ObservableCollection<Item> ItemsToReorder { get; set; }

        public MainViewModel()
        {
            this.ItemsToReorder = new ObservableCollection<Item>()
            {
                new Item("Check weather for London"),
                new Item("Call Brian Ingram for the Hotel reservations"),
                new Item("Check the childrens' documents"),
                new Item("Check if Johan will take care of the dog"),
                new Item("Airplane tickets reschedule for the morning plane"),
                new Item("Check the trains schedule London - Paris"),
                new Item("Bills due: Alissa's ballet class free tomorrow"),
                new Item("Weekly organic basket")
            };
        }
    }
}