using Prism.Commands;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using Windows.Storage;
using Windows.UI.Xaml;
using WindowsGemini.Models;
using WindowsGemini.Models.Settings;

namespace WindowsGemini.ViewModels
{

    partial class MainViewModel : BaseViewModel
    {
        Stack<StorageFile> groupedFiles;

        private readonly ObservableCollection<StorageFolder> _includeFolders;
        public ObservableCollection<StorageFolder> FoldersToScan
        {
            get { return _includeFolders; }
        }

        public MainViewModel()
        {
            resourceLoader = Windows.ApplicationModel.Resources.ResourceLoader.GetForCurrentView("Resources");
            StateOfScanning = 0;
            _includeFolders = new ObservableCollection<StorageFolder>();
            _includeFolders.CollectionChanged += IncludeFolders_CollectionChanged;
            groupedFiles = new Stack<StorageFile>();
            DropCommand = new DelegateCommand<DragEventArgs>(ExecuteDropCommandAsync);
            ThemeSettingsController.LoadTheme();
        }

        private void IncludeFolders_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            NotifyPropertyChanged(nameof(FoldersToScan));
            NotifyPropertyChanged(nameof(txbMainPageHello));
            NotifyPropertyChanged(nameof(txbMainPageWelcomeTo));
            NotifyPropertyChanged(nameof(txbMainPageSomeNameApp));
            NotifyPropertyChanged(nameof(txbMainPageHintPlusOrPressButoonTop));
            NotifyPropertyChanged(nameof(txbMainPageHintPlusOrPressButoonBottom));
            NotifyPropertyChanged(nameof(GridWithBtnAddAndListOfFolderVisibility));
            NotifyPropertyChanged(nameof(BtnBigPlusAddFolder));
            NotifyPropertyChanged(nameof(GridWithBtnAddAndListOfFolderVisibility));
        }
    }
}
