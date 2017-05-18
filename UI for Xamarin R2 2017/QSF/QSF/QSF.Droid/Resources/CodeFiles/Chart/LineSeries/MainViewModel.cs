using Examples.Chart.BarSeries;
using System.Collections.ObjectModel;

namespace Examples.Chart.LineSeries
{
    public class MainViewModel
    {
        public ObservableCollection<GalleryItem> LineLayouts { get; set; }
        public ObservableCollection<DataItem> SeriesData { get; set; }
        public ObservableCollection<DataItem> SecondSeriesData { get; set; }

        public MainViewModel()
        {
            this.LineLayouts = new ObservableCollection<GalleryItem>()
            {
                new GalleryItem("line", "line_1.png"),
                new GalleryItem("stacked-line", "line_3.png"),
                new GalleryItem("spline", "line_5.png"),
                new GalleryItem("stacked-spline", "line_7.png")
            };

            this.SeriesData = new ObservableCollection<DataItem>()
            {
                new DataItem(){Category = "Greenings", Value = 60},
                new DataItem(){Category = "Perfecto", Value = 47},
                new DataItem(){Category = "NearBy", Value = 51},
                new DataItem(){Category = "FamilyStore", Value = 26},
                new DataItem(){Category = "Fresh&Green", Value = 82}
            };

            this.SecondSeriesData = new ObservableCollection<DataItem>()
            {
                new DataItem(){Category = "Greenings", Value = 5},
                new DataItem(){Category = "Perfecto", Value = 15},
                new DataItem(){Category = "NearBy", Value = 4},
                new DataItem(){Category = "FamilyStore", Value = 45},
                new DataItem(){Category = "Fresh&Green", Value = 10}
            };
        }
    }
}