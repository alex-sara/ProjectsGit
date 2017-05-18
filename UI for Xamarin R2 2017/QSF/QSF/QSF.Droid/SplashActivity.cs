using System;
using Android.App;
using Android.OS;

namespace QSF.Droid
{
    [Activity(Theme = "@style/Theme.Splash", MainLauncher = true, NoHistory = true)]
    public class SplashActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Create your application here

            StartActivity(typeof(MainActivity));
        }
    }
}