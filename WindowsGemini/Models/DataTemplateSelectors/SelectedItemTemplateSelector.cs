using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using WindowsGemini.ViewModels;

namespace WindowsGemini.Models.DataTemplateSelectors
{
    class SelectedItemTemplateSelector : DataTemplateSelector
    {
        public DataTemplate Normal { get; set; }
        public DataTemplate Accent { get; set; }

        protected override DataTemplate SelectTemplateCore(object item)
        {
            //if (MainViewModel.SelectedFolderWithoutNotify != null)
            //{
            //    if ((item as StorageFolder).FolderRelativeId == MainViewModel.SelectedFolderWithoutNotify.FolderRelativeId)
            //    {
            //        return Accent;
            //    }
            //}
            return Normal;
        }
    }
}
