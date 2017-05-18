using System;
using System.Linq;
using Android.Widget;

namespace QSF.Droid
{
    public class CodeViewerRenderer : Xamarin.Forms.Platform.Android.ViewRenderer<Examples.CodeViewer, Android.Widget.TextView>
    {
        System.Collections.Generic.Dictionary<string, string> codeTextForFiles;

        protected override void OnElementChanged(Xamarin.Forms.Platform.Android.ElementChangedEventArgs<Examples.CodeViewer> e)
        {
            base.OnElementChanged(e);

            if (this.Element != null)
            {
                var nativeTextView = new Android.Widget.TextView(Xamarin.Forms.Forms.Context);
                nativeTextView.SetTextColor(new Android.Graphics.Color(30, 50, 63));

                var assembly = System.Reflection.Assembly.GetExecutingAssembly();
                var resourceNamesInAssembly = assembly.GetManifestResourceNames();
                codeTextForFiles = new System.Collections.Generic.Dictionary<string, string>();

                var resourcesWithCode = resourceNamesInAssembly.Where(r => r.Contains(this.Element.FileNameToLoad));

                foreach (var resourceName in resourcesWithCode)
                {
                    using (var stream = assembly.GetManifestResourceStream(resourceName))
                    {
                        using (System.IO.StreamReader streamReader = new System.IO.StreamReader(stream))
                        {
                            var codeText = streamReader.ReadToEnd();
                            codeTextForFiles.Add(resourceName, codeText);
                        }
                    }
                }

                nativeTextView.SetText(codeTextForFiles.First().Value, TextView.BufferType.Normal);
                nativeTextView.SetScrollContainer(true);
                nativeTextView.SetTextIsSelectable(true);
                this.Element.LoadedFiles = codeTextForFiles;

                SetNativeControl(nativeTextView);
            }
        }

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName.Equals("FileNameToLoad"))
            {
                this.Control.SetText(codeTextForFiles[this.Element.FileNameToLoad], TextView.BufferType.Normal);
            }
        }
    }
}