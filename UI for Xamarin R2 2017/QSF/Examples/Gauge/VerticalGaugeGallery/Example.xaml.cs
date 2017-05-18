using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using Xamarin.Forms;

namespace Examples.Gauge.VerticalGaugeGallery
{
    public partial class Example : ContentPage
    {
        public Example()
        {
            InitializeComponent();
            
            List<GalleryItem> galleryItems = new List<GalleryItem>
            {
                new GalleryItem("template9", "gauge_gallery_item_9.png"),
                new GalleryItem("template10", "gauge_gallery_item_10.png"),
            };
            
            this.BindingContext = galleryItems;
            this.galleryItemsList.SelectedItems.Add(galleryItems[0]);
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

        private void SelectedItemsCollectionChanged(object sender, NotifyCollectionChangedEventArgs args)
        {
            GalleryItem galleryItem = this.galleryItemsList.SelectedItems.LastOrDefault() as GalleryItem;
            if (galleryItem != null)
            {
                object template;
                this.Resources.TryGetValue(galleryItem.Key, out template);
                this.ExamplePresenter.ContentTemplate = template as DataTemplate;
            }
        }

        protected override bool OnBackButtonPressed()
        {
            Navigation.PopAsync();
            return true;
        }
    }
}