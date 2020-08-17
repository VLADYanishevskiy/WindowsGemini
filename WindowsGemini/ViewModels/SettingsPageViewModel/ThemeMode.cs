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

                if (Window.Current.Content is FrameworkElement frameworkElement)
                {
                    switch (_applicationTheme)
                    {
                        case ApplTheme.Light:
                            frameworkElement.RequestedTheme = ElementTheme.Light;
                            break;
                        case ApplTheme.Dark:
                            frameworkElement.RequestedTheme = ElementTheme.Dark;
                            break;
                        case ApplTheme.UseDefault:
                            frameworkElement.RequestedTheme = ElementTheme.Default;
                            break;
                        default:
                            break;
                    }
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
