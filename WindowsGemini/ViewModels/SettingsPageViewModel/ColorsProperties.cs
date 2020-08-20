using Prism.Commands;
using System.Collections.ObjectModel;
using System.Reflection.Metadata.Ecma335;
using System.Windows.Input;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;
using WindowsGemini.Models;
using Microsoft.Toolkit.Uwp.Helpers;
using System.ComponentModel.DataAnnotations;
using WindowsGemini.Models.Settings;
using System;

namespace WindowsGemini.ViewModels.SettingsPageViewModel
{
    // Accent colors
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
