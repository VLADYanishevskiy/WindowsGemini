using WindowsGemini.Models;

namespace WindowsGemini.ViewModels.SettingsPageViewModel
{
    partial class SettingsViewModel
    {
        public ApplTheme ApplicationTheme
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
