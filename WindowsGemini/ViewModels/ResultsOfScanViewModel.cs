using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace WindowsGemini.ViewModels
{

    // Scan results
    partial class MainViewModel
    {
        private ObservableCollection<StorageFile> _images = new ObservableCollection<StorageFile>();
        private ObservableCollection<StorageFile> _video = new ObservableCollection<StorageFile>();
        private ObservableCollection<StorageFile> _audio = new ObservableCollection<StorageFile>();
        private ObservableCollection<StorageFile> _documents = new ObservableCollection<StorageFile>();
        private ObservableCollection<StorageFile> _archieves = new ObservableCollection<StorageFile>();
        private ObservableCollection<StorageFolder> _folders = new ObservableCollection<StorageFolder>();
        private ObservableCollection<StorageFile> _other = new ObservableCollection<StorageFile>();


        public Task<ulong> Images
        {
            get {
                return GetFilesSizeInMB(_images); 
            }
        }
        public Task<ulong> Video
        {
            get { return GetFilesSizeInMB(_video); }
        }
        public ObservableCollection<StorageFile> Audio
        {
            get { return _audio; }
        }
        public ObservableCollection<StorageFile> Documents
        {
            get { return _documents; }
        }
        public ObservableCollection<StorageFile> Archives
        {
            get { return _archieves; }
        }
        public ObservableCollection<StorageFolder> Folders
        {
            get { return _folders; }
        }
        public ObservableCollection<StorageFile> Other
        {
            get { return _other; }
        }

        private void Images_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            NotifyPropertyChanged("Images");
        }
        private void Video_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            NotifyPropertyChanged("Video");
        }
        private void Audio_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            NotifyPropertyChanged("Audio");
        }
        private void Documents_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            NotifyPropertyChanged("Documents");
        }
        private void Archieves_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            NotifyPropertyChanged("Archives");
        }
        private void Folders_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            NotifyPropertyChanged("Folders");
        }
        private void Other_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            NotifyPropertyChanged("Other");
        }



        private async Task<ulong> GetFilesSizeInMB(ICollection<StorageFile> files)
        {
            ulong FilesSize = 0;

            foreach (var item in files)
            {
                FilesSize += await GetFileSizeInMB(item);
            }

            return FilesSize;
        }
        private async Task<ulong> GetFileSizeInMB(StorageFile file)
        {
            var baseProperties = await file.GetBasicPropertiesAsync();
            var bytesSize = baseProperties.Size;

            return (bytesSize / 1024) / 1024;
        }
    }
}
