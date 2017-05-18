using Examples.Chart.ScatterSeries;
using System;
using System.Collections.ObjectModel;

namespace Examples.Chart.BarSeries
{
    public class MainViewModel
    {
        public ObservableCollection<GalleryItem> BarLayouts { get; set; }
        public ObservableCollection<DataItem> SeriesData { get; set; }
        public ObservableCollection<DataItem> SeriesData2 { get; set; }

        public MainViewModel()
        {
            this.BarLayouts = new ObservableCollection<GalleryItem>()
            {
                new GalleryItem("bar", "bar_1.png"),
                new GalleryItem("cluster", "bar_2.png"),
                new GalleryItem("stacked", "bar_3.png"),
                new GalleryItem("stacked100", "bar_4.png"),
                new GalleryItem("hor-bar", "bar_5.png"),
                new GalleryItem("hor-cluster", "bar_6.png"),
                new GalleryItem("hor-stacked", "bar_7.png"),
                new GalleryItem("hor-stacked100", "bar_8.png"),
            };

            this.SeriesData = new ObservableCollection<DataItem>()
            {
                new DataItem(){Category = "Greenings", Value = 85},
                new DataItem(){Category = "Perfecto", Value = 78},
                new DataItem(){Category = "NearBy", Value = 99},
                new DataItem(){Category = "FamilyStore", Value = 85},
                new DataItem(){Category = "Fresh&Green", Value = 57}
            };

            this.SeriesData2 = new ObservableCollection<DataItem>()
            {
                new DataItem(){Category = "Greenings", Value = 75},
                new DataItem(){Category = "Perfecto", Value = 95},
                new DataItem(){Category = "NearBy", Value = 91},
                new DataItem(){Category = "FamilyStore", Value = 64},
                new DataItem(){Category = "Fresh&Green", Value = 67}
            };
        }
    }
}