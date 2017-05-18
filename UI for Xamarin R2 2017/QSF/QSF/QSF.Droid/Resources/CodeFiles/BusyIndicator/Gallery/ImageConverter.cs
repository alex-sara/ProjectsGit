using System;
using System.Globalization;
using Telerik.XamarinForms.Primitives;
using Xamarin.Forms;

namespace Examples.BusyIndicator.Gallery
{
    public class ImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string format = parameter as string;
            if (format == null || value == null || !(value is AnimationType))
            {
                return null;
            }

            AnimationType animation = (AnimationType)value;

            if (Device.RuntimePlatform == Device.Windows)
            {
                format = "Assets/" + format;
            }

            return string.Format(format, animation.ToString().ToLower());
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
