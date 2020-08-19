using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WindowsGemini.ViewModels.SettingsPageViewModel
{
    partial class SettingsViewModel
    {
        public string AppVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }
        public string AppName
        {
            get
            {
                return "Windows Gemini";
            }
        }
    }
}
