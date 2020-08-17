using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Popups;
using WindowsGemini.Models;

namespace WindowsGemini.ViewModels
{
    partial class MainViewModel
    {
        public ICommand StopScanCommand
        {
            get
            {
                return new CommandHandler(() => StopScanActionAsync());
            }
        }
        private async Task StopScanActionAsync()
        {
            StopScan = true;
        }
    }
}
