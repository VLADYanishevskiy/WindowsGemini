using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Windows.Storage;

namespace WindowsGemini.ViewModels
{
    partial class MainViewModel
    {
        private ObservableCollection<StorageFile> _images = new ObservableCollection<StorageFile>();
        private ObservableCollection<StorageFile> _video = new ObservableCollection<StorageFile>();
        private ObservableCollection<StorageFile> _audio = new ObservableCollection<StorageFile>();
        private ObservableCollection<StorageFile> _documents = new ObservableCollection<StorageFile>();
        private ObservableCollection<StorageFile> _archieves = new ObservableCollection<StorageFile>();
        private ObservableCollection<StorageFolder> _folders = new ObservableCollection<StorageFolder>();
        private ObservableCollection<StorageFile> _other = new ObservableCollection<StorageFile>();

        private double _imagesSize;
        public double ImagesSize
        {
            get {
                return _imagesSize; 
            }
        }
        private double _videoSize;
        public double VideoSize
        {
            get { return _videoSize; }
        }
        private double _audioSize;
        public double AudioSize
        {
            get { return _audioSize; }
        }
        private double _documentsSize;
        public double DocumentsSize
        {
            get { return _documentsSize; }
        }
        private double _archivesSize;
        public double ArchivesSize
        {
            get { return _archivesSize; }
        }
        public ObservableCollection<StorageFolder> Folders
        {
            get { return _folders; }
        }
        private double _otherSize;
        public double OtherSize
        {
            get { return _otherSize; }
        }
        public double _fullSizeOfDuplicates;
        public double FullSizeOfDuplicates
        {
            get { return _fullSizeOfDuplicates; }
        }

        private async void Notify_Results_Collection_Completed()
        {
            _imagesSize = await GetFilesSizeInMB(_images);
            _videoSize = await GetFilesSizeInMB(_video);
            _audioSize = await GetFilesSizeInMB(_audio);
            _documentsSize = await GetFilesSizeInMB(_documents);
            _archivesSize = await GetFilesSizeInMB(_archieves);
            _otherSize = await GetFilesSizeInMB(_other);
            _fullSizeOfDuplicates = _imagesSize + _videoSize + _audioSize + _documentsSize + _archivesSize + _otherSize;
            NotifyPropertyChanged(nameof(ImagesSize));
            NotifyPropertyChanged(nameof(VideoSize));
            NotifyPropertyChanged(nameof(AudioSize));
            NotifyPropertyChanged(nameof(DocumentsSize));
            NotifyPropertyChanged(nameof(ArchivesSize));
            //NotifyPropertyChanged("Folders");
            NotifyPropertyChanged(nameof(OtherSize));
            NotifyPropertyChanged(nameof(FullSizeOfDuplicates));
        }

        private static async Task<double> GetFilesSizeInMB(ICollection<StorageFile> files)
        {
            double FilesSize = 0;

            foreach (var item in files)
            {
                FilesSize += await GetFileSizeInMB(item);
            }

            return FilesSize;
        }
        private static async Task<double> GetFileSizeInMB(StorageFile file)
        {
            var baseProperties = await file.GetBasicPropertiesAsync();
            var bytesSize = baseProperties.Size;
            
            return (bytesSize / 1024) / 1024; //MB
        }
        private static async Task<ulong> GetFileSizeInBytes(StorageFile file)
        {
            var baseProperties = await file.GetBasicPropertiesAsync();
            return baseProperties.Size;
        }
    }
}
