using System.Linq;

namespace QSF.iOS
{
    public class CodeViewerRenderer : Xamarin.Forms.Platform.iOS.ViewRenderer<Examples.CodeViewer, UIKit.UITextView>
    {
        private System.Collections.Generic.Dictionary<string, string> codeTextForFiles;

        protected override void OnElementChanged(Xamarin.Forms.Platform.iOS.ElementChangedEventArgs<Examples.CodeViewer> e)
        {
            base.OnElementChanged(e);

            if (this.Element != null)
            {
                var nativeControl = new UIKit.UITextView();

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
                nativeControl.Text = codeTextForFiles.First().Value;
                nativeControl.Editable = false;

                this.Element.LoadedFiles = codeTextForFiles;
                SetNativeControl(nativeControl);
            }
        }

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName.Equals("FileNameToLoad"))
            {
                this.Control.Text = codeTextForFiles[this.Element.FileNameToLoad];
            }
        }
    }
}