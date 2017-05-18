using System;
using System.Collections.Generic;
using CoreGraphics;
using Foundation;
using TelerikUI;
using UIKit;
using System.Linq;

namespace Examples
{
    [Register("CalendarDayViewCustomization")]
    public class CalendarDayViewCustomization : CalendarDayViewViewControllerBase
    {
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var presenter = (TKCalendarDayViewPresenter)this.CalendarView.Presenter;
            var dayView = presenter.DayView;

            dayView.EventsView.StartTime = 8 * 3600;
            dayView.EventsView.EndTime = 20 * 3600;

            dayView.EventsView.Style.EventsSpacing = 0;

            dayView.EventsView.RegisterClassForCell(typeof(DayViewCustomCell), DayViewCustomCell.Identifier);

            dayView.EventsView.UpdateLayout();
            dayView.AllDayEventsView.UpdateLayout();

            dayView.DataSource = new DayViewDataSource();

            this.View.AddSubview(this.CalendarView);
        }

        public class DayViewCustomCell : UICollectionViewCell
        {
            public const string Identifier = "DayViewCustomCell";

            public DayViewCustomCell(IntPtr handle) : base(handle)
            {
                Title = new UILabel
                {
                    TextColor = UIColor.White,
                    Font = UIFont.BoldSystemFontOfSize(12),
                    TextAlignment = UITextAlignment.Center,
                    LineBreakMode = UILineBreakMode.TailTruncation,
                    Lines = 0
                };

                this.AddSubview(Title);

                this.Title.Layer.CornerRadius = 4;
                this.Title.Layer.MasksToBounds = true;
            }

            public UILabel Title { get; }

            public void Update(TKCalendarEvent ev)
            {
                Title.Text = ev.Title;
                Title.BackgroundColor = ev.EventColor;
            }

            public override void LayoutSubviews()
            {
                base.LayoutSubviews();
                Title.Frame = Inset(this.Bounds, 1, 20);
                Title.LayoutMargins = new UIEdgeInsets(4, 4, 4, 4);
            }

            private static CGRect Inset(CGRect rect, nfloat inset, nfloat minHeight)
            {
                return new CGRect(rect.X + inset, rect.Y + inset, rect.Width - 2 * inset, Math.Max(rect.Height - 2 * inset, minHeight));
            }
        }

        public class DayViewDataSource : TKCalendarDayViewDataSource
        {
            public override UICollectionViewCell EventCellForItemAtIndexPath(TKCalendarDayView dayView, NSIndexPath indexPath)
            {
                var cell = dayView.EventsView.DequeueReusableCell(DayViewCustomCell.Identifier, indexPath) as DayViewCustomCell;
                cell.Update((TKCalendarEvent)dayView.Events[indexPath.Row]);

                return cell;
            }
        }
    }
}
