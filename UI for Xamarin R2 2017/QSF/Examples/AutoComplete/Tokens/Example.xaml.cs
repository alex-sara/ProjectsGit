using Telerik.XamarinForms.DataControls.ListView;
using Telerik.XamarinForms.Input;
using Xamarin.Forms;

namespace Examples.AutoComplete.Tokens
{
    public partial class Example : ContentPage
    {
        public Example()
        {
            InitializeComponent();

            BindableProperty property = Device.OnPlatform<BindableProperty>(RadAutoComplete.TokensProperty, RadAutoComplete.TokensProperty, RadAutoComplete.TextProperty);
            StringArrayToStringConverter converter = Device.OnPlatform<StringArrayToStringConverter>(null, null, new StringArrayToStringConverter());
            Binding binding = new Binding(nameof(TokensViewModel.Tokens), BindingMode.OneWayToSource, converter);
            this.autoComplete.SetBinding(property, binding);
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

        private void ListViewImages_SizeChanged(object sender, System.EventArgs e)
        {
            ListViewGridLayout listViewLayout = (ListViewGridLayout)this.listViewImages.LayoutDefinition;
            int desiredColumnsCount = listViewLayout.SpanCount;
            double spacing = (desiredColumnsCount - 1) * listViewLayout.HorizontalItemSpacing;
            double availableWidth = this.listViewImages.Width - spacing;
            double itemWidth = availableWidth / desiredColumnsCount;
            listViewLayout.ItemLength = itemWidth;
        }
    }
}