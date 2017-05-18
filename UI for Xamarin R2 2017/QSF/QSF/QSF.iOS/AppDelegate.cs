using Foundation;
using UIKit;
using Xamarin.Forms;
using Telerik.XamarinForms.Input;

[assembly: ExportRenderer(typeof(Examples.CodeViewer), typeof(QSF.iOS.CodeViewerRenderer))]
[assembly: ExportRenderer(typeof(Examples.CustomLabel), typeof(QSF.iOS.CustomizedLabelRenderer))]
[assembly: ExportRenderer(typeof(RadDataForm), typeof(QSF.iOS.IOSDataFormRenderer))]

namespace QSF.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();

            UIApplication.SharedApplication.SetStatusBarHidden(true, false);
            LoadApplication(new Examples.App(double.Parse(UIScreen.MainScreen.Bounds.Width.ToString()), double.Parse(UIScreen.MainScreen.Bounds.Height.ToString())));

            return base.FinishedLaunching(app, options);
        }
    }
}
