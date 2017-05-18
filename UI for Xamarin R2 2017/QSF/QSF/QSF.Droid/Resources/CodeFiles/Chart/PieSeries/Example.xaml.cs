using System.Collections.Specialized;
using System.Linq;
using Xamarin.Forms;

namespace Examples.Chart.PieSeries
{
    public partial class Example : ContentPage
    {
        public Example()
        {
            InitializeComponent();
            MainViewModel vm;
            this.BindingContext =vm= new MainViewModel();
            this.galleryItemsList.SelectedItems.Add(vm.PieLayouts[0]);

            if (Device.OS == TargetPlatform.Windows)
            {
                this.legendBoxView60.BackgroundColor = Color.FromHex("1E98E4");
                this.legendBoxView40.BackgroundColor = Color.FromHex("FFC500");
                this.legendBoxView30.BackgroundColor = Color.FromHex("1E98E4");
                this.legendBoxView302.BackgroundColor = Color.FromHex("FFC500");
                this.legendBoxView402.BackgroundColor = Color.FromHex("FF2A00");
            }
            else
            {
                this.legendBoxView60.BackgroundColor = Color.FromHex("4FB6E7");
                this.legendBoxView40.BackgroundColor = Color.FromHex("A666CE");
                this.legendBoxView30.BackgroundColor = Color.FromHex("4FB6E7");
                this.legendBoxView302.BackgroundColor = Color.FromHex("A666CE");
                this.legendBoxView402.BackgroundColor = Color.FromHex("9DCC00");
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

                if (galleryItem.Key.Equals("Pie"))
                {
                    this.twoPoints.IsVisible = true;
                    this.threePoints.IsVisible = false;
                }
                else
                {
                    this.twoPoints.IsVisible = false;
                    this.threePoints.IsVisible = true;
                }
            }
        }

        protected override bool OnBackButtonPressed()
        {
            Navigation.PopAsync();
            return true;
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
    }
}