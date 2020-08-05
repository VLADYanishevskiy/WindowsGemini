using System;
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


        public ObservableCollection<StorageFile> Images
        {
            get { return _images; }
        }
        public ObservableCollection<StorageFile> Video
        {
            get { return _video; }
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

    }
}
