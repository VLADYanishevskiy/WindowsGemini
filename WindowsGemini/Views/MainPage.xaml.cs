using Microsoft.Toolkit.Uwp.UI.Helpers;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Navigation;
using WindowsGemini.Views;
using WindowsGemini.Views.CustomControls;

namespace WindowsGemini
{
    public sealed partial class MainPage : Page
    {
        private ThemeListener Listener = new ThemeListener();
        public MainPage()
        {
            this.InitializeComponent();

            ApplicationView.PreferredLaunchViewSize = new Size(500, 500);
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;
            CoreApplication.GetCurrentView().TitleBar.ExtendViewIntoTitleBar = true;
            ApplicationView.GetForCurrentView().SetPreferredMinSize(new Size(500, 500));

            Binding myBinding = new Binding();
            myBinding.Source = this.DataContext;
            myBinding.Path = new PropertyPath("StateOfScanning");
            myBinding.Mode = BindingMode.TwoWay;
            myBinding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            BindingOperations.SetBinding(mltView, MultiViewControl.selectedItemShowProperty, myBinding);
            mltView.SelectedItemShow = 0;
            mltView.selectedItemChanged();
            Listener.ThemeChanged += Listener_ThemeChanged;
        }
        private void Listener_ThemeChanged(ThemeListener sender)
        {
            var theme = sender.CurrentTheme;
            CorrectTitleBarTheme(theme);
        }
        private static void CorrectTitleBarTheme(ApplicationTheme theme)
        {
            var titleBar = ApplicationView.GetForCurrentView().TitleBar;
            switch (theme)
            {
                case ApplicationTheme.Dark:
                    titleBar.ForegroundColor = Colors.White;
                    break;
                default:
                case ApplicationTheme.Light:
                    titleBar.ForegroundColor = Colors.Black;
                    break;
            }
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            HideBackButtonOnCurrentpage();
        }
        private static void HideBackButtonOnCurrentpage()
        {
            Windows.UI.Core.SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility =
            Windows.UI.Core.AppViewBackButtonVisibility.Disabled;
        }
        private void OpenSettings_Click(object sender, RoutedEventArgs e)
        {
            mltView.Views.Clear();
            this.Frame.Navigate(typeof(SettingPage));
        }
        private void BtnOpenResultsScan(object sender, RoutedEventArgs e)
        {
            mltView.Views.Clear();
            this.Frame.Navigate(typeof(ResultsScanPage));
        }
    }
}
