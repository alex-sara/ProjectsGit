
using System.Collections.Generic;
using Xamarin.Forms;

namespace Examples.SegmentedControl.FirstLook
{
    public partial class Example : ContentPage
    {
        private List<MenuItem> dinnerMenu = new List<MenuItem>() { new MenuItem("Filet Mignon", 26), new MenuItem("Sirloin Steak", 28), new MenuItem("Fried Chicken", 21) };
        private List<MenuItem> drinksMenu = new List<MenuItem>() { new MenuItem("Coca-Cola", 2), new MenuItem("Mineral Water", 1.5), new MenuItem("Orange Juice", 3) };
        private List<MenuItem> snacksMenu = new List<MenuItem>() { new MenuItem("Crackers", 9), new MenuItem("Cheese Burger", 12), new MenuItem("Energy Bar", 5) };
        private List<List<MenuItem>> menu;
        public Example()
        {
            InitializeComponent();

            this.menu = new List<List<MenuItem>>() { dinnerMenu, drinksMenu, snacksMenu };

            if (!Device.RuntimePlatform.Equals(Device.Windows))
            {
                this.menuSegment.HeightRequest = 85;
            }
            else
            {
                this.menuSegment.HeightRequest = 85;
            }

            this.menuSegment.ItemsSource = dinnerMenu;
            string imageFolder = Device.OnPlatform<string>("", "", "Assets/");
            string imageSuffix = Device.OnPlatform<string>("_small.png", ".png", "_small.png");
            var textColor = Color.FromRgb(251, 176, 59);
            var backgroundColor = Color.FromRgb(10, 144, 208);

            this.menuSegment.SelectionChanged += MenuSegment_SelectionChanged;
            this.menuSegment.ItemsSource = new List<ImageSource>() { ImageSource.FromFile(imageFolder + "segment_dinner.png"), ImageSource.FromFile(imageFolder + "segment_drinks.png"), ImageSource.FromFile(imageFolder + "segment_snack.png") };
            this.menuSegment.SelectedSegmentBackgroundColor = backgroundColor;
            this.menuSegment.SelectedSegmentTextColor = textColor;
            this.menuSegment.SelectedIndex = 0;

            this.selectionSegment.ItemsSource = new List<string>() { "Dinner", "Drink", "Snacks" };
            this.selectionSegment.SelectedIndex = 0;
            this.selectionSegment.SegmentBackgroundColor = Color.White;
            this.selectionSegment.SegmentTextColor = textColor;
            this.selectionSegment.SelectedSegmentTextColor = textColor;
            this.selectionSegment.SelectedSegmentBackgroundColor = backgroundColor;

            this.imageSegment.ItemsSource = new List<ImageSource>() { ImageSource.FromFile(imageFolder + "segment_dinner" + imageSuffix), ImageSource.FromFile(imageFolder + "segment_drinks" + imageSuffix), ImageSource.FromFile(imageFolder + "segment_snack" + imageSuffix) };
            this.imageSegment.SelectedSegmentBackgroundColor = backgroundColor;
            this.imageSegment.SelectedSegmentTextColor = textColor;
            this.imageSegment.SelectedIndex = 0;

            this.disabledSegment.ItemsSource = new List<string>() { "Dinner", "Drinks", "Snacks" };
            this.disabledSegment.SetSegmentEnabled(2, false);
            this.disabledSegment.SegmentBackgroundColor = Color.White;
            this.disabledSegment.SegmentTextColor = textColor;
            this.disabledSegment.SelectedSegmentBackgroundColor = backgroundColor;
            this.disabledSegment.SelectedSegmentTextColor = textColor;
            this.disabledSegment.DisabledSegmentTextColor = Color.FromRgb(241, 203, 144);
        }

        private void MenuSegment_SelectionChanged(object sender, Telerik.XamarinForms.Common.ValueChangedEventArgs<int> e)
        {
            if (e.NewValue >= 0 && e.NewValue < this.menu.Count)
            {
                this.BindingContext = this.menu[e.NewValue];
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
    }
}
