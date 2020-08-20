using Prism.Commands;
using System;
using System.Linq;
using Windows.ApplicationModel.DataTransfer;
using Windows.Storage;
using Windows.UI.Xaml;

namespace WindowsGemini.ViewModels
{
    partial class MainViewModel 
    {
        public DelegateCommand<DragEventArgs> DragOverCommand { get; } = new DelegateCommand<DragEventArgs>(ExecuteDragOverCommand);
        private static void ExecuteDragOverCommand(DragEventArgs e)
        {
            e.AcceptedOperation = DataPackageOperation.Copy;
        }

        public DelegateCommand<DragEventArgs> DropCommand { get; } 
        private async void ExecuteDropCommandAsync(DragEventArgs e)
        {
            if (e.DataView.Contains(StandardDataFormats.StorageItems))
            {
                var items = await e.DataView.GetStorageItemsAsync();
                if (items.Count > 0)
                {
                    foreach (var appFile in items.OfType<StorageFolder>())
                    {
                        this.FoldersToScan.Add(appFile);
                    }
                }
            }
        }
    }
}
