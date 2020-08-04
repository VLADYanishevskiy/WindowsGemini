using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml;
using WindowsGemini.Models;

namespace WindowsGemini.ViewModels
{
    partial class MainViewModel
    {
        public ICommand startNewScanCommand
        {
            get
            {
                return new CommandHandler(() => this.StartNewScanAction());
            }
        }
        private async void StartNewScanAction()
        {
            Images.Clear();
            Video.Clear();
            Audio.Clear();
            Documents.Clear();
            Archieves.Clear();
            Folders.Clear();
            Other.Clear();
            StackPanelNewScanVisibility = Visibility.Visible;
            StackPanelResultsScanVisibility = Visibility.Collapsed;
            SelectedFolder = null;
        }
    }
}
