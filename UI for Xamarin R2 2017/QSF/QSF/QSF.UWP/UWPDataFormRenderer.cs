using Examples.DataForm.Reservations;
using System;
using Telerik.UI.Xaml.Controls.Data;
using Telerik.XamarinForms.Input.DataForm;
using Telerik.XamarinForms.InputRenderer.UWP;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace QSF.UWP
{
    public class UWPDataFormRenderer : DataFormRenderer
    {
        protected override Type GetCustomEditorType(string propertyName, Type propertyType)
        {
            switch (propertyName)
            {
                case nameof(Reservation.TableNumber):
                case nameof(Reservation.TableSection):
                case nameof(Reservation.OrderOrigin):
                    return typeof(EnumEditor);

                case nameof(Reservation.GuestNumber):
                    return typeof(NumericEditor);

                case nameof(Reservation.ReservationDate):
                    return typeof(DateEditor);

                case nameof(Reservation.ReservationTime):
                    return typeof(TimeEditor);

                default:
                    return base.GetCustomEditorType(propertyName, propertyType);
            }
        }

        protected override void UpdateEditor(EntityPropertyControl editor, IEntityProperty property)
        {
            Style iconStyle = new Style();
            iconStyle.TargetType = typeof(SymbolIcon);
            iconStyle.Setters.Add(new Setter(SymbolIcon.ForegroundProperty, new SolidColorBrush(Colors.Red)));
            iconStyle.Setters.Add(new Setter(SymbolIcon.MarginProperty, new Thickness(5, 0, 0, 0)));

            var propertyName = property.PropertyName;

            switch (propertyName)
            {
                case nameof(Reservation.ReservationHolder):
                    var editorView = editor.View as StringEditor;
                    if (editorView != null)
                    {
                        editorView.IconDisplayMode = Telerik.UI.Xaml.Controls.Data.DataForm.EditorIconDisplayMode.Label;
                        iconStyle.Setters.Add(new Setter(SymbolIcon.SymbolProperty, Symbol.Contact));
                        editorView.LabelIconStyle = iconStyle;
                    }
                    break;

                case nameof(Reservation.GuestNumber):
                    var numericEditor = editor.View as NumericEditor;
                    if (numericEditor != null)
                    {
                        numericEditor.IconDisplayMode = Telerik.UI.Xaml.Controls.Data.DataForm.EditorIconDisplayMode.Label;
                        iconStyle.Setters.Add(new Setter(SymbolIcon.SymbolProperty, Symbol.People));
                        numericEditor.LabelIconStyle = iconStyle;
                    }
                    break;

                case nameof(Reservation.HolderPhoneNumber):
                    var stringEditorView = editor.View as StringEditor;
                    if (stringEditorView != null)
                    {
                        stringEditorView.IconDisplayMode = Telerik.UI.Xaml.Controls.Data.DataForm.EditorIconDisplayMode.Label;
                        iconStyle.Setters.Add(new Setter(SymbolIcon.SymbolProperty, Symbol.Phone));
                        stringEditorView.LabelIconStyle = iconStyle;
                    }
                    break;

                case nameof(Reservation.ReservationDate):
                    var dateEditorView = editor.View as DateEditor;
                    if (dateEditorView != null)
                    {
                        dateEditorView.IconDisplayMode = Telerik.UI.Xaml.Controls.Data.DataForm.EditorIconDisplayMode.Label;
                        iconStyle.Setters.Add(new Setter(SymbolIcon.SymbolProperty, Symbol.Calendar));
                        dateEditorView.LabelIconStyle = iconStyle;
                    }
                    break;

                case nameof(Reservation.ReservationTime):
                    var timeEditorView = editor.View as TimeEditor;
                    if (timeEditorView != null)
                    {
                        timeEditorView.IconDisplayMode = Telerik.UI.Xaml.Controls.Data.DataForm.EditorIconDisplayMode.Label;
                        iconStyle.Setters.Add(new Setter(SymbolIcon.SymbolProperty, Symbol.Clock));
                        timeEditorView.LabelIconStyle = iconStyle;
                    }
                    break;

                default:
                    break;
            }

            base.UpdateEditor(editor, property);
        }
    }
}