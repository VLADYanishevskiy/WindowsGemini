using Microsoft.Toolkit.Uwp.Helpers;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.Xaml.Media;
using WindowsGemini.Models.Settings;

namespace WindowsGemini.ViewModels.SettingsPageViewModel
{
    partial class SettingsViewModel : BaseViewModel
    {
        public SettingsViewModel()
        {
            SetColorCommand =  new DelegateCommand<object>(SetColor);
            if ((CompositeSettings.localSettings.Values["ApplicationTheme"] as string) != null)
            {
                object obj = CompositeSettings.localSettings.Values["ApplicationTheme"];
                _applicationTheme = (ApplTheme)Enum.Parse(typeof(ApplTheme), obj.ToString());
            }
            else
            {
                _applicationTheme = ApplTheme.UseDefault;

            }
        }
        

    }
}
