using System;
using System.Runtime.CompilerServices;
using Telerik.XamarinForms.DataControls.ListView;
using Xamarin.Forms;

namespace Examples.TabView.RestaurantMenu
{
    public partial class ExploreItemsView : ContentView
    {
        public static readonly BindableProperty IsSelectableProperty = 
            BindableProperty.Create("IsSelectable", typeof(bool), typeof(ExploreItemsView), false);
        
        public ExploreItemsView()
        {
            InitializeComponent();
            this.listViewImages.ItemTapped += ListViewImages_ItemTapped;
            this.UpdateListViewItemTemplate();
        }

        public bool IsSelectable
        {
            get
            {
                return (bool)this.GetValue(IsSelectableProperty);
            }
            set
            {
                this.SetValue(IsSelectableProperty, value);
            }
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == IsSelectableProperty.PropertyName)
            {
                this.UpdateListViewItemTemplate();
            }
        }

        private void ListViewImages_ItemTapped(object sender, ItemTapEventArgs e)
        {
            if (this.IsSelectable)
            {
                RestaurantMenuItem item = (RestaurantMenuItem)e.Item;
                item.IsSaved ^= true;
            }
        }

        private void ListViewImages_SizeChanged(object sender, System.EventArgs e)
        {
            if (Device.RuntimePlatform == Device.Android)
            {
                return;
            }

            ListViewGridLayout listViewLayout = (ListViewGridLayout)this.listViewImages.LayoutDefinition;
            int desiredColumnsCount = listViewLayout.SpanCount;
            double spacing = (desiredColumnsCount - 1) * listViewLayout.HorizontalItemSpacing;
            double availableWidth = this.listViewImages.Width - spacing;
            double itemWidth = availableWidth / desiredColumnsCount;
            listViewLayout.ItemLength = 1.5 * itemWidth;
        }

        private void UpdateListViewItemTemplate()
        {
            object template = this.IsSelectable ? this.Resources["itemTemplateWithSelection"] : this.Resources["itemTemplate"];
            this.listViewImages.ItemTemplate = (DataTemplate)template;
        }
    }
}
