using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using WindowsGemini.Models;

namespace WindowsGemini.ViewModels
{

    partial class MainViewModel : BaseViewModel
    {

        Dictionary<string, List<StorageFile>> groupedFiles;

        private readonly ObservableCollection<StorageFolder> _includeFolders;
        public ObservableCollection<StorageFolder> FoldersToScan
        {
            get { return _includeFolders; }
        }



        public MainViewModel()
        {
            _includeFolders = new ObservableCollection<StorageFolder>();
            _includeFolders.CollectionChanged += IncludeFolders_CollectionChanged;
            groupedFiles = new Dictionary<string, List<StorageFile>>();
            _stackPanelNewScanVisibility = Visibility.Visible;
            _stackPanelResultsScanVisibility = Visibility.Collapsed;
        }

        private void IncludeFolders_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            NotifyPropertyChanged("FoldersToScan");
            NotifyPropertyChanged("txbMainPageHello");
            NotifyPropertyChanged("txbMainPageWelcomeTo");
            NotifyPropertyChanged("txbMainPageSomeNameApp");
            NotifyPropertyChanged("txbMainPageHintPlusOrPressButoonTop");
            NotifyPropertyChanged("txbMainPageHintPlusOrPressButoonBottom");
            NotifyPropertyChanged("GridWithBtnAddAndListOfFolderVisibility");
            NotifyPropertyChanged("BtnBigPlusAddFolder");
            NotifyPropertyChanged("GridWithBtnAddAndListOfFolderVisibility");
        }

    }
}
