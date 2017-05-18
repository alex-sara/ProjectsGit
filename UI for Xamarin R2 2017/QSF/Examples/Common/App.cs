using Examples;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Examples
{
    public class App : Application
    {
        public App(double screenWidth, double screenHeight, double pixelDensity = 1)
        {
            ExamplesLoader loader = new ExamplesLoader("Examples.config.xml");
            ContentPage startPage;

            if (Device.RuntimePlatform == Device.Windows)
            {
                startPage = new StartPageWUP(loader, screenWidth, screenHeight, pixelDensity);
            }
            else
            {
                startPage = new StartPage(loader, screenWidth, screenHeight, pixelDensity);
            }
            NavigationPage.SetHasNavigationBar(startPage, false);
            var rootPage = new NavigationPage(startPage);
            MainPage = rootPage;
        }
    }
}