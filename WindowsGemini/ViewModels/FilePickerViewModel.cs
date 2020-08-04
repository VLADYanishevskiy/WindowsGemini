using System;
using System.Windows.Input;
using Windows.Storage;
using Windows.Storage.Pickers;
using WindowsGemini.Models;

namespace WindowsGemini.ViewModels
{
    partial class MainViewModel
    {
        public ICommand OpenFilePickerCommand
        {
            get
            {
                return new CommandHandler(() => this.OpenFilePickerAction());
            }
        }
        private async void OpenFilePickerAction()
        {
            var folderPicker = new FolderPicker();
            folderPicker.SuggestedStartLocation = PickerLocationId.Desktop;
            folderPicker.FileTypeFilter.Add("*");

            StorageFolder folder = await folderPicker.PickSingleFolderAsync();
            if (folder != null)
            {
                Windows.Storage.AccessCache.StorageApplicationPermissions.
                FutureAccessList.AddOrReplace("PickedFolderToken", folder);
                FoldersToScan.Add(folder);
            }
        }

    }
}
