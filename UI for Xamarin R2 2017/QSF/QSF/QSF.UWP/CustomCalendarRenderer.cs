using Telerik.XamarinForms.Input;
using Xamarin.Forms.Platform.UWP;

namespace QSF.UWP
{
    public class CustomCalendarRenderer : Telerik.XamarinForms.InputRenderer.UWP.CalendarRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<RadCalendar> e)
        {
            base.OnElementChanged(e);

            if (this.Control != null)
            {
                this.Control.AppointmentTemplateSelector = new CalendarAppointmentTemplateSelector();
            }
        }
    }
}
