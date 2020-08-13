using Microsoft.Toolkit.Uwp.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Media;
using WindowsGemini.Models.Settings;

namespace WindowsGemini.ViewModels.SettingsPageViewModel
{
    class SettingsViewModel : BaseViewModel
    {
        DeletionMode mode = DeletionMode.SendToTecycleBin;

        private ObservableCollection<string> _accentColors = new ObservableCollection<string>() {
            "#f7630c" , "#ff4343",
            "#ea005e" , "#b146c2",
            "#107c10" , "#0078d7", };
        public ObservableCollection<string> AccentColors
        {
            get { return _accentColors; }
            set { _accentColors = value; }
        }
    }
}
