using System;
using Windows.UI.Xaml;
using WindowsGemini.Models.Settings;

namespace WindowsGemini.Models
{
    class ThemeSettingsController
    {
        private static ApplTheme _applicationTheme;
        public static ApplTheme ApplicationTheme
        {
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

        public static void LoadTheme()
        {
            if ((CompositeSettings.localSettings.Values["ApplicationTheme"] as string) != null)
            {
                object obj = CompositeSettings.localSettings.Values["ApplicationTheme"];
                ApplicationTheme = (ApplTheme)Enum.Parse(typeof(ApplTheme), obj.ToString());
            }
            else
            {
                ApplicationTheme = ApplTheme.UseDefault;
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
