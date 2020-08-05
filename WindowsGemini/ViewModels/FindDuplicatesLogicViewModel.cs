using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;
using WindowsGemini.Models;

namespace WindowsGemini.ViewModels
{
    partial class MainViewModel
    {
        private async Task ScanFolder(StorageFolder folder)
        {
            foreach (var item in await folder.GetFilesAsync())
            {
                if (!groupedFiles.ContainsKey(item.FileType))
                {
                    groupedFiles.Add(item.FileType, new List<StorageFile>() { item });
                }
                else
                {
                    groupedFiles[item.FileType].Add(item);
                }
            }

            foreach (var item in await folder.GetFoldersAsync())
            {
                await ScanFolder(item);
            }

            return;
        }

        private async Task FindDublicates()
        {
            var checker = new FileEqualsChecker();

            foreach (KeyValuePair<string, List<StorageFile>> entry in groupedFiles)
            {
                for (int i = 0; i < entry.Value.Count; i++)
                {
                    for (int j = i + 1; j < entry.Value.Count; j++)
                    {
                        bool isSame = await checker.IsSameFile(entry.Value[i], entry.Value[j]);
                        if (isSame)
                        {
                            if (FileTypeChecker.IsImage(entry.Value[i].FileType))
                            {
                                _images.Add(entry.Value[i]);
                                _images.Add(entry.Value[j]);
                                continue;
                            }
                            if (FileTypeChecker.IsDocument(entry.Value[i].FileType)){
                                _documents.Add(entry.Value[i]);
                                _documents.Add(entry.Value[j]);
                                continue;
                            }
                            if (FileTypeChecker.IsArchive(entry.Value[i].FileType))
                            {
                                _archieves.Add(entry.Value[i]);
                                _archieves.Add(entry.Value[j]);
                                continue;
                            }
                            if (FileTypeChecker.IsVideo(entry.Value[i].FileType))
                            {
                                _video.Add(entry.Value[i]);
                                _video.Add(entry.Value[j]);
                                continue;
                            }
                            if (FileTypeChecker.IsAudio(entry.Value[i].FileType))
                            {
                                _audio.Add(entry.Value[i]);
                                _audio.Add(entry.Value[j]);
                                continue;
                            }

                            _other.Add(entry.Value[i]);
                            _other.Add(entry.Value[j]);

                        }
                    }
                }
            }
        }

        
    }
}
