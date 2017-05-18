using Foundation;
using System;
using UIKit;
using Xamarin.Forms.Platform.iOS;

namespace QSF.iOS
{
    public class CustomizedLabelRenderer : LabelRenderer
    {
        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == Examples.CustomLabel.IsStrikethroughProperty.PropertyName)
            {
                if ((this.Element as Examples.CustomLabel).IsStrikethrough)
                {
                    var attrString = new NSMutableAttributedString(this.Control.Text);
                    attrString.AddAttribute(
                        UIStringAttributeKey.StrikethroughStyle,
                        NSNumber.FromInt32((int)NSUnderlineStyle.Single),
                        new NSRange(0, attrString.Length)
                        );
                    this.Control.AttributedText = attrString;
                }
                else
                {
                    var attrString = new NSMutableAttributedString(this.Control.Text);
                    attrString.AddAttribute(
                        UIStringAttributeKey.StrikethroughStyle,
                        NSNumber.FromInt32((int)NSUnderlineStyle.None),
                        new NSRange(0, attrString.Length)
                        );
                    this.Control.AttributedText = attrString;
                }
            }
        }
    }
}