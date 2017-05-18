using Android.Graphics;
using Android.Util;
using Android.Views;
using Com.Telerik.Widget.Calendar;
using Com.Telerik.Widget.Calendar.Dayview;
using Com.Telerik.Widget.Calendar.Decorations;
using Com.Telerik.Widget.Calendar.Events;
using Examples.Calendar.DayView;
using QSF.Droid;
using Telerik.XamarinForms.InputRenderer.Android;
using Xamarin.Forms.Platform.Android;

[assembly: Xamarin.Forms.ExportRenderer(typeof(DayViewCalendar), typeof(DayViewCalendarRenderer))]

namespace QSF.Droid
{
    public class DayViewCalendarRenderer : CalendarRenderer
    {
        public override bool TrySetViewMode(Telerik.XamarinForms.Input.CalendarViewMode view, bool isAnimated)
        {
            bool hasNavigated = base.TrySetViewMode(view, isAnimated);
            var background = Color.White;

            if (view == Telerik.XamarinForms.Input.CalendarViewMode.Day && hasNavigated && Control.DayView != null)
            {
                Control.DayView.EventDayViewAdapter = new MyDayViewEventCustomAdapter();

                Control.DayView.DayEventsViewStyle.StartTime = 3600 * 8 * 1000;
                Control.DayView.DayEventsViewStyle.EndTime = 3600 * 22 * 1000;
                Control.DayView.DayEventsViewStyle.EndTime = 3600 * 22 * 1000;
                Control.DayView.DayEventsViewStyle.TimeLinesColor = Color.Transparent;

                Control.DayView.AllDayEventsViewStyle.AllDayTextIsVisible = false;

                Control.ShowGridLines = false;
                Control.CellDecorator = new CustomCircularCellDecorator(Control, new Color(48, 112, 182)) { Stroked = false, Scale = 0.8f };
                Control.ShowTitle = false;
                Control.WeekHeightRequest = (int)Xamarin.Forms.Forms.Context.ToPixels(60);

                var adapter = Control.Adapter;

                adapter.TodayCellBorderColor = Color.Transparent;

                adapter.SetDateCellBackgroundColor(background, background);
                adapter.TodayCellBackgroundColor = background;
                adapter.SelectedCellBackgroundColor = background;
                adapter.DayNameBackgroundColor = background;

                adapter.SelectedCellTextColor = Color.White;
                adapter.TodayCellSelectedTextColor = Color.White;
                adapter.SetDateTextColor(Color.Black, Color.DarkGray);

                adapter.DateTextSize = (int)Xamarin.Forms.Forms.Context.ToPixels(24);

                adapter.DateTextPosition = CalendarElement.Center;
                adapter.DayNameTextPosition = CalendarElement.Center;
                adapter.CapitalizeDayNames = true;
            }

            return hasNavigated;
        }
    }

    public class MyDayViewEventCustomAdapter : EventDayViewAdapter
    {
        public MyDayViewEventCustomAdapter() : base(Xamarin.Forms.Forms.Context)
        {
        }

        public override View GetView(Event e, long date)
        {
            var view = base.GetView(e, date);

            if (e.AllDay)
            {
                var eventView = view as AllDayEventView;
                eventView.SetBackgroundColor(new Color(218, 238, 251));
                eventView.TextColor = new Color(66, 77, 130);
            }

            return view;
        }
    }

    public class CustomCircularCellDecorator : CircularCellDecorator
    {
        private Color color;

        public CustomCircularCellDecorator(RadCalendarView owner, Color color) : base(owner)
        {
            this.color = color;
        }

        protected override void RenderDecorationForCell(Canvas canvas, CalendarCell cell)
        {
            this.Paint.Color = this.color;
            base.RenderDecorationForCell(canvas, cell);
        }
    }
}