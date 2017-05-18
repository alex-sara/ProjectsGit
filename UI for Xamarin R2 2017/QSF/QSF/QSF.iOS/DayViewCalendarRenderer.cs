using Examples.Calendar.DayView;
using QSF.iOS;
using Telerik.XamarinForms.InputRenderer.iOS;
using TelerikUI;
using Xamarin.Forms;
using Foundation;
using UIKit;
using Examples.ZipLibrary.CreateArchive.Converters;
using CoreGraphics;

[assembly: ExportRenderer(typeof(DayViewCalendar), typeof(DayViewCalendarRenderer))]
namespace QSF.iOS
{
    public class DayViewCalendarRenderer : CalendarRenderer
    {
        public override bool TrySetViewMode(Telerik.XamarinForms.Input.CalendarViewMode view, bool isAnimated)
        {
            bool hasNavigated = base.TrySetViewMode(view, isAnimated);
            var presenter = Control?.Presenter as TKCalendarDayViewPresenter;
            if (presenter != null)
            {
                presenter.DayView.EventsView.StartTime = 3600 * 8;
                presenter.DayView.EventsView.EndTime = 3600 * 22;
                presenter.DayView.EventsView.Style.LabelFormatter = new NSDateFormatter { DateFormat = "H a" };

                presenter.DayView.EventsView.UpdateLayout();
                presenter.Style.DayNameTextEffect = TKCalendarTextEffect.Uppercase;
                presenter.TitleHidden = true;
                presenter.WeekView.Layer.MasksToBounds = false;

                presenter.Update(false);
            }

            return hasNavigated;
        }

        protected override CalendarDelegate CreateCalendarDelegateOverride()
        {
            return new CustomCalendarDelegate();
        }
    }

    public class CustomCalendarDelegate : CalendarDelegate
    {
        private static UIColor selectionColor = (UIColor.FromRGB(183 / 256f, 64 / 256f, 63 / 256f));

        public override void UpdateVisualsForCell(TKCalendar calendar, TKCalendarCell cell)
        {
            base.UpdateVisualsForCell(calendar, cell);

            var dayCell = cell as TKCalendarDayCell;
            if (dayCell != null)
            {
                dayCell.Style.ShapeFill = new TKSolidFill(selectionColor);
                dayCell.Style.ShapeStroke = new TKStroke(selectionColor, 10);
                dayCell.Style.TopBorderWidth = 0;
                dayCell.Style.BottomBorderWidth = 0;

                if ((dayCell.State & TKCalendarDayState.Today) == TKCalendarDayState.Today && (dayCell.State & TKCalendarDayState.Selected) != TKCalendarDayState.Selected)
                {
                    dayCell.Style.TextColor = UIColor.Black;
                }
            }

            var dayNameCell = cell as TKCalendarDayNameCell;
            if (dayNameCell != null)
            {
                dayNameCell.Style.TextFont = UIFont.SystemFontOfSize(10);
                dayNameCell.Style.BottomBorderWidth = 0;
                dayNameCell.Style.TextInsets = new UIEdgeInsets(10, 0, 0, 0);
            }
        }
    }
}