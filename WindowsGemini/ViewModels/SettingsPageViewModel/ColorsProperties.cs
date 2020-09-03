using WindowsGemini.Models.Settings;
using System;

namespace WindowsGemini.ViewModels.SettingsPageViewModel
{
    partial class SettingsViewModel
    {
        private AccentColors _colors;

        public AccentColors Colors
        {
            get
            {
                return _colors;
            }
            set
            {
                _colors = value;
                switch (value)
                {
                    case AccentColors.Orange:
                        MVVMLocator.AccentColorSettings.AccentColor = "#f7630c";
                        break;
                    case AccentColors.Corral:
                        MVVMLocator.AccentColorSettings.AccentColor = "#ff4343";
                        break;
                    case AccentColors.Red:
                        MVVMLocator.AccentColorSettings.AccentColor = "#ea005e";
                        break;
                    case AccentColors.Purple:
                        MVVMLocator.AccentColorSettings.AccentColor = "#b146c2";
                        break;
                    case AccentColors.Green:
                        MVVMLocator.AccentColorSettings.AccentColor = "#107c10";
                        break;
                    case AccentColors.Blue:
                        MVVMLocator.AccentColorSettings.AccentColor = "#0078d7";
                        break;
                    default:
                        break;
                }
                CompositeSettings.localSettings.Values["CurrentAccentColor"] = value.ToString();
            }
        }
    }
}
