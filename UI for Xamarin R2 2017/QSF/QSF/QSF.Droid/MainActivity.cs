using Android.App;
using Android.Content.PM;
using Android.OS;
using Telerik.XamarinForms.Input;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: Xamarin.Forms.ExportRenderer(typeof(Image), typeof(Telerik.XamarinForms.Common.Android.AndroidImageRenderer))]
[assembly: Xamarin.Forms.ExportRenderer(typeof(Examples.CodeViewer), typeof(QSF.Droid.CodeViewerRenderer))]
[assembly: Xamarin.Forms.ExportRenderer(typeof(Examples.CustomLabel), typeof(QSF.Droid.CustomizedLabelRenderer))]
[assembly: Xamarin.Forms.ExportRenderer(typeof(Picker), typeof(QSF.Droid.CustomizedPickerRenderer))]
[assembly: ExportRenderer(typeof(RadDataForm), typeof(QSF.Droid.CustomDataFormRenderer))]

namespace QSF.Droid
{
    [Activity(Theme = "@style/Theme.AppCompat.NoActionBar", Label = "QSF", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            this.SetTheme(Resource.Style.Theme_Design_Light);
            global::Xamarin.Forms.Forms.Init(this, bundle);
            var metrics = Resources.DisplayMetrics;
            LoadApplication(new Examples.App(metrics.WidthPixels, metrics.HeightPixels, metrics.Density));
        }
    }
}