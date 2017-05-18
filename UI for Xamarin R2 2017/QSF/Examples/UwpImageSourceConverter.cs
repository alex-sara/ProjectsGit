using System;
using System.Globalization;
using Xamarin.Forms;

namespace Examples
{
    public class UwpImageSourceConverter : IValueConverter
    {
        public static object Convert(object value)
        {
            if (Device.OS == TargetPlatform.Windows)
            {
                var imgSrc = value as FileImageSource;
                if (imgSrc != null)
                {
                    return @"Assets\" + imgSrc.File;
                }
                return @"Assets\" + value;
            }

            return value;
        }
             
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Convert(value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}