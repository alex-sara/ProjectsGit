using Xamarin.Forms;

namespace Examples.Helpers
{
    public static class NavigationHelper
    {
        public static void NavigateBackFromExample(VisualElement element)
        {
            if (Device.OS == TargetPlatform.Android)
            {
                NavigateToDetailsPage();
            }
            else if (Device.OS == TargetPlatform.iOS)
            {
                element.Navigation.PopAsync();
            }
            else if (Device.OS == TargetPlatform.Windows)
            {
                NavigateToDetailsPageUWP();
            }
        }

        async public static void NavigateToDetailsPage()
        {
            var exampleDetails = new Examples.ExampleDetailsPage(Examples.StartPage.CurrentlyOpenedExample);
            NavigationPage.SetHasNavigationBar(exampleDetails, false);

            await Application.Current.MainPage.Navigation.PushAsync(exampleDetails);
            Application.Current.MainPage.Navigation.RemovePage(Application.Current.MainPage.Navigation.NavigationStack[Application.Current.MainPage.Navigation.NavigationStack.Count - 2]);
        }

        async public static void NavigateToDetailsPageUWP()
        {
            var exampleDetails = new Examples.ExampleDetailsPageUWP(Examples.StartPage.CurrentlyOpenedExample);
            NavigationPage.SetHasNavigationBar(exampleDetails, false);

            await Application.Current.MainPage.Navigation.PushAsync(exampleDetails);
            Application.Current.MainPage.Navigation.RemovePage(Application.Current.MainPage.Navigation.NavigationStack[Application.Current.MainPage.Navigation.NavigationStack.Count - 2]);
        }
    }
}