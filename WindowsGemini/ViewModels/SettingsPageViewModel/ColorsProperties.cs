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
                return (AccentColors)Enum.Parse(typeof(AccentColors), CompositeSettings.localSettings.Values["CurrentAccentColor"].ToString());
            }
            set
            {
                _colors = value;
                switch (value)
                {
                    case AccentColors.Orange:
                        AccentColorSettings.AccentColor = "#f7630c";
                        break;
                    case AccentColors.Corral:
                        AccentColorSettings.AccentColor = "#ff4343";
                        break;
                    case AccentColors.Red:
                        AccentColorSettings.AccentColor = "#ea005e";
                        break;
                    case AccentColors.Purple:
                        AccentColorSettings.AccentColor = "#b146c2";
                        break;
                    case AccentColors.Green:
                        AccentColorSettings.AccentColor = "#107c10";
                        break;
                    case AccentColors.Blue:
                        AccentColorSettings.AccentColor = "#0078d7";
                        break;
                    default:
                        break;
                }
                CompositeSettings.localSettings.Values["CurrentAccentColor"] = value.ToString();
            }
        }
    }
}
