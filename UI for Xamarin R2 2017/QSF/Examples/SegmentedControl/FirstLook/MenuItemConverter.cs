using System;
using System.Collections.Generic;
using System.Globalization;
using Xamarin.Forms;

namespace Examples.SegmentedControl.FirstLook
{
    public class MenuItemConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var param = parameter.ToString();
            var menu = value as List<MenuItem>;
            if (!String.IsNullOrEmpty(param) && value != null)
            {
                switch(param)
                {
                    case "price1":
                        return this.ToPrice(menu[0].Price);
                    case "price2":
                        return this.ToPrice(menu[1].Price);
                    case "price3":
                        return this.ToPrice(menu[2].Price);
                    case "menu1":
                        return menu[0].Name;
                    case "menu2":
                        return menu[1].Name;
                    case "menu3":
                        return menu[2].Name;
                    default:
                        return String.Empty;

                }
            }

            return String.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
        
        private string ToPrice(object value)
        {
            return String.Format("${0}", value);
        }
    }
}
