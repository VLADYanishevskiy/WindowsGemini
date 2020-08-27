using System;
using WindowsGemini.Models.Settings;

namespace WindowsGemini.ViewModels.SettingsPageViewModel
{
    partial class SettingsViewModel : BaseViewModel
    {
        public SettingsViewModel()
        {
            if(CompositeSettings.localSettings.Values["DeleTionMode"] != null)
                _deletionMode = (DeletionMode)Enum.Parse(typeof(DeletionMode),
                    CompositeSettings.localSettings.Values["DeleTionMode"].ToString());
            else
                _deletionMode = DeletionMode.SendToTecycleBin;


            if(CompositeSettings.localSettings.Values["CurrentAccentColor"] != null)
            {
                _colors = (AccentColors)Enum.Parse(typeof(AccentColors), 
                    CompositeSettings.localSettings.Values["CurrentAccentColor"].ToString());
            }
            else
            {
                Colors = AccentColors.Blue;
            }

        }
    }
}
