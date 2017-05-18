using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using Xamarin.Forms;

namespace Examples.Gauge.RadialGaugeGallery
{
    public partial class Example : ContentPage
    {
        public Example()
        {
            InitializeComponent();
            
            List<GalleryItem> galleryItems = new List<GalleryItem>
            {
                new GalleryItem("template1", "gauge_gallery_item_1.png"),
                new GalleryItem("template2", "gauge_gallery_item_2.png"),
                new GalleryItem("template3", "gauge_gallery_item_3.png"),
                new GalleryItem("template4", "gauge_gallery_item_4.png"),
                new GalleryItem("template5", "gauge_gallery_item_5.png"),
                new GalleryItem("template6", "gauge_gallery_item_6.png"),
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