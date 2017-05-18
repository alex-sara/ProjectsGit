using System.Collections.Specialized;
using System.Linq;
using Xamarin.Forms;

namespace Examples.Chart.LineSeries
{
    public partial class Example : ContentPage
    {
        public Example()
        {
            InitializeComponent();
            var vm = new MainViewModel();
            this.BindingContext = vm;
            this.galleryItemsList.SelectedItems.Add(vm.LineLayouts[0]);
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