using System;
using System.Linq;
using Xamarin.Forms;

namespace Examples
{
    public class CodeViewer : View
    {
        public static readonly BindableProperty FileNameToLoadProperty = BindableProperty.Create<CodeViewer, string>(p => p.FileNameToLoad, "");
        public string FileNameToLoad
        {
            get { return (string)GetValue(FileNameToLoadProperty); }
            set { SetValue(FileNameToLoadProperty, value); }
        }

        public static readonly BindableProperty LoadedFilesProperty = BindableProperty.Create<CodeViewer, System.Collections.Generic.Dictionary<string, string>>(p => p.LoadedFiles, null, BindingMode.TwoWay);
        public System.Collections.Generic.Dictionary<string, string> LoadedFiles
        {
            get
            {
                return (System.Collections.Generic.Dictionary<string, string>)GetValue(LoadedFilesProperty);
            }
            set
            {
                SetValue(LoadedFilesProperty, value);
            }
        }
    }
}