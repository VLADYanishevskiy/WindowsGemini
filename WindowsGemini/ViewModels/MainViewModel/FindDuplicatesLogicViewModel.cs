using Microsoft.Toolkit.Uwp.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Popups;
using WindowsGemini.Models;

namespace WindowsGemini.ViewModels
{
    partial class MainViewModel
    {
        private bool StopScan = false;
        private bool StopFindScan = false;

        private int _countOfFiles = 0;
        public int CountOfFiles
        {
            get { return _countOfFiles; }
            set { _countOfFiles = value;
                NotifyPropertyChanged(nameof(CountOfFiles));
            }
        }

        private int _countOfCheckedFiles;
        public int CountOfCheckedFiles
        {
            get { return _countOfCheckedFiles; }
            set { 
                if(value <= CountOfFiles)
                    _countOfCheckedFiles = value;
                NotifyPropertyChanged(nameof(CountOfCheckedFiles));
            }
        }

        private string _currentCheckingFile;
        public string CurrentCheckingFile
        {
            get { return _currentCheckingFile; }
            set { _currentCheckingFile = value;
                NotifyPropertyChanged(nameof(CurrentCheckingFile));
            }
        }

        private void ClearStatsOfScanning()
        {
            CountOfCheckedFiles = 0;
            CountOfFiles = 0;
            CurrentCheckingFile = "";
        }

        private async Task ScanFolder(StorageFolder folder)
        {
            //if (StopFindScan == true) return;

            //if (StopScan == true && StopFindScan == false)
            //{
            //    bool askToStopResult = await AskToStop();
            //    if (askToStopResult == true)
            //    {
            //        StopFindScan = true;
            //    }
            //}

            foreach (var item in await folder.GetFilesAsync())
            {
                if (StopFindScan == true) return;
                groupedFiles.Push(item);
                CountOfFiles++;
                CurrentCheckingFile = "Founded : " + item.Path;
            }

            foreach (var item in await folder.GetFoldersAsync())
            {
                await ScanFolder(item);
            }

            return;
        }

        private async Task FindDublicates()
        {
            if (StopFindScan == true) return;
            Dictionary<ulong, List<StorageFile>> sortedFiles = new Dictionary<ulong, List<StorageFile>>();

            while (groupedFiles.Count > 0)
            {
                ulong fileSize = await GetFileSizeInBytes(groupedFiles.Peek());

                if (!sortedFiles.Keys.Contains(fileSize))
                    sortedFiles.Add(fileSize, new List<StorageFile>());

                sortedFiles[fileSize].Add(groupedFiles.Pop());
            }
            groupedFiles.Clear();


            var toRemove = sortedFiles.Where(pair => pair.Value.Count == 1)
                         .Select(pair => pair.Key)
                         .ToList();

            foreach (var key in toRemove)
            {
                sortedFiles.Remove(key);
            }

            toRemove = null;
            GC.Collect();

            CountOfFiles = sortedFiles.Count;

            foreach (var entry in sortedFiles)
            {
                for (int i = 0; i < entry.Value.Count && StopScan == false ; i++)
                {
                    if (entry.Value[i] == null) continue;
                    bool hasduplicatesOfCurrentFile = false;

                    byte[] currentFileContent = await entry.Value[i].ReadBytesAsync();

                    for (int j = i + 1; j < entry.Value.Count ; j++)
                    {
                        if (StopScan == true)
                        {
                            bool askToStopResult = await AskToStop();
                            if (askToStopResult == true)
                            {
                                break;
                            }
                            else
                            {
                                StopScan = false;
                            }
                        }

                        if (entry.Value[j] != null)
                        {
                            CountOfCheckedFiles++;
                            CurrentCheckingFile = entry.Value[j].Path;
                            if (entry.Value[i].FileType == entry.Value[j].FileType)
                            {
                                if (currentFileContent.SequenceEqual(await entry.Value[j].ReadBytesAsync()))
                                {
                                    hasduplicatesOfCurrentFile = true;
                                    AddDuplicateToResultFolder(entry.Value[j]);
                                    entry.Value[j] = null;
                                }
                            }
                        }
                    }

                    if (hasduplicatesOfCurrentFile)
                    {
                        AddDuplicateToResultFolder(entry.Value[i]);
                    }
                }
            }
        }

        private void AddDuplicateToResultFolder(StorageFile file)
        {
            if (FileTypeChecker.IsImage(file.FileType))
            {
                _images.Add(file);
            }
            else if (FileTypeChecker.IsVideo(file.FileType))
            {
                _video.Add(file);
            }
            else if (FileTypeChecker.IsDocument(file.FileType))
            {
                _documents.Add(file);
            }
            else if (FileTypeChecker.IsAudio(file.FileType))
            {
                _audio.Add(file);
            }
            else if (FileTypeChecker.IsArchive(file.FileType))
            {
                _archieves.Add(file);
            }
            else
            {
                _other.Add(file);
            }
        }
        

        private static async Task<bool> AskToStop()
        {
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
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
