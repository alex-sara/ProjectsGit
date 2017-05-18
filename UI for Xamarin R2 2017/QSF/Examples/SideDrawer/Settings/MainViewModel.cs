using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Examples.SideDrawer.Settings
{
    public class MainViewModel
    {
        public List<string> Transitions { get; set; }
        public List<string> TransitionsIos { get; set; }

        public MainViewModel()
        {
            this.Transitions = new List<string>()
            {
                "SlideAlong",
                "SlideInOnTop",
                "Push",
                "Reveal",
                "ReverseSlideOut",
                "ScaleUp"
            };

            this.TransitionsIos = new List<string>()
            {
                "SlideAlong",
                "SlideInOnTop",
                "Push",
                "Reveal",
                "ReverseSlideOut",
                "ScaleUp"
            };
        }
    }

    public class TransitionItem
    {
        public ImageSource ImageSourceUri { get; set; }
        public string Title {get;set;}
    }
}