using System;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;

namespace Examples
{
    public class StartPageViewModel
    {
        public ObservableCollection<string> InformationMenuList { get; set; }
        public ObservableCollection<QSFControl> AllControlsList { get; set; }
        public ObservableCollection<Example> FeaturedExamplesList { get; set; }

        private bool isOpen;
        public bool IsOpen 
        { 
            get 
            {
                return this.isOpen;
            } 
            set 
            { 
                this.isOpen = value;
            }
        }

        public StartPageViewModel(ExamplesLoader loader)
        {
            this.InformationMenuList = new ObservableCollection<string>()
            {
                "About",
                "Product Page",
                "Documentation",
                "SDK Examples",
                //"Send Feedback"
            };

            this.AllControlsList = new ObservableCollection<QSFControl>();
            foreach (var control in loader.GetAvailableControls())
            {
                this.AllControlsList.Add(control);
            }

            this.FeaturedExamplesList = new ObservableCollection<Example>();
            foreach (var example in loader.GetFeaturedExamples())
            {
                this.FeaturedExamplesList.Add(example);
            }

            foreach (var ex in FeaturedExamplesList)
            {
                ex.UserFriendlyTitle = Regex.Replace(ex.Title, "([a-z](?=[A-Z])|[A-Z](?=[A-Z][a-z]))", "$1 "); 
            }
        }
    }
}