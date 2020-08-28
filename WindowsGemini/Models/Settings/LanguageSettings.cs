using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Globalization;

namespace WindowsGemini.Models.Settings
{
    class LanguageSettings
    {
        public static ObservableCollection<Language> availableLanguages;
        public static Language currentLanguage;
    }
}
