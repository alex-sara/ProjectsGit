using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;

[assembly: ExportRenderer(typeof(Xamarin.Forms.Button), typeof(QSF.Droid.GenericButtonRenderer))]
namespace QSF.Droid
{
    public class GenericButtonRenderer : Xamarin.Forms.Platform.Android.ButtonRenderer
    {
    }
}