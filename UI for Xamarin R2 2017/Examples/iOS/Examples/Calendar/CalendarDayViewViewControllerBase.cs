using System;
using System.Collections.Generic;
using Foundation;
using TelerikUI;
using UIKit;
using System.Linq;

namespace Examples
{
    public class CalendarDayViewViewControllerBase : XamarinExampleViewController
    {
        static string[] locations = { "Sofia", "London", "Paris", "New York", "San Francisco", "Home" };
        static string[] titles = { "Meeting with Jack", "Lunch with Peter", "Planning meeting", "Go shopping", "Very important meeting", "Another meeting", "Lorem ipsum" };
        static string[] allDayTitles = { "Hackathon", "Party", "Birthday", "Vacation" };

        static UIColor[] colors =  {
            new UIColor (88f / 255f, 86f / 255f, 214f / 255f, 1f),
            new UIColor (255f / 255f, 149f / 255f, 3f / 255f, 1f),
            new UIColor (255f / 255, 45f / 255f, 85f / 255f, 1f),
            new UIColor (76f / 255f, 217f / 255f, 100f / 255f, 1f),
            new UIColor (255f / 255f, 204f / 255f, 3f / 255f, 1f)
        };

        static Random rand = new Random();
        static NSDate displayDate = NSCalendar.CurrentCalendar.DateFromComponents(new NSDateComponents { Year = 2017, Month = 3, Day = 7 });

        public CalendarDayViewViewControllerBase()
        {
            CalendarSource = new CalendarDataSource(CreateEvents());

            this.CalendarView = new TKCalendar
            {
                AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleHeight,
                Calendar = new NSCalendar(NSCalendarType.Gregorian),
                DataSource = CalendarSource,
                ViewMode = TKCalendarViewMode.Day
            };

            CalendarView.NavigateToDate(displayDate, false);
        }

        public CalendarDataSource CalendarSource { get; }

        public TKCalendar CalendarView { get; }


        public override void ViewDidLayoutSubviews()
        {
            base.ViewDidLayoutSubviews();
            this.CalendarView.Frame = this.View.Bounds;
        }

