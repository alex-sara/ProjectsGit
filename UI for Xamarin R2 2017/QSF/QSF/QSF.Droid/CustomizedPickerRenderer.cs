using System;
using System.Linq;
using Xamarin.Forms.Platform.Android;

namespace QSF.Droid
{
    public class CustomizedPickerRenderer : PickerRenderer
    {
        public CustomizedPickerRenderer()
            : base()
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Picker> e)
        {
            base.OnElementChanged(e);

            this.Control.SetTextColor(new Android.Graphics.Color(93, 86, 83));
        }
    }
}