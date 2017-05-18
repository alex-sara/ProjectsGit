using QSF.Droid.Effects;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ResolutionGroupName("QSF")]
[assembly: ExportEffect(typeof(EntryEffect), "EntryEffect")]
namespace QSF.Droid.Effects
{
    public class EntryEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            this.Control.SetBackgroundColor(Android.Graphics.Color.Transparent);
        }

        protected override void OnDetached()
        {
        }
    }
}