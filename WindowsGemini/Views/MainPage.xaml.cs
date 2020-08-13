using Microsoft.Toolkit.Collections;
using Microsoft.Toolkit.Uwp.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Core;
using Windows.ApplicationModel.DataTransfer;
using Windows.Foundation;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Popups;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Navigation;
using WindowsGemini.Models;
using WindowsGemini.ViewModels;
using WindowsGemini.Views;
using WindowsGemini.Views.CustomControls;

namespace WindowsGemini
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            ApplicationView.PreferredLaunchViewSize = new Size(500, 500);
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;

            CoreApplication.GetCurrentView().TitleBar.ExtendViewIntoTitleBar = true;
            
            Binding myBinding = new Binding();
            myBinding.Source = this.DataContext;
            myBinding.Path = new PropertyPath("StateOfScanning");
            myBinding.Mode = BindingMode.TwoWay;
            myBinding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            BindingOperations.SetBinding(mltView, MultiViewControl.selectedItemShowProperty, myBinding);
            mltView.SelectedItemShow = 0;
            mltView.selectedItemChanged();
            
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
    }
}
