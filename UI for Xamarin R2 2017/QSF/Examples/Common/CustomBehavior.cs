using Examples.Helpers;
using System;
using Xamarin.Forms;

namespace Examples
{
    public enum ButtonType
    {
        Back, Info
    }

    //This behavior inserts the half circle button on top of each example
    public class CustomBehavior : Behavior<Layout<View>>
    {
        public static BindableProperty BackButtonHorizontalOptionsProperty =
            BindableProperty.CreateAttached("BackButtonHorizontalOptions", typeof(LayoutOptions?), typeof(CustomBehavior), null);

        public static BindableProperty BackButtonVerticalOptionsProperty =
            BindableProperty.CreateAttached("BackButtonVerticalOptions", typeof(LayoutOptions?), typeof(CustomBehavior), null);

        public static BindableProperty IsBackButtonVisibleProperty =
            BindableProperty.CreateAttached("IsBackButtonVisible", typeof(bool), typeof(CustomBehavior), true);

        public static BindableProperty InfoButtonHorizontalOptionsProperty =
            BindableProperty.CreateAttached("InfoButtonHorizontalOptions", typeof(LayoutOptions?), typeof(CustomBehavior), null);

        public static BindableProperty InfoButtonVerticalOptionsProperty =
            BindableProperty.CreateAttached("InfoButtonVerticalOptions", typeof(LayoutOptions?), typeof(CustomBehavior), null);

        private Layout<View> bindable;
        public static LayoutOptions? GetBackButtonHorizontalOptions(BindableObject view)
        {
            return (LayoutOptions?)view.GetValue(BackButtonHorizontalOptionsProperty);
        }

        public static LayoutOptions? GetBackButtonVerticalOptions(BindableObject view)
        {
            return (LayoutOptions?)view.GetValue(BackButtonVerticalOptionsProperty);
        }

        public static LayoutOptions? GetInfoButtonHorizontalOptions(BindableObject view)
        {
            return (LayoutOptions?)view.GetValue(InfoButtonHorizontalOptionsProperty);
        }

        public static LayoutOptions? GetInfoButtonVerticalOptions(BindableObject view)
        {
            return (LayoutOptions?)view.GetValue(InfoButtonVerticalOptionsProperty);
        }

        public static bool GetIsBackButtonVisible(BindableObject view)
        {
            return (bool)view.GetValue(IsBackButtonVisibleProperty);
        }

        public static void SetBackButtonHorizontalOptions(BindableObject view, LayoutOptions? value)
        {
            view.SetValue(BackButtonHorizontalOptionsProperty, value);
        }

        public static void SetBackButtonVerticalOptions(BindableObject view, LayoutOptions value)
        {
            view.SetValue(BackButtonVerticalOptionsProperty, value);
        }

        public static void SetInfoButtonHorizontalOptions(BindableObject view, LayoutOptions? value)
        {
            view.SetValue(InfoButtonHorizontalOptionsProperty, value);
        }
        public static void SetInfoButtonVerticalOptions(BindableObject view, LayoutOptions? value)
        {
            view.SetValue(InfoButtonVerticalOptionsProperty, value);
        }
        protected override void OnAttachedTo(Layout<View> bindable)
        {
            base.OnAttachedTo(bindable);
            this.bindable = bindable;

            var infoH = GetInfoButtonHorizontalOptions(bindable);
            var infoV = GetInfoButtonVerticalOptions(bindable);

            var backH = GetBackButtonHorizontalOptions(bindable);
            var backV = GetBackButtonVerticalOptions(bindable);

            var backVis = GetIsBackButtonVisible(bindable);

            if (Device.OS == TargetPlatform.Android)
            {
                var info = new ImageButton(ButtonType.Info, info_Tapped)
                {
                    Source = ImageSource.FromFile("ic_view_example.png"),
                    HorizontalOptions = infoH ?? LayoutOptions.End,
                    VerticalOptions = infoV ?? LayoutOptions.End,
                    Margin = new Thickness(4, 0)
                };

                bindable.Children.Add(info);
            }
            else if (Device.OS == TargetPlatform.iOS)
            {
                // TODO: fix image names

                var back = new ImageButton(ButtonType.Back, back_Tapped)
                {
                    Source = ImageSource.FromFile("ic_view_example.png"),
                    HorizontalOptions = backH ?? LayoutOptions.Start,
                    VerticalOptions = backV ?? LayoutOptions.End
                };

                var info = new ImageButton(ButtonType.Info, info_Tapped)
                {
                    Source = ImageSource.FromFile("ic_view_info.png"),
                    HorizontalOptions = infoH ?? LayoutOptions.End,
                    VerticalOptions = infoV ?? LayoutOptions.End,
                    Margin = new Thickness(4)
                };

                if (backVis)
                {
                    bindable.Children.Add(back);
                }
                bindable.Children.Add(info);
            }
            else if (Device.OS == TargetPlatform.Windows)
            {
                var info = new ImageButton(ButtonType.Info, info_Tapped)
                {
                    Source = ImageSource.FromFile("Assets\\ic_view_example.png"),
                    HorizontalOptions = infoH ?? LayoutOptions.End,
                    VerticalOptions = infoV ?? LayoutOptions.End,
                    HeightRequest = 50,
                    WidthRequest = 50
                };

                bindable.Children.Add(info);
            }
        }

        private void back_Tapped(object sender, EventArgs e)
        {
            NavigationHelper.NavigateBackFromExample(this.bindable);
        }

        private void info_Tapped(object sender, EventArgs e)
        {
            if (Device.OS == TargetPlatform.Windows)
            {
                NavigationHelper.NavigateToDetailsPageUWP();
            }
            else
            {
                NavigationHelper.NavigateToDetailsPage();
            }
        }
    }

    public class ImageButton : Image
    {
        public ImageButton(ButtonType type, EventHandler tapped)
        {
            this.Type = type;
            var recognizer = new TapGestureRecognizer();
            recognizer.Tapped += tapped;
            this.GestureRecognizers.Add(recognizer);
            this.IsVisible = false;
        }

        public ButtonType Type { get; }
    }
}