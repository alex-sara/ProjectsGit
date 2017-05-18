using System;
using System.Linq;
using Xamarin.Forms;

namespace Examples
{
    public class CustomLabel : Label
    {
        public static readonly BindableProperty IsStrikethroughProperty = 
            BindableProperty.Create<CustomLabel, bool>(rv => rv.IsStrikethrough, false);

        public bool IsStrikethrough
        {
            get
            {
                return (bool)GetValue(IsStrikethroughProperty);
            }
            set
            {
                SetValue(IsStrikethroughProperty, value);

            }
        }
    }
}