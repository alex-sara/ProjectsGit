using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace Examples
{
    public partial class ExampleDetailsPage : ContentPage
    {
        public string Description { get; set; }
        public string ExampleTitle { get; set; }
        public bool IsNextButtonEnabled
        {
            get
            {
                return this.isNextButtonEnabled;
            }

            set
            {
                if (this.isNextButtonEnabled != value)
                {
                    this.isNextButtonEnabled = value;
                    this.OnPropertyChanged("IsNextButtonEnabled");
                }
            }
        }
        public bool IsPreviousButtonEnabled
        {
            get
            {
                return this.isPreviousButtonEnabled;
            }

            set
            {
                if (this.isPreviousButtonEnabled != value)
                {
                    this.isPreviousButtonEnabled = value;
                    this.OnPropertyChanged("IsPreviousButtonEnabled");
                }
            }
        }
        public ObservableCollection<Example> OtherExamples { get; set; }
        private Example loadedExample;
        private Example chosenExample;
        private double initialLoadedExampleImagePosition = 0;
        //private TapGestureRecognizer nextBtnTapped;
        //private TapGestureRecognizer prevBtnTapped;
        private TapGestureRecognizer chosenExampleBtnTapped;

        private TapGestureRecognizer viewExampleLinkTapped;
        private TapGestureRecognizer viewCodeLinkTapped;
        private TapGestureRecognizer documentationLinkTapped;
        private bool isNextButtonEnabled = true;
        private bool isPreviousButtonEnabled = true;

        private const int ANIMATION_SPEED = 150;
        private Easing TRANSITION_EASING = Easing.CubicInOut;

        public ExampleDetailsPage(Example example)
        {
            InitializeComponent();

            this.ExampleTitle = Regex.Replace(example.Title, "([a-z](?=[A-Z])|[A-Z](?=[A-Z][a-z]))", "$1 ");
            this.Description = example.Description;
            this.OtherExamples = StartPage.ExamplesListCache;

            this.nextButtonDisabledState.BackgroundColor = Color.FromRgba(1, 1, 1, 0.5);
            this.previousButtonDisabledState.BackgroundColor = Color.FromRgba(1, 1, 1, 0.5);

            if (this.OtherExamples.Count == 1)
            {
                this.IsNextButtonEnabled = false;
                this.IsPreviousButtonEnabled = false;

                for (int i = 0; i < rootGrid.Children.Count; i++)
                {
                    if (Grid.GetRow(rootGrid.Children[i]) == 1)
                    {
                        this.rootGrid.Children.RemoveAt(i);
                    }
                }
                this.rootGrid.RowDefinitions[1].Height = 0;
            }

            for (int i = 0; i < OtherExamples.Count; i++)
            {
                this.directImageHost.Children.Add(new Image() { Source = OtherExamples[i].ImageSourceUri, HeightRequest = 132, WidthRequest = 132 });
            }

            this.loadedExample = example;
            this.BindingContext = this;
            this.chosenExample = example;
            this.ScrollToCorrectItem();

            this.backLabel.HorizontalOptions = LayoutOptions.Start;

            if (Device.OS == TargetPlatform.Android)
            {
                //this.backLabel.HorizontalOptions = LayoutOptions.Start; 
                this.ViewExampleLink.Text = this.ViewExampleLink.Text.ToUpper();
                this.ViewCodeLink.Text = this.ViewCodeLink.Text.ToUpper();
                this.DocumentationLink.Text = this.DocumentationLink.Text.ToUpper();
            }
            else if (Device.OS == TargetPlatform.iOS)
            {
                //this.backLabel.HorizontalOptions = LayoutOptions.Center;
                //Grid.SetColumnSpan(this.backLabel, 2);
                //Grid.SetColumn(this.backLabel, 0);
            }

            this.SetupLinks();

            this.prevExImage.Source = ImageSource.FromFile("ic_arrow_prev.png");
            this.nextExImage.Source = ImageSource.FromFile("ic_arrow_next.png");

            this.prevExTitle.Text = this.GetPreviousExampleTitle(loadedExample);
            this.nextExTitle.Text = this.GetNextExamplpeTitle(loadedExample);

            //prevBtnTapped = new TapGestureRecognizer();
            //prevBtnTapped.Tapped += previousExample;
            //this.prevButton.GestureRecognizers.Add(prevBtnTapped);

            //nextBtnTapped = new TapGestureRecognizer();
            //nextBtnTapped.Tapped += nextExample;
            //this.nextButton.GestureRecognizers.Add(nextBtnTapped);

            chosenExampleBtnTapped = new TapGestureRecognizer();
            chosenExampleBtnTapped.Tapped += chosenExampleTapped_Tapped;
            //this.middleBtn.GestureRecognizers.Add(chosenExampleBtnTapped);

            var backLableTapped = new TapGestureRecognizer();
            backLableTapped.Tapped += backButtonClicked;
            this.backLableHolder.GestureRecognizers.Add(backLableTapped);

            var backButtonTapped = new TapGestureRecognizer();
            backButtonTapped.Tapped += backButtonClicked;
            this.backButton.GestureRecognizers.Add(backButtonTapped);

        }

        private void ScrollToCorrectItem()
        {
            byte loadedExampleIndex = (byte)OtherExamples.IndexOf(loadedExample);
            this.initialLoadedExampleImagePosition = loadedExampleIndex * 140;
            this.directImageHost.TranslateTo(-initialLoadedExampleImagePosition, 0, 0, TRANSITION_EASING);
        }

        private void SetupLinks()
        {

            this.viewExampleLinkTapped = new TapGestureRecognizer();
            this.viewExampleLinkTapped.Tapped += viewExampleLinkTapped_Tapped;
            this.ViewExampleLink.GestureRecognizers.Add(viewExampleLinkTapped);

            this.viewCodeLinkTapped = new TapGestureRecognizer();
            this.viewCodeLinkTapped.Tapped += viewCodeLinkTapped_Tapped;
            this.ViewCodeLink.GestureRecognizers.Add(viewCodeLinkTapped);

            this.documentationLinkTapped = new TapGestureRecognizer();
            this.documentationLinkTapped.Tapped += documentationLinkTapped_Tapped;
            this.DocumentationLink.GestureRecognizers.Add(documentationLinkTapped);
        }

        void documentationLinkTapped_Tapped(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri("http://docs.telerik.com/devtools/xamarin/"));
        }

        void viewCodeLinkTapped_Tapped(object sender, EventArgs e)
        {
            var exCodePage = new ExampleCodePage(chosenExample);
            NavigationPage.SetHasNavigationBar(exCodePage, false);
            Navigation.PushAsync(exCodePage);
        }

        void viewExampleLinkTapped_Tapped(object sender, EventArgs e)
        {
            this.OpenSelectedExample();
        }

        void chosenExampleTapped_Tapped(object sender, EventArgs e)
        {
            this.OpenSelectedExample();
        }

        private string GetNextExamplpeTitle(Example loadedExample)
        {
            int nextIndex = this.OtherExamples.IndexOf(loadedExample) + 1;
            if (nextIndex >= this.OtherExamples.Count)
            {
                this.IsNextButtonEnabled = false;
                this.UpdateButtonState("next", false);
                return "";
            }

            this.IsNextButtonEnabled = true;
            this.UpdateButtonState("next", true);
            return Regex.Replace(this.OtherExamples[nextIndex].Title, "([a-z](?=[A-Z])|[A-Z](?=[A-Z][a-z]))", "$1 ");
        }

        private string GetPreviousExampleTitle(Example loadedExample)
        {
            int previousIndex = this.OtherExamples.IndexOf(loadedExample) - 1;
            if (previousIndex < 0)
            {
                this.IsPreviousButtonEnabled = false;
                this.UpdateButtonState("previous", false);
                return "";
            }

            this.IsPreviousButtonEnabled = true;
            this.UpdateButtonState("previous", true);
            return Regex.Replace(this.OtherExamples[previousIndex].Title, "([a-z](?=[A-Z])|[A-Z](?=[A-Z][a-z]))", "$1 ");
        }

        private void UpdateButtonState(string buttonName, bool isButtonEnabled)
        {
            if (buttonName.Equals("previous"))
            {
                if (isButtonEnabled)
                {
                    this.previousButtonDisabledState.IsVisible = false;
                }
                else
                {
                    this.previousButtonDisabledState.IsVisible = true;
                }
            }

            if (buttonName.Equals("next"))
            {
                if (isButtonEnabled)
                {
                    this.nextButtonDisabledState.IsVisible = false;
                }
                else
                {
                    this.nextButtonDisabledState.IsVisible = true;
                }
            }
        }

        async void previousExample(object sender, EventArgs e)
        {
            this.DeattachTapListeners();

            if (!this.IsNextButtonEnabled)
            {
                this.IsNextButtonEnabled = true;
            }

            //Save initial position
            double initialDescriontionX = exampleDescriptionHolder.TranslationX;

            //animate example description and example images
            this.exampleDescriptionHolder.TranslateTo(Examples.Helpers.DeviceHelper.ScreenWidth, exampleDescriptionHolder.TranslationY, ANIMATION_SPEED / 2, TRANSITION_EASING);
            await this.directImageHost.TranslateTo(directImageHost.TranslationX + 140, this.directImageHost.TranslationY, ANIMATION_SPEED / 2, TRANSITION_EASING);

            //switch images
            this.SwitchExample(false);

            //reset positions of animated components
            await this.exampleDescriptionHolder.TranslateTo(-350, exampleDescriptionHolder.TranslationY, 0, TRANSITION_EASING);

            await this.exampleDescriptionHolder.TranslateTo(initialDescriontionX, exampleDescriptionHolder.TranslationY, ANIMATION_SPEED, TRANSITION_EASING);

            this.AttachTapListeners();
        }

        async void nextExample(object sender, EventArgs e)
        {
            this.DeattachTapListeners();

            if (!this.IsPreviousButtonEnabled)
            {
                this.IsPreviousButtonEnabled = true;
            }

            double initialDescriontionX = exampleDescriptionHolder.TranslationX;

            this.exampleDescriptionHolder.TranslateTo(-350, exampleDescriptionHolder.TranslationY, ANIMATION_SPEED / 2, TRANSITION_EASING);
            await this.directImageHost.TranslateTo(directImageHost.TranslationX - 140, this.directImageHost.TranslationY, ANIMATION_SPEED / 2, TRANSITION_EASING);

            this.SwitchExample(true);

            await this.exampleDescriptionHolder.TranslateTo(Examples.Helpers.DeviceHelper.ScreenWidth, exampleDescriptionHolder.TranslationY, 0, TRANSITION_EASING);

            await this.exampleDescriptionHolder.TranslateTo(initialDescriontionX, exampleDescriptionHolder.TranslationY, ANIMATION_SPEED, TRANSITION_EASING);

            this.AttachTapListeners();
        }

        private void SwitchExample(bool isForward)
        {
            var indexToNavitage = isForward == true ? OtherExamples.IndexOf(chosenExample) + 1 : OtherExamples.IndexOf(chosenExample) - 1;
            if (indexToNavitage >= 0 && indexToNavitage < OtherExamples.Count)
            {
                chosenExample = OtherExamples[indexToNavitage];
                this.ExampleTitle = Regex.Replace(chosenExample.Title, "([a-z](?=[A-Z])|[A-Z](?=[A-Z][a-z]))", "$1 ");
                this.Description = chosenExample.Description;
                this.prevExTitle.Text = this.GetPreviousExampleTitle(chosenExample);
                this.nextExTitle.Text = this.GetNextExamplpeTitle(chosenExample);
                this.OnPropertyChanged("ExampleTitle");
                this.OnPropertyChanged("Description");
            }
        }

        private void OpenSelectedExample()
        {
            var exampleToNavigate = PageFactory.GetPage(chosenExample.Control + "." + chosenExample.Title);
            StartPage.CurrentlyOpenedExample = chosenExample;
            NavigationPage.SetHasNavigationBar(exampleToNavigate, false);

            Navigation.PushAsync(exampleToNavigate);
            Navigation.RemovePage(Navigation.NavigationStack[Navigation.NavigationStack.Count - 2]);
        }

        private void AttachTapListeners()
        {
            //nextBtnTapped.Tapped += nextExample;
            //prevBtnTapped.Tapped += previousExample;
            nextButton.Clicked += nextExample;
            prevButton.Clicked += previousExample;
            chosenExampleBtnTapped.Tapped += chosenExampleTapped_Tapped;
        }

        private void DeattachTapListeners()
        {
            //nextBtnTapped.Tapped -= nextExample;
            //prevBtnTapped.Tapped -= previousExample;
            nextButton.Clicked -= nextExample;
            prevButton.Clicked -= previousExample;
            chosenExampleBtnTapped.Tapped -= chosenExampleTapped_Tapped;
        }

        void backButtonClicked(object sender, EventArgs e)
        {
            this.directImageHost.IsVisible = false;
            Navigation.PopAsync();
        }

        protected override bool OnBackButtonPressed()
        {
            Navigation.PopAsync();
            return true;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            this.imagesClipHolder.IsClippedToBounds = true;
        }
    }
}