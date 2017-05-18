using Examples.Chart.BarSeries;
using System.Collections.ObjectModel;

namespace Examples.Chart.AreaSeries
{
    public class MainViewModel
    {
        public ObservableCollection<GalleryItem> AreaLayouts { get; set; }
        public ObservableCollection<DataItem> SeriesData { get; set; }
        public ObservableCollection<DataItem> SecondSeriesData { get; set; }

        public MainViewModel()
        {
            this.AreaLayouts = new ObservableCollection<GalleryItem>()
            {
                new GalleryItem("lineArea", "area_1.png"),
                new GalleryItem("stacked-lineArea", "area_2.png"),
                new GalleryItem("splineArea", "area_3.png"),
                new GalleryItem("stacked-splineArea", "area_4.png"),
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