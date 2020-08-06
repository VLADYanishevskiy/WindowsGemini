using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.VoiceCommands;
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



        private ulong _imagesSize;
        public ulong ImagesSize
        {
            get {
                return _imagesSize; 
            }
        }
        private ulong _videoSize;
        public ulong Video
        {
            get { return _videoSize; }
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

        private async void Notify_Results_Collection_Completed()
        {
            _imagesSize = await GetFilesSizeInMB(_images);
            _videoSize = await GetFilesSizeInMB(_video);
            NotifyPropertyChanged("ImagesSize");
            NotifyPropertyChanged("Video");
            //NotifyPropertyChanged("Audio");
            //NotifyPropertyChanged("Documents");
            //NotifyPropertyChanged("Archives");
            //NotifyPropertyChanged("Folders");
            //NotifyPropertyChanged("Other");
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
        private async Task<ulong> GetFileSizeInBytes(StorageFile file)
        {
            var baseProperties = await file.GetBasicPropertiesAsync();
            return baseProperties.Size;
        }
    }
}
