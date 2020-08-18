using Microsoft.Toolkit.Uwp.UI.Animations.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using WindowsGemini.Models;
using WindowsGemini.Models.Settings;

namespace WindowsGemini.ViewModels.SettingsPageViewModel
{
    partial class SettingsViewModel
    {
        public static ApplTheme ApplicationTheme
        {
            get
            {
                return ThemeSettingsController.ApplicationTheme;
            }
            set
            {
                ThemeSettingsController.ApplicationTheme = value;
            }
        }
    }
    
}
