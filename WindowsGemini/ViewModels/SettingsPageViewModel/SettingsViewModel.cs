using System;
using System.Collections.ObjectModel;
using Windows.Globalization;
using WindowsGemini.Models;
using WindowsGemini.Models.Settings;
using Language = WindowsGemini.Models.Language;

namespace WindowsGemini.ViewModels.SettingsPageViewModel
{
    partial class SettingsViewModel : BaseViewModel
    {
        private ObservableCollection<Language> _languages;
        public ObservableCollection<Language> Languages
        {
            get => _languages;
            set
            {
                _languages = value;
                NotifyPropertyChanged(nameof(Languages));
            }
        }
        private Language appLanguage;
        public Language AppLanguage
        {
            get
            {
                return appLanguage;
            }
            set
            {
                appLanguage = value;
                ApplicationLanguages.PrimaryLanguageOverride = appLanguage.LanguageCode;
            }
        }

        public SettingsViewModel()
        {
            if (CompositeSettings.localSettings.Values["DeleTionMode"] != null)
                _deletionMode = (DeletionMode)Enum.Parse(typeof(DeletionMode),
                    CompositeSettings.localSettings.Values["DeleTionMode"].ToString());
            else
                _deletionMode = DeletionMode.SendToTecycleBin;


            if (CompositeSettings.localSettings.Values["CurrentAccentColor"] != null)
            {
                _colors = (AccentColors)Enum.Parse(typeof(AccentColors),
                    CompositeSettings.localSettings.Values["CurrentAccentColor"].ToString());
            }
            else
            {
                Colors = AccentColors.Blue;
            }

            Languages = new ObservableCollection<Language>
            {
                new Language { DisplayName = "English", LanguageCode = "en-US" },
                new Language { DisplayName = "Russian", LanguageCode = "ru-RU" }
            };
        }

    }
}
