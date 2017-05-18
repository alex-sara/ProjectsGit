using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.XamarinForms.Common.DataAnnotations;

namespace Examples.DataForm.Reservations
{
    public class SectionToStringConverter : IPropertyConverter
    {
        public object Convert(object value)
        {
            switch ((Section)value)
            {
                case Section.Patio:
                    return "Patio";
                case Section.FirstFloor:
                    return "FirstFloor";
                case Section.SecondFloor:
                    return "SecondFloor";
                default:
                    return string.Empty;
            }
        }

        public object ConvertBack(object value)
        {
            switch ((string)value)
            {
                case "Patio":
                    return Section.Patio;

                case "FirstFloor":
                    return Section.FirstFloor;

                case "SecondFloor":
                    return Section.SecondFloor;

                default:
                    return Section.Patio;
            }
        }
    }
}
