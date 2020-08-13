using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Popups;
using WindowsGemini.Models;
using WindowsGemini.ViewModels;

namespace WindowsGemini.ViewModels
{
    partial class MainViewModel
    {
        private async void StartScanningSelectedFolderAction()
        {
            if (SelectedFolder == null)
            {
                MessageDialog msg = new MessageDialog("Select at least one folder.");
                await msg.ShowAsync();
            }
            else
            {
                StopScan = false;
                groupedFiles.Clear();
                ClearStatsOfScanning();

                _state_scanning_comparing_files();

                await ScanFolder(SelectedFolder);
                await FindDublicates();

                Notify_Results_Collection_Completed();

                _state_scanning_finished();

                //StackPanelNewScanVisibility = Windows.UI.Xaml.Visibility.Collapsed;
                //StackPanelResultsScanVisibility = Windows.UI.Xaml.Visibility.Visible;
            }
        }

        public ICommand StartScanningSelectedFolderCommand
        {
            get
            {
                return new CommandHandler(() => this.StartScanningSelectedFolderAction());
            }
        }
    }
}
