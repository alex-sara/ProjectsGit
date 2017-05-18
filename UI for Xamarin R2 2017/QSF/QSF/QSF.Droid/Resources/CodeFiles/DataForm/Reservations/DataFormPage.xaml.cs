using System;
using System.Reflection;
using Telerik.XamarinForms.Input;
using Telerik.XamarinForms.Input.DataForm;
using Xamarin.Forms;

namespace Examples.DataForm.Reservations
{
    [Xamarin.Forms.Xaml.XamlCompilation(Xamarin.Forms.Xaml.XamlCompilationOptions.Skip)]
    public partial class DataFormPage : ContentPage
    {
        private bool isNewItem = false;
        private DataFormViewModel vm;

        public DataFormPage(Reservation source = null)
        {
            this.isNewItem = source == null;
            this.BindingContext = vm = new DataFormViewModel(source);

            InitializeComponent();

            this.dataForm.PropertyDataSourceProvider = new UserPropertyDataSourceProvider();

            foreach (var property in typeof(Reservation).GetTypeInfo().DeclaredProperties)
            {
                this.dataForm.RegisterEditor(property.Name, EditorType.Custom);
            }

            this.dataForm.GroupHeaderStyle = new DataFormGroupHeaderStyle { IsCollapsible = false };
            this.dataForm.GroupLayoutDefinition = new DataFormGroupGridLayoutDefinition();

            var style = new DataFormEditorStyle
            {
                FeedbackFontSize = 10,
                PositiveFeedbackBackground = Color.Transparent,
            };

            if (Device.OS == TargetPlatform.Android)
            {
                style.HeaderFontSize = 12;
            }

            this.dataForm.EditorStyle = style;

            var cancelEditGesture = new TapGestureRecognizer();
            cancelEditGesture.Tapped += this.cancelButton_Clicked;
            this.cancelButton.GestureRecognizers.Add(cancelEditGesture);

            var addReservationGesture = new TapGestureRecognizer();
            addReservationGesture.Tapped += this.doneButton_Clicked;
            this.doneButton.GestureRecognizers.Add(addReservationGesture);

            var cancelReservationGesture = new TapGestureRecognizer();
            cancelReservationGesture.Tapped += CancelReservationClicked;
            this.cancelReservationButton.GestureRecognizers.Add(cancelReservationGesture);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var rootGrid = this.Content as Grid;
            if (Examples.Helpers.ExampleHelper.SetImageButtonOnTop(ref rootGrid))
            {
                this.Content = rootGrid;
            }
        }

        private async void CancelReservationClicked(object sender, EventArgs e)
        {
            if (!isNewItem)
            {
                Example.vm.Reservations.Remove(this.vm.FormSource);
            }

            await this.Navigation.PopAsync();
        }

        private void doneButton_Clicked(object sender, EventArgs e)
        {
            this.dataForm.FormValidationCompleted += DataForm_FormValidationCompleted;
            this.dataForm.ValidateAll();
        }

        private async void DataForm_FormValidationCompleted(object sender, FormValidationCompletedEventArgs e)
        {
            var form = sender as RadDataForm;
            if (form != null)
            {
                form.FormValidationCompleted -= this.DataForm_FormValidationCompleted;
                if (e.IsValid)
                {
                    this.dataForm.CommitAll();

                    if (isNewItem)
                    {
                        Example.vm.Reservations.Add(this.vm.FormSource);
                    }

                    await this.Navigation.PopAsync();
                }
            }
        }

        private async void cancelButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}