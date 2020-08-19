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
                return "";
            }
            set
            {
                ((SolidColorBrush)App.Current.Resources["GeneralBlueWhiteButtonBackground"]).Color = ColorHelper.ToColor(value);// = new SolidColorBrush(Colors.Red);
            }
        }

        public DelegateCommand<string> SetColorCommand { get; }

        private void ExecuteColorCommand(string e)
        {
            AccentColorSettings.AccentColor = e;
        }
    }
}
