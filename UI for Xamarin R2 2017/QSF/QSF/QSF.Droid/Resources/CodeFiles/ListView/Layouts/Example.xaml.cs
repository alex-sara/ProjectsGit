using Examples.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.XamarinForms.DataControls.ListView;
using Xamarin.Forms;

namespace Examples.ListView.Layouts
{
    public partial class Example : ContentPage
    {
        public Example()
        {
            InitializeComponent();

            var vm = new MainViewModel();
            this.BindingContext = vm;

            this.availableLayoutsList.SelectedItems.Add(vm.LayoutOptions[1]);

            this.list.LayoutDefinition = null;
            this.list.LayoutDefinition = new ListViewLinearLayout() { GroupHeaderLength = 34, HorizontalItemSpacing = 0, VerticalItemSpacing = 0, Orientation = Telerik.XamarinForms.Common.Orientation.Vertical, ItemLength = 190 };
        }

        void LayoutOptionList_SelectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                if (e.NewItems[0] == (this.list.BindingContext as MainViewModel).LayoutOptions[0])
                {
                    this.list.LayoutDefinition = null;
                    this.list.LayoutDefinition = new ListViewGridLayout() { GroupHeaderLength = 34, HorizontalItemSpacing = 2, VerticalItemSpacing = 2, Orientation = Telerik.XamarinForms.Common.Orientation.Vertical, SpanCount = 2, ItemLength = 190 };
                }
                else
                {
                    this.list.LayoutDefinition = null;
                    this.list.LayoutDefinition = new ListViewLinearLayout() { GroupHeaderLength = 34, HorizontalItemSpacing = 0, VerticalItemSpacing = 0, Orientation = Telerik.XamarinForms.Common.Orientation.Vertical, ItemLength = 190 };
                }
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

            this.availableLayoutsList.SelectionChanged += LayoutOptionList_SelectionChanged;
        }

        protected override bool OnBackButtonPressed()
        {
            Navigation.PopAsync();
            return true;
        }
    }
}