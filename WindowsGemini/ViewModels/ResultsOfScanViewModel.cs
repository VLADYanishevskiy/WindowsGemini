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
        public ulong VideoSize
        {
            get { return _videoSize; }
        }
        private ulong _audioSize;
        public ulong AudioSize
        {
            get { return _audioSize; }
        }
        private ulong _documentsSize;
        public ulong DocumentsSize
        {
            get { return _documentsSize; }
        }
        private ulong _archivesSize;
        public ulong ArchivesSize
        {
            get { return _archivesSize; }
        }
        public ObservableCollection<StorageFolder> Folders
        {
            get { return _folders; }
        }
        private ulong _otherSize;
        public ulong OtherSize
        {
            get { return _otherSize; }
        }
        public ulong _fullSizeOfDuplicates;
        public ulong FullSizeOfDuplicates
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


        private static async Task<ulong> GetFilesSizeInMB(ICollection<StorageFile> files)
        {
            ulong FilesSize = 0;

            foreach (var item in files)
            {
                FilesSize += await GetFileSizeInMB(item);
            }

            return FilesSize;
        }
        private static async Task<ulong> GetFileSizeInMB(StorageFile file)
        {
            var baseProperties = await file.GetBasicPropertiesAsync();
            var bytesSize = baseProperties.Size;

            
            //return bytesSize; // Bytes
            return bytesSize / 1024;//KB
            //return (bytesSize / 1024) / 1024; //MB
        }
        private static async Task<ulong> GetFileSizeInBytes(StorageFile file)
        {
            var baseProperties = await file.GetBasicPropertiesAsync();
            return baseProperties.Size;
        }
    }
}
