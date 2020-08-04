using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace WindowsGemini.ViewModels
{

    // Scan results
    partial class MainViewModel
    {
        private List<StorageFile> Images = new List<StorageFile>();
        private List<StorageFile> Video = new List<StorageFile>();
        private List<StorageFile> Audio = new List<StorageFile>();
        private List<StorageFile> Documents = new List<StorageFile>();
        private List<StorageFile> Archieves = new List<StorageFile>();
        private List<StorageFolder> Folders = new List<StorageFolder>();
        private List<StorageFile> Other = new List<StorageFile>();

    }
}
