using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace SDKBrowser.WinRT
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            LoadApplication(new SDKBrowser.App());

            this.Tapped += MainPage_Tapped;
        }

        private void MainPage_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (this.BottomAppBar != null)
            {
                this.BottomAppBar.IsSticky = true;
                this.BottomAppBar.Opened += BottomAppBar_Opened;
                var commands = ((CommandBar)this.BottomAppBar).PrimaryCommands.Count;
                var commands2 = ((CommandBar)this.BottomAppBar).SecondaryCommands.Count;
            }
        }

        private void BottomAppBar_Opened(object sender, object e)
        {
            Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                var button = Telerik.Core.ElementTreeHelper.FindVisualDescendant<AppBarButton>(sender as DependencyObject);
            });
        }
    }
}
