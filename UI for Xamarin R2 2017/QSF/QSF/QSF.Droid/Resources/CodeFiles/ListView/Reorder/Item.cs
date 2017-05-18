using System.ComponentModel;

namespace Examples.ListView.Reorder
{
    public class Item : INotifyPropertyChanged
    {
        private string header;
        private bool isDone;

        public Item(string header, bool isDone = false)
        {
            this.header = header;
            this.isDone = isDone;
        }

        public string Header
        {
            get
            {
                return this.header;
            }
            set 
            {
                if (this.header != value)
                {
                    this.header = value;
                    this.OnPropertyChanged("Header");
                }
            }
        }

        public bool IsDone
        {
            get
            {
                return this.isDone;
            }
            set
            {
                if (this.isDone != value)
                {
                    this.isDone = value;
                    this.OnPropertyChanged("IsDone");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string p)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs(p));
            }
        }
    }
}