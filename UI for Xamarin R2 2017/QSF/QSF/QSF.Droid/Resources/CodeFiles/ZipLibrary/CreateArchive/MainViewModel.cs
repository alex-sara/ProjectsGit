using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows.Input;
using Examples.Helpers;
using Telerik.XamarinForms.DataControls.ListView;
using Telerik.Zip;
using Xamarin.Forms;

namespace Examples.ZipLibrary.CreateArchive
{
    public class MainViewModel : ViewModelBase
    {
        private ObservableCollection<FileViewModel> files;
        private ICommand itemTapCommand;
        private ICommand createArchiveCommand;
        private ICommand goBackCommand;

        public MainViewModel()
        {
            this.Files = new ObservableCollection<FileViewModel>(this.GetSampleFiles());
            this.ItemTapCommand = new Command(this.ItemTap);
            this.CreateArchiveCommand = new Command(this.CreateArchive);
            this.GoBackCommand = new Command(this.GoBack);
        }

        public event EventHandler OnNavigateBackRequested;

        public ObservableCollection<FileViewModel> Files
        {
            get
            {
                return this.files;
            }
            private set
            {
                if (this.files != value)
                {
                    this.files = value;
                    this.OnPropertyChanged();
                }
            }
        }

        public ICommand ItemTapCommand
        {
            get
            {
                return this.itemTapCommand;
            }
            private set
            {
                if (this.itemTapCommand != value)
                {
                    this.itemTapCommand = value;
                    this.OnPropertyChanged();
                }
            }
        }

        public ICommand CreateArchiveCommand
        {
            get
            {
                return this.createArchiveCommand;
            }
            private set
            {
                if (this.createArchiveCommand != value)
                {
                    this.createArchiveCommand = value;
                    this.OnPropertyChanged();
                }
            }
        }

        public ICommand GoBackCommand
        {
            get
            {
                return this.goBackCommand;
            }
            private set
            {
                if (this.goBackCommand != value)
                {
                    this.goBackCommand = value;
                    this.OnPropertyChanged();
                }
            }
        }

        private IEnumerable<FileViewModel> GetSampleFiles()
        {
            var resourceNames = ResourceHelper.GetResourceNamesFromFolder("ZipSampleDocuments").OrderBy(p => p).ToArray();

            foreach (var resourceName in resourceNames)
            {
                yield return new FileViewModel(resourceName);
            }
        }

        private void ItemTap(object obj)
        {
            ItemTapEventArgs commandContext = (ItemTapEventArgs)obj;

            var file = (FileViewModel)commandContext.Item;

            file.IsSelected = !file.IsSelected;
        }

        private async void CreateArchive(object obj)
        {
            var selectedItems = this.Files.Where(p => p.IsSelected);

            if (!selectedItems.Any())
            {
                return;
            }

            using (MemoryStream stream = new MemoryStream())
            {
                using (ZipArchive archive = new ZipArchive(stream, ZipArchiveMode.Create, true, null))
                {
                    foreach (var selectedItem in selectedItems)
                    {
                        var fileName = selectedItem.FileName + selectedItem.FileExtension;
                        using (ZipArchiveEntry entry = archive.CreateEntry(fileName))
                        {
                            using (Stream fileStream = ResourceHelper.GetResourceStream(fileName))
                            {
                                using (Stream entryStream = entry.Open())
                                {
                                    fileStream.CopyTo(entryStream);
                                }
                            }
                        }
                    }
                }

                await DependencyService.Get<IFileViewer>().View(stream, "archive.zip");
            }
        }

        private void GoBack(object obj)
        {
            this.OnNavigateBackRequested?.Invoke(this, EventArgs.Empty);
        }
    }
}