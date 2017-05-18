using Examples.Chart.BarSeries;
using System.Collections.ObjectModel;

namespace Examples.Chart.PieSeries
{
    public class MainViewModel
    {
        public ObservableCollection<GalleryItem> PieLayouts { get; set; }
        public ObservableCollection<DataItem> Pie2Data { get; set; }
        public ObservableCollection<DataItem> Pie3Data { get; set; }

        public MainViewModel()
        {
            this.PieLayouts = new ObservableCollection<GalleryItem>();
            this.Pie2Data = new ObservableCollection<DataItem>();
            this.Pie3Data = new ObservableCollection<DataItem>();

            this.GetLayouts();
            this.GetSeriesData();
        }

        private void GetSeriesData()
        {
            this.Pie2Data.Add(new DataItem() { Value = 60, Category = "France" });
            this.Pie2Data.Add(new DataItem() { Value = 40, Category = "Belguim" });

            this.Pie3Data.Add(new DataItem() { Value = 30, Category = "France" });
            this.Pie3Data.Add(new DataItem() { Value = 30, Category = "Germany" });
            this.Pie3Data.Add(new DataItem() { Value = 40, Category = "Belguim" });
        }

        private void GetLayouts()
        {
            this.PieLayouts.Add(new GalleryItem("Pie", "pie_1.png"));
            this.PieLayouts.Add(new GalleryItem("Pie2", "pie_2.png"));
        }
    }
}
