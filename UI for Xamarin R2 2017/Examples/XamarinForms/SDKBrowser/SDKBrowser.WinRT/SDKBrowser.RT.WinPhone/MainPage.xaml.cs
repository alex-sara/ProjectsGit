using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Navigation;

namespace SDKBrowser.WinRT
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            LoadApplication(new SDKBrowser.App());
            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var appView = ApplicationView.GetForCurrentView();
            appView.SetDesiredBoundsMode(ApplicationViewBoundsMode.UseVisible);
            var top = appView.VisibleBounds.Top - Window.Current.Bounds.Top;
            this.Margin = new Thickness(this.Margin.Left, top, this.Margin.Right, this.Margin.Bottom);
        }
    }
}
