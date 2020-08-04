using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.UI.Xaml;

namespace WindowsGemini.ViewModels
{
    partial class MainViewModel
    {
        public Visibility BtnBigPlusAddFolder
        {
            get
            {
                return FoldersToScan.Count == 0 ? Visibility.Visible : Visibility.Collapsed;
            }
        }

        public Visibility GridWithBtnAddAndListOfFolderVisibility
        {
            get
            {
                return FoldersToScan.Count == 0 ? Visibility.Collapsed : Visibility.Visible;
            }
        }
    }
}
