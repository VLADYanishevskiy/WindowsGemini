using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace WindowsGemini.Models.Settings
{
    public static class CompositeSettings
    {
        public readonly static ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
        
    }
}
