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
            var content = "Are you sure you want to stop scanning?";

            var yesCommand = new UICommand("Yes", cmd => { });
            var noCommand = new UICommand("No", cmd => { });

           
            var dialog = new MessageDialog(content);
            dialog.Options = MessageDialogOptions.None;
            dialog.Commands.Add(yesCommand);

            dialog.DefaultCommandIndex = 0;
            dialog.CancelCommandIndex = 0;

            if (noCommand != null)
            {
                dialog.Commands.Add(noCommand);
                dialog.CancelCommandIndex = (uint)dialog.Commands.Count - 1;
            }

            var command = await dialog.ShowAsync();

            if (command == yesCommand)
            {
                // handle yes command
            }
            else if (command == noCommand)
            {
                // handle no command
            }
        }
    }
}
