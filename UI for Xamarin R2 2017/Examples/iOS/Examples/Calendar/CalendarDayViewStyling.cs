using System;
using System.Collections.Generic;
using CoreGraphics;
using Foundation;
using TelerikUI;
using UIKit;

namespace Examples
{
    [Register("CalendarDayViewStyling")]
    public class CalendarDayViewStyling : CalendarDayViewViewControllerBase
    {
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var presenter = (TKCalendarDayViewPresenter)this.CalendarView.Presenter;

            presenter.TitleHidden = true;
            presenter.WeekNumbersHidden = false;
            presenter.WeekendsHidden = true;
            presenter.Style.DayNameTextEffect = TKCalendarTextEffect.Uppercase;

            presenter.Update(true);

            var dayView = presenter.DayView;

            dayView.AllDayEventsView.BackgroundColor = UIColor.FromRGB(0.2f, 0.2f, 0.2f);
            dayView.AllDayEventsView.Style.EventHeight = 25;
            dayView.AllDayEventsView.Style.MaxVisibleLines = 4;
            dayView.AllDayEventsView.Style.LabelInsets = new UIEdgeInsets(3, 3, 3, 3);

            var label = dayView.AllDayEventsView.LabelView as UILabel;
            label.TextAlignment = UITextAlignment.Center; ;
            label.Font = UIFont.SystemFontOfSize(10);
            label.TextColor = UIColor.White;

            dayView.EventsView.BackgroundColor = UIColor.Black;
            dayView.EventsView.StartTime = 8 * 3600;
            dayView.EventsView.EndTime = 20 * 3600;

            dayView.EventsView.Style.LabelTextSize = 10;
            dayView.EventsView.Style.LabelTextColor = UIColor.LightGray;
            dayView.EventsView.Style.LabelOffset = 3;
            dayView.EventsView.Style.SeparatorColor = UIColor.White;
            dayView.EventsView.Style.SeparatorLeadingOffset = 10;
            dayView.EventsView.Style.SeparatorTrailingOffset = 10;
            dayView.EventsView.Style.EventsLeadingOffset = 15;
            dayView.EventsView.Style.EventsTrailingOffset = 15;
            dayView.EventsView.Style.EventsSpacing = 2;

            dayView.EventsView.UpdateLayout();
            dayView.AllDayEventsView.UpdateLayout();

            dayView.DataSource = new DayViewDataSource();

            this.View.AddSubview(this.CalendarView);
        }

        public class DayViewDataSource : TKCalendarDayViewDataSource
        {
            public override void UpdateCell(TKCalendarDayView dayView, UICollectionViewCell cell)
            {
                var eventCell = cell as TKCalendarDayViewEventCell;
                if (eventCell != null)
                {
                    eventCell.Style.TextColor = UIColor.FromRGBA(1, 1, 1, 0.8f);
                    eventCell.Style.Transparency = 0.5f;
                    return;
                }

                var allDayCell = cell as TKCalendarDayViewAllDayEventCell;
                if (allDayCell != null)
                {
                    allDayCell.Style.TextColor = UIColor.FromRGBA(1, 1, 1, 0.8f);
                    allDayCell.Style.TextFont = UIFont.BoldSystemFontOfSize(10);
                    allDayCell.Style.BackgroundColor = UIColor.FromRGB(0.3f, 0.3f, 0.3f);
                }
            }
        }
    }


}
