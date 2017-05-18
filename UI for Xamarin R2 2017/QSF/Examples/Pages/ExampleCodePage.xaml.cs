using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace Examples
{
    public partial class ExampleCodePage : ContentPage
    {
        public string FileNameToLoad { get; set; }
        public System.Collections.Generic.Dictionary<string, string> LoadedFiles { get; set; }
        private ObservableCollection<string> visibleFiles;
        private string loadedControl;
        private string loadedExampleTitle;
        private string NAMESPACE_CONTROL_EXAMPLE_CONST;

        public ExampleCodePage(Example loadedExample)
        {
            InitializeComponent();
            this.visibleFiles = new ObservableCollection<string>();
            this.loadedControl = loadedExample.Control;
            this.loadedExampleTitle = loadedExample.Title;
            this.FileNameToLoad = this.loadedControl + "." + this.loadedExampleTitle;
            if (Device.OS == TargetPlatform.Android)
            {
                 this.NAMESPACE_CONTROL_EXAMPLE_CONST = "QSF.Droid.Resources.CodeFiles." + this.FileNameToLoad + ".";
                 this.backLable.IsVisible = false;
            }
            else if (Device.OS == TargetPlatform.iOS)
            {
                this.NAMESPACE_CONTROL_EXAMPLE_CONST = "QSF.iOS.Resources.CodeFiles." + this.FileNameToLoad + ".";
                this.backLable.HorizontalOptions = LayoutOptions.Start;

                var backLableTapped = new TapGestureRecognizer();
                backLableTapped.Tapped += backButtonClicked;
                this.backLableHolder.GestureRecognizers.Add(backLableTapped);
            }
            else if (Device.OS == TargetPlatform.Windows)
            {
                this.NAMESPACE_CONTROL_EXAMPLE_CONST = "QSF.UWP.Resources.CodeFiles." + this.FileNameToLoad + ".";
                this.backLable.IsVisible = false;
            }
           
            this.BindingContext = this;

            var backButtonTapped = new TapGestureRecognizer();
            backButtonTapped.Tapped += backButtonClicked;
            this.backButton.GestureRecognizers.Add(backButtonTapped);

            this.fileList.ItemsSource = this.visibleFiles;

            //this.backButton.Source = ImageSource.FromFile("ic_arrow_back.png");
            //var backClicked = new TapGestureRecognizer();
            //backClicked.Tapped += backButtonClicked;
            //this.backButton.GestureRecognizers.Add(backClicked);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            foreach (var file in this.LoadedFiles)
            {
                this.visibleFiles.Add(this.GetFileName(file.Key));
            }

            //this.fileList.SelectedItems.Add(visibleFiles.First());
        }

        private string GetFileName(string fileName)
        {
            string fn = "";
            string[] separators = { NAMESPACE_CONTROL_EXAMPLE_CONST };
            fn = fileName.Split(separators, StringSplitOptions.RemoveEmptyEntries).Last();

            return fn;
        }

        void FileTapped(object sender, Telerik.XamarinForms.DataControls.ListView.ItemTapEventArgs e)
        {
            this.FileNameToLoad = this.NAMESPACE_CONTROL_EXAMPLE_CONST + e.Item.ToString();
            this.OnPropertyChanged("FileNameToLoad");
        }

        void backButtonClicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        protected override bool OnBackButtonPressed()
        {
            Navigation.PopAsync();
            return true;
        }
    }
}