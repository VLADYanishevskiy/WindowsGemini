using WindowsGemini.Models.Settings;

namespace WindowsGemini.ViewModels.SettingsPageViewModel
{
    partial class SettingsViewModel
    {
        private DeletionMode _deletionMode = DeletionMode.SendToTecycleBin;
        public DeletionMode DeleTionMode {
            get
            {
                return _deletionMode;
            }
            set
            {
                this._deletionMode = value;
                CompositeSettings.localSettings.Values["DeleTionMode"] = _deletionMode.ToString();
            }
        }
    }
    enum DeletionMode
    {
        SendToTecycleBin,
        PermanentDeletion
    }
}
