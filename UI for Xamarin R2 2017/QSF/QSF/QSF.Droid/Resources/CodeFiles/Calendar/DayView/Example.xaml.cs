using Telerik.XamarinForms.Input;
using Xamarin.Forms;
using System;
using System.Globalization;

namespace Examples.Calendar.DayView
{
    public partial class Example : ContentPage
    {
        public Example()
        {
            InitializeComponent();

            this.BindingContext = new ExampleViewModel();

            var today = new TapGestureRecognizer();
            today.Tapped += DisplayToday;
            this.todayLabel.GestureRecognizers.Add(today);
        }

        protected override bool OnBackButtonPressed()
        {
            Navigation.PopAsync();
            return true;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var rootGrid = this.Content as Grid;
            if (Helpers.ExampleHelper.SetImageButtonOnTop(ref rootGrid))
            {
                this.Content = rootGrid;
            }
        }

        private void CalendarLoaded(object sender, EventArgs e)
        {
            (sender as RadCalendar).TrySetViewMode(CalendarViewMode.Day, false);
        }

        private void DisplayToday(object sender, EventArgs e)
        {
            calendar.DisplayDate = DateTime.Today;
        }
    }

    public class DayViewCalendar : RadCalendar
    {
    }

    public class DayeToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var date = value as DateTime?;
            if (date != null)
            {
                return string.Format("{0:MMMMM yyyy}", date);
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
