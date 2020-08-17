using Microsoft.Toolkit.Uwp.UI.Animations.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using WindowsGemini.Models.Settings;

namespace WindowsGemini.ViewModels.SettingsPageViewModel
{
    partial class SettingsViewModel
    {
        private ApplTheme _applicationTheme; 
        public ApplTheme ApplicationTheme {
            get
            {
                return _applicationTheme;
            }
            set
            {
                _applicationTheme = value;
                CompositeSettings.localSettings.Values["ApplicationTheme"] = _applicationTheme.ToString();

                switch (_applicationTheme)
                {
                    case ApplTheme.Light:
                        Application.Current.RequestedTheme = Windows.UI.Xaml.ApplicationTheme.Light;
                        break;
                    case ApplTheme.Dark:
                        Application.Current.RequestedTheme = Windows.UI.Xaml.ApplicationTheme.Dark;
                        break;
                    case ApplTheme.UseDefault:
                        //Application.Current.RequestedTheme = Windows.UI.Xaml.ApplicationTheme;
                        break;
                    default:
                        break;
                }

            }
        }
    }
    public enum ApplTheme
    {
        Light,
        Dark,
        UseDefault
    }
}
