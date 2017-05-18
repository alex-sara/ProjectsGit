using Examples.Chart.BarSeries;
using System.Collections.ObjectModel;

namespace Examples.Chart.ScatterSeries
{
    public class MainViewModel
    {
        public ObservableCollection<GalleryItem> ScatterLayouts { get; set; }
        public ObservableCollection<DataItem> SeriesData { get; set; }
        public ObservableCollection<DataItem> SeriesData2 { get; set; }

        public MainViewModel()
        {
            this.ScatterLayouts = new ObservableCollection<GalleryItem>()
            {
                new GalleryItem("ScatterPointSeries", "scatter.png"),
                new GalleryItem("ScatterLineSeries", "line_1.png"),
                new GalleryItem("ScatterSplineAreaSeries", "area_3.png"),
                new GalleryItem("ScatterSplineSeries", "line_5.png"),
                new GalleryItem("ScatterAreaSeries", "area_1.png")
            };

            this.SeriesData = new ObservableCollection<DataItem>()
            {
                new DataItem(){Category = "Greenings", Value = 20, ValueY = 300},
                new DataItem(){Category = "Perfecto", Value = 35, ValueY = 700},
                new DataItem(){Category = "NearBy", Value = 60, ValueY = 950},
                new DataItem(){Category = "Store", Value = 85, ValueY = 1000},
                new DataItem(){Category = "Fresh&Green", Value = 90, ValueY = 1050}
            };

            this.SeriesData2 = new ObservableCollection<DataItem>()
            {
                new DataItem(){Category = "Greenings", Value = 20, ValueY = 100},
                new DataItem(){Category = "Perfecto", Value = 40, ValueY = 700},
                new DataItem(){Category = "NearBy", Value = 50, ValueY = 850},
                new DataItem(){Category = "Store", Value = 95, ValueY = 900},
                new DataItem(){Category = "Fresh&Green", Value = 100, ValueY = 1250}
            };
        }
    }
}