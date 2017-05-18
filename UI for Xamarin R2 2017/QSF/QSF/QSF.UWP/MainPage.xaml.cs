using Windows.Foundation;
using Windows.System.Profile;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(Examples.CodeViewer), typeof(QSF.UWP.CodeViewerRenderer))]
[assembly: ExportRenderer(typeof(Examples.CustomLabel), typeof(QSF.UWP.CustomizedLabelRenderer))]

namespace QSF.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            if (Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.UI.ViewManagement.StatusBar"))
            {
                Windows.UI.ViewManagement.StatusBar.GetForCurrentView().BackgroundColor = Windows.UI.Colors.Black;
                Windows.UI.ViewManagement.StatusBar.GetForCurrentView().BackgroundOpacity = 1;
                Windows.UI.ViewManagement.StatusBar.GetForCurrentView().ForegroundColor = Windows.UI.Colors.White;
            }

            this.InitializeComponent();

            Rect bounds;

            if (AnalyticsInfo.VersionInfo.DeviceFamily == "Windows.Mobile")
            {
                bounds = Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().VisibleBounds;
            }
            else
            {
                bounds = Windows.UI.Xaml.Window.Current.Bounds;
            }

            LoadApplication(new Examples.App(bounds.Width, bounds.Height));
        }
    }
}