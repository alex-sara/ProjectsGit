using Telerik.XamarinForms.Common.WinPhone;
using Xamarin.Forms;
using Xamarin.Forms.Platform.WinPhone;

namespace SDKBrowser.WinPhone
{
    public partial class MainPage : FormsApplicationPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            Forms.Init();

            this.LoadApplication(new SDKBrowser.App());
        }
    }
}
