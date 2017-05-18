using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Xamarin.Forms.Platform.UWP;

namespace QSF.UWP
{
    public class CodeViewerRenderer : ViewRenderer<Examples.CodeViewer, TextBox>
    {
        private Dictionary<string, string> codeTextForFiles;

        protected override void OnElementChanged(ElementChangedEventArgs<Examples.CodeViewer> e)
        {
            base.OnElementChanged(e);
            if (this.Element != null)
            {
                var text = new TextBox();
                text.IsReadOnly = true;
                text.BorderBrush = new SolidColorBrush(Colors.Transparent);
                text.BorderThickness = new Windows.UI.Xaml.Thickness(0);
                text.TextWrapping = Windows.UI.Xaml.TextWrapping.Wrap;

                var assembly = this.GetType().GetTypeInfo().Assembly;
                var resourceNamesInAssembly = assembly.GetManifestResourceNames();
                codeTextForFiles = new Dictionary<string, string>();
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
                text.Text = codeTextForFiles.First().Value;
                this.Element.LoadedFiles = codeTextForFiles;

                SetNativeControl(text);
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName.Equals("FileNameToLoad"))
            {
                this.Control.Text = codeTextForFiles[this.Element.FileNameToLoad];
            }
        }
    }
}