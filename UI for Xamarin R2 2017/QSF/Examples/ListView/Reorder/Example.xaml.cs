using System;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace Examples.ListView.Reorder
{
    public partial class Example : ContentPage
    {
        public Example()
        {
            InitializeComponent();

            if (Device.OS == TargetPlatform.Android || Device.OS == TargetPlatform.Windows)
            {
                this.exampleLabel.Text = "TO DO LIST";
            }
            else if (Device.OS == TargetPlatform.iOS)
            {
                this.exampleLabel.Text = "To Do List";
            }

            this.BindingContext = new MainViewModel();
        }

        void DeleteButtonClicked(object sender, EventArgs e)
        {
            (this.list.ItemsSource as ObservableCollection<Item>).Remove((sender as Button).BindingContext as Item);
            this.list.EndItemSwipe(true);
        }

        void DoneButtonClicked(object sender, EventArgs e)
        {
            var listItem = (sender as Button).BindingContext as Item;

            listItem.IsDone = !listItem.IsDone;
           
            this.list.EndItemSwipe(true);
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