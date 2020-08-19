using Microsoft.Toolkit.Uwp.Helpers;
using Prism.Commands;
using System;
using System.Collections;
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
using Windows.UI;
using Windows.UI.Popups;
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
            Application.Current.Resources["AccentColorSettings"] = new AccentColorSettings();
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
