﻿using Prism.Commands;
using System.Collections.ObjectModel;
using System.Reflection.Metadata.Ecma335;
using System.Windows.Input;
using Windows.UI.Popups;
using WindowsGemini.Models;

namespace WindowsGemini.ViewModels.SettingsPageViewModel
{
    // Accent colors
    partial class SettingsViewModel
    {
        private ObservableCollection<string> _accentColors = new ObservableCollection<string>() {
            "#f7630c" , "#ff4343",
            "#ea005e" , "#b146c2",
            "#107c10" , "#0078d7", };
        public ObservableCollection<string> AccentColors
        {
            get { return _accentColors; }
            set { _accentColors = value; }
        }
        public string CurrentAccentColor {
            get
            {
                return CurrentAccentColor;
            }
            set
            {
            }
        }
       
       
    }
}
