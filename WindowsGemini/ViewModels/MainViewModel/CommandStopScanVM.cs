using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.ApplicationModel.Resources;
using Windows.UI.Popups;
using WindowsGemini.Models;

namespace WindowsGemini.ViewModels
{
    partial class MainViewModel
    {
        public static ResourceLoader resourceLoader;
        public ICommand StopScanCommand
        {
            get
            {
                return new CommandHandler(async () => await StopScanActionAsync());
            }
        }
        private async Task StopScanActionAsync()
        {
            var content = resourceLoader.GetString("msgAskSureStopScan");

            var yesCommand = new UICommand(resourceLoader.GetString("msgYes"), cmd => { });
            var noCommand = new UICommand(resourceLoader.GetString("msgNo"), cmd => { });


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
                StopScanTokenSource.Cancel();
            }
        }
    }
}
