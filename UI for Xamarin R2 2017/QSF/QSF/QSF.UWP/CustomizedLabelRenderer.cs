using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Documents;
using Xamarin.Forms.Platform.UWP;

namespace QSF.UWP
{
    public class CustomizedLabelRenderer : LabelRenderer
    {
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == Examples.CustomLabel.IsStrikethroughProperty.PropertyName)
            {
                if ((this.Element as Examples.CustomLabel).IsStrikethrough)
                {
                    this.Control.FontStyle = Windows.UI.Text.FontStyle.Oblique;
                }
                else
                {
                    this.Control.FontStyle = Windows.UI.Text.FontStyle.Normal;
                }
            }
        }
    }
}
