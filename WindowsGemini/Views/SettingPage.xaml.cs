using Microsoft.Toolkit.Uwp.UI.Helpers;
using Windows.ApplicationModel.Core;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace WindowsGemini.Views
{
    public sealed partial class SettingPage : Page
    {
        ThemeListener Listener = new ThemeListener();

        public SettingPage()
        {
            this.InitializeComponent();
            CoreApplicationViewTitleBar coreTitleBar = CoreApplication.GetCurrentView().TitleBar;
            coreTitleBar.ExtendViewIntoTitleBar = true;
            Listener.ThemeChanged += Listener_ThemeChanged;
            CorrectTitleBarTheme(App.Current.RequestedTheme);
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
        private void App_BackRequested(object sender, BackRequestedEventArgs e)
        {
            if (this.Frame.CanGoBack)
            {
                this.Frame.GoBack();
            }
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Window.Current.SetTitleBar(TitleBarGrid);
            Windows.UI.Core.SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility =
            Windows.UI.Core.AppViewBackButtonVisibility.Visible;
            Windows.UI.Core.SystemNavigationManager.GetForCurrentView().BackRequested += App_BackRequested;
        }

    }
}
