using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsGemini.Models.Settings;
using WindowsGemini.ViewModels.SettingsPageViewModel;

namespace WindowsGemini.ViewModels
{
    class MVVMLocator
    {
        private static MainViewModel mainVM;
        public static MainViewModel MainViewModel
        {
            get
            {
                if(mainVM == null)
                {
                    mainVM = new MainViewModel();
                }
                return mainVM;
            }
        }

        private static SettingsViewModel settingsVM;
        public static SettingsViewModel SettingsViewModel
        {
            get
            {
                if(settingsVM == null)
                {
                    settingsVM = new SettingsViewModel();
                }
                return settingsVM;
            }
        }

        private static AccentColorSettings colorsSettings;
        public static AccentColorSettings AccentColorSettings
        {
            get
            {
                if(colorsSettings == null)
                {
                    colorsSettings = new AccentColorSettings();
                }
                return new AccentColorSettings();
            }
        }

        public MVVMLocator()
        {

        }

    }
}
