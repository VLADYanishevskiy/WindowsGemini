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
                                Images.Add(entry.Value[i]);
                                Images.Add(entry.Value[j]);
                                continue;
                            }
                            if (FileTypeChecker.IsDocument(entry.Value[i].FileType)){
                                Documents.Add(entry.Value[i]);
                                Documents.Add(entry.Value[j]);
                                continue;
                            }
                            if (FileTypeChecker.IsArchive(entry.Value[i].FileType))
                            {
                                Archieves.Add(entry.Value[i]);
                                Archieves.Add(entry.Value[j]);
                                continue;
                            }
                            if (FileTypeChecker.IsVideo(entry.Value[i].FileType))
                            {
                                Video.Add(entry.Value[i]);
                                Video.Add(entry.Value[j]);
                                continue;
                            }
                            if (FileTypeChecker.IsAudio(entry.Value[i].FileType))
                            {
                                Audio.Add(entry.Value[i]);
                                Audio.Add(entry.Value[j]);
                                continue;
                            }

                            Other.Add(entry.Value[i]);
                            Other.Add(entry.Value[j]);

                        }
                    }
                }
            }
        }

        
    }
}