        protected virtual TKCalendarEvent[] CreateEvents()
        {
            var eventsList = new List<TKCalendarEvent>();

            // all day
            var calEvent = GetEvent(true, UIColor.DarkGray);
            calEvent.StartDate = DateWithOffset(1);
            calEvent.EndDate = DateWithOffset(2);
            eventsList.Add(calEvent);

            calEvent = GetEvent(true, UIColor.DarkGray);
            calEvent.StartDate = DateWithOffset(2);
            calEvent.EndDate = DateWithOffset(3);
            eventsList.Add(calEvent);

            calEvent = GetEvent(true);
            calEvent.StartDate = DateWithOffset(2);
            calEvent.EndDate = DateWithOffset(2);
            eventsList.Add(calEvent);

            for (int i = 0; i < 5; i++)
            {
                calEvent = GetEvent(true, UIColor.DarkGray);
                calEvent.StartDate = DateWithOffset(-1);
                calEvent.EndDate = DateWithOffset(-1);
                eventsList.Add(calEvent);
            }

            calEvent = GetEvent(true);
            calEvent.StartDate = DateWithOffset(0);
            calEvent.EndDate = DateWithOffset(0);
            eventsList.Add(calEvent);

            // today
            var dayOffset = 0;

            calEvent = GetEvent();
            calEvent.StartDate = DateWithOffset(dayOffset, 12);
            calEvent.EndDate = DateWithOffset(dayOffset, 13, 30);
            eventsList.Add(calEvent);

            calEvent = GetEvent();
            calEvent.StartDate = DateWithOffset(dayOffset, 14);
            calEvent.EndDate = DateWithOffset(dayOffset, 16);
            eventsList.Add(calEvent);

            calEvent = GetEvent();
            calEvent.StartDate = DateWithOffset(dayOffset, 14);
            calEvent.EndDate = DateWithOffset(dayOffset, 15, 30);
            eventsList.Add(calEvent);

            calEvent = GetEvent();
            calEvent.StartDate = DateWithOffset(dayOffset, 16);
            calEvent.EndDate = DateWithOffset(dayOffset, 17);
            eventsList.Add(calEvent);


            calEvent = GetEvent();
            calEvent.StartDate = DateWithOffset(dayOffset, 16, 20);
            calEvent.EndDate = DateWithOffset(dayOffset, 17, 30);
            eventsList.Add(calEvent);


            calEvent = GetEvent();
            calEvent.StartDate = DateWithOffset(dayOffset, 16);
            calEvent.EndDate = DateWithOffset(dayOffset, 17, 15);
            eventsList.Add(calEvent);


            calEvent = GetEvent();
            calEvent.StartDate = DateWithOffset(dayOffset, 17, 15);
            calEvent.EndDate = DateWithOffset(dayOffset, 18);
            eventsList.Add(calEvent);

            calEvent = GetEvent();
            calEvent.StartDate = DateWithOffset(dayOffset, 10);
            calEvent.EndDate = DateWithOffset(dayOffset, 11, 30);
            eventsList.Add(calEvent);

            // tomorrow
            dayOffset = 1;

            calEvent = GetEvent();
            calEvent.StartDate = DateWithOffset(dayOffset, 12);
            calEvent.EndDate = DateWithOffset(dayOffset, 13);
            eventsList.Add(calEvent);

            calEvent = GetEvent();
            calEvent.StartDate = DateWithOffset(dayOffset, 11);
            calEvent.EndDate = DateWithOffset(dayOffset, 11, 30);
            eventsList.Add(calEvent);

            calEvent = GetEvent();
            calEvent.StartDate = DateWithOffset(dayOffset, 12, 45);
            calEvent.EndDate = DateWithOffset(dayOffset, 13, 15);
            eventsList.Add(calEvent);

            calEvent = GetEvent();
            calEvent.StartDate = DateWithOffset(dayOffset, 16, 10);
            calEvent.EndDate = DateWithOffset(dayOffset, 16, 20);
            eventsList.Add(calEvent);

            calEvent = GetEvent();
            calEvent.StartDate = DateWithOffset(dayOffset, 17, 15);
            calEvent.EndDate = DateWithOffset(dayOffset, 18);
            eventsList.Add(calEvent);

            calEvent = GetEvent();
            calEvent.StartDate = DateWithOffset(dayOffset, 10);
            calEvent.EndDate = DateWithOffset(dayOffset, 11, 30);
            eventsList.Add(calEvent);

            return eventsList.ToArray();
        }

        public class CalendarDataSource : TKCalendarDataSource
        {
            TKCalendarEvent[] events;

            public CalendarDataSource(TKCalendarEvent[] events)
            {
                this.events = events;
            }

            public override TKCalendarEventProtocol[] EventsForDate(TKCalendar calendar, NSDate date)
            {
                NSDateComponents components = calendar.Calendar.Components(NSCalendarUnit.Year | NSCalendarUnit.Month | NSCalendarUnit.Day, date);
                components.Hour = 23;
                components.Minute = 59;
                components.Second = 59;
                NSDate endDate = calendar.Calendar.DateFromComponents(components);

                return events.Where(ev =>
                                    ev.StartDate.SecondsSinceReferenceDate <= endDate.SecondsSinceReferenceDate &&
                                    ev.EndDate.SecondsSinceReferenceDate >= date.SecondsSinceReferenceDate
                                   ).ToArray();
            }
        }

        public static TKCalendarEvent GetEvent(bool allDay = false, UIColor color = null)
        {
            return new TKCalendarEvent
            {
                Detail = locations[rand.Next(locations.Length)],
                EventColor = color ?? colors[rand.Next(colors.Length)],
                AllDay = allDay,
                Title = allDay ? allDayTitles[rand.Next(allDayTitles.Length)] : titles[rand.Next(titles.Length)]
            };
        }

        public static NSDate DateWithOffset(int days, int hours = 0, int munutes = 0)
        {
            NSCalendar calendar = NSCalendar.CurrentCalendar;
            NSDateComponents components = new NSDateComponents { Day = days, Hour = hours, Minute = munutes };
            return calendar.DateByAddingComponents(components, displayDate, NSCalendarOptions.None);
        }

        public static NSDate Today()
        {
            NSCalendar calendar = NSCalendar.CurrentCalendar;
            return calendar.DateFromComponents(calendar.Components(NSCalendarUnit.Year | NSCalendarUnit.Month | NSCalendarUnit.Day, NSDate.Now));
        }
    }
}