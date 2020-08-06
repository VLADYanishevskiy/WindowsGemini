using Microsoft.Toolkit.Uwp.Helpers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Windows.Security.Authentication.Identity.Core;
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
                groupedFiles.Push(item);
            }

            foreach (var item in await folder.GetFoldersAsync())
            {
                await ScanFolder(item);
            }

            return;
        }

        private async Task FindDublicates()
        {
            Dictionary<ulong, List<StorageFile>> sortedFiles = new Dictionary<ulong, List<StorageFile>>();

            while(groupedFiles.Count > 0)
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


            foreach (var entry in sortedFiles){

                //var stackByMIMETYPE = entry.Value.GroupBy(file => file.FileType).ToList();

                for (int i = 0; i < entry.Value.Count(); i++)
                {
                    if (entry.Value[i] == null) continue;
                    bool hasduplicatesOfCurrentFile = false;

                    byte[] currentFileContent = await entry.Value[i].ReadBytesAsync();

                    for (int j = i + 1; j < entry.Value.Count(); j++)
                    {
                        if (entry.Value[j] != null)
                        {
                            if (entry.Value[i].FileType == entry.Value[j].FileType)
                            {

                                if (currentFileContent.SequenceEqual(await entry.Value[j].ReadBytesAsync()))
                                {
                                    hasduplicatesOfCurrentFile = true;
                                    _images.Add(entry.Value[j]);
                                    entry.Value[j] = null;
                                    // add duplicate to collection;
                                }

                            }
                        }
                    }

                    if (hasduplicatesOfCurrentFile)
                    {
                        _images.Add(entry.Value[i]);
                    }
                }


            }

            //foreach (KeyValuePair<string, List<StorageFile>> entry in groupedFiles)
            //{
            //    if (FileTypeChecker.IsImage(entry.Key))
            //    {
            //        var duplicates = entry.Value.GroupBy(file => new
            //        {
            //            file.Name,
            //            Size = GetFileSizeInMB(file),
            //            byteContent = FileEqualsChecker.GetFileContent(file)
            //        });

            //        continue;
            //    }
            //    //if (FileTypeChecker.IsDocument(entry.Key))
            //    //{
            //    //    for (int j = i + 1; j < entry.Value.Count; j++)
            //    //    {
            //    //        if (await checker.IsSameFile(entry.Value[i], entry.Value[j]))
            //    //        {
            //    //            _documents.Add(entry.Value[i]);
            //    //            _documents.Add(entry.Value[j]);
            //    //        }
            //    //    }
            //    //    continue;
            //    //}
            //    //if (FileTypeChecker.IsArchive(entry.Key))
            //    //{
            //    //    for (int j = i + 1; j < entry.Value.Count; j++)
            //    //    {
            //    //        if (await checker.IsSameFile(entry.Value[i], entry.Value[j]))
            //    //        {
            //    //            _archieves.Add(entry.Value[i]);
            //    //            _archieves.Add(entry.Value[j]);
            //    //        }
            //    //    }
            //    //    continue;
            //    //}
            //    //if (FileTypeChecker.IsVideo(entry.Key))
            //    //{
            //    //    for (int j = i + 1; j < entry.Value.Count; j++)
            //    //    {
            //    //        if (await checker.IsSameFile(entry.Value[i], entry.Value[j]))
            //    //        {
            //    //            _video.Add(entry.Value[i]);
            //    //            _video.Add(entry.Value[j]);
            //    //        }
            //    //    }
            //    //    continue;
            //    //}
            //    //if (FileTypeChecker.IsAudio(entry.Key))
            //    //{
            //    //    for (int j = i + 1; j < entry.Value.Count; j++)
            //    //    {
            //    //        if (await checker.IsSameFile(entry.Value[i], entry.Value[j]))
            //    //        {
            //    //            _audio.Add(entry.Value[i]);
            //    //            _audio.Add(entry.Value[j]);
            //    //        }
            //    //    }
            //    //    continue;
            //    //}
            //}
        }

        
    }
}
