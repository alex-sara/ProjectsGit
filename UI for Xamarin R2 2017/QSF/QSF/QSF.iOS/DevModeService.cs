using Examples;
using QSF.iOS;
using System;
using System.Collections.Generic;
using System.Text;
using UIKit;

[assembly: Xamarin.Forms.Dependency(typeof(DevModeService))]
namespace QSF.iOS
{
    public class DevModeService : IDevModeService
    {
        public void EnableDevMode()
        {
            (UIApplication.SharedApplication as CustomApplication).EnableTouchVisuals();

            var alert = new UIAlertController
            {
                Title = "Dev Mode enabled",
                Message = "Touch visual feedback is now enabled."
            };

            alert.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Cancel, null));
            UIApplication.SharedApplication.KeyWindow.RootViewController.PresentViewController(alert, true, null);
        }
    }
}
