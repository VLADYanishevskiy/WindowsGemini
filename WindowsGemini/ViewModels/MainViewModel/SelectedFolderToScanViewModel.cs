using Windows.Storage;

namespace WindowsGemini.ViewModels
{
    partial class MainViewModel
    {
        private static StorageFolder _selectedFolder;
        
        public StorageFolder SelectedFolder
        {
            get { return _selectedFolder; }
            set { _selectedFolder = value;
                NotifyPropertyChanged(nameof(SelectedFolder));
            }
        }
    }
}
