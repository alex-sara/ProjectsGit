using Telerik.UI.Xaml.Controls.Input.Calendar;
using Windows.UI.Xaml;

namespace QSF.UWP
{
    public class CalendarAppointmentTemplateSelector : AppointmentTemplateSelector
    {
        private readonly DataTemplate dataTemplate = App.Current.Resources["CallendarAppointmentTemplate"] as DataTemplate;

        protected override DataTemplate SelectTemplateCore(CalendarAppointmentInfo context, CalendarCellModel cell)
        {
            return dataTemplate;
        }
    }
}