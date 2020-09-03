using System.Reflection;

namespace WindowsGemini.ViewModels.SettingsPageViewModel
{
    partial class SettingsViewModel
    {
        public static string AppVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }
        public static string AppName
        {
            get
            {
                return "Windows Gemini";
            }
        }
    }
}
