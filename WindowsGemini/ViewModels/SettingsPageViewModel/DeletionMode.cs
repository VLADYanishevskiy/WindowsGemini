using WindowsGemini.Models.Settings;

namespace WindowsGemini.ViewModels.SettingsPageViewModel
{
    partial class SettingsViewModel
    {
        DeletionMode mode = DeletionMode.SendToTecycleBin;
    }
    enum DeletionMode
    {
        SendToTecycleBin,
        PermanentDeletion
    }
}
