using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using WindowsGemini.ViewModels;
using Microsoft.Toolkit.Uwp.Helpers;
using ColorHelper = Microsoft.Toolkit.Uwp.Helpers.ColorHelper;
using Windows.UI.Xaml.Media;

namespace WindowsGemini.Models.Settings
{
    internal class AccentColorSettings : BaseViewModel
    {
        private static string _AccentColor ;
        public string AccentColor
        {
            get { return _AccentColor; }
            set {
                _AccentColor = value;
                CompositeSettings.localSettings.Values["AccentColor"] = _AccentColor;
                NotifyPropertyChanged(nameof(AccentColor));
            }
        }
        

        public AccentColorSettings()
        {
            if ((CompositeSettings.localSettings.Values["AccentColor"] as string) != null)
            {
                object obj = CompositeSettings.localSettings.Values["AccentColor"];
                AccentColor = (string)obj;
            }
            else
            {
                AccentColor = "#0078d7";
            }
        }
    }
}
