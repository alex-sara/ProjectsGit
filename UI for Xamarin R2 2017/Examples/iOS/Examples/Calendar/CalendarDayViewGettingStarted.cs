using System;
using System.Collections.Generic;
using CoreGraphics;
using Foundation;
using TelerikUI;
using UIKit;

namespace Examples
{
    [Register("CalendarDayViewGettingStarted")]
    public class CalendarDayViewGettingStarted : CalendarDayViewViewControllerBase
    {
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var presenter = (TKCalendarDayViewPresenter)this.CalendarView.Presenter;
            var dayView = presenter.DayView;

            dayView.EventsView.StartTime = 8 * 3600;
            dayView.EventsView.EndTime = 20 * 3600;

            dayView.EventsView.UpdateLayout();
            dayView.AllDayEventsView.UpdateLayout();

            dayView.Delegate = new DayViewDelegate(this);

            this.View.AddSubview(this.CalendarView);
        }

        public class DayViewDelegate : TKCalendarDayViewDelegate
        {
            private CalendarDayViewGettingStarted viewController;

            public DayViewDelegate(CalendarDayViewGettingStarted viewController)
            {
                this.viewController = viewController;
            }

            public override void DidSelectEvent(TKCalendarDayView dayView, TKCalendarEventProtocol ev)
            {
                var e = (TKCalendarEvent)ev;
                var alert = UIAlertController.Create(e.Title, e.Detail, UIAlertControllerStyle.Alert);
                var action = UIAlertAction.Create("OK", UIAlertActionStyle.Default, (obj) => alert.DismissViewController(true, null));
                alert.AddAction(action);
                viewController.PresentViewController(alert, true, null);
            }
        }
    }
}
