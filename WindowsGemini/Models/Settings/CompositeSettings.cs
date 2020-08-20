using Windows.Storage;

namespace WindowsGemini.Models.Settings
{
    public static class CompositeSettings
    {
        public readonly static ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
    }
}
