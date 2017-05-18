using System;
using System.Linq;
using Xamarin.Forms.Platform.Android;
using Examples;

namespace QSF.Droid
{
    public class CustomizedLabelRenderer : LabelRenderer
    {
        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == CustomLabel.IsStrikethroughProperty.PropertyName)
            {
                if ((this.Element as CustomLabel).IsStrikethrough)
                {
                    this.Control.PaintFlags |= Android.Graphics.PaintFlags.StrikeThruText;
                }
                else
                {
                    this.Control.PaintFlags &= ~Android.Graphics.PaintFlags.StrikeThruText;
                }
            }
        }
    }
}