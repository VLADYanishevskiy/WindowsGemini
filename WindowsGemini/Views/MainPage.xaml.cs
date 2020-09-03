using Microsoft.Toolkit.Uwp.UI.Helpers;
using System.ServiceModel.Channels;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Navigation;
using WindowsGemini.Views;
using WindowsGemini.Views.CustomControls;
using Binding = Windows.UI.Xaml.Data.Binding;

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

            Listener.ThemeChanged += Listener_ThemeChanged;
        }
        private void Listener_ThemeChanged(ThemeListener sender)
        {
            var theme = sender.CurrentTheme;
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
            Windows.UI.Core.SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility =
            Windows.UI.Core.AppViewBackButtonVisibility.Disabled;
        }
        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
            
        }
        private void OpenSettings_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(SettingPage));
        }
        private void BtnOpenResultsScan(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ResultsScanPage));
        }


        
    }
}
