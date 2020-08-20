using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;
using WindowsGemini.Models.Settings;
using WindowsGemini.ViewModels.SettingsPageViewModel;

namespace WindowsGemini.Models.ValueConverters
{
    public class ColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string culture)
        {
            string parameterString = parameter as string;
            if (parameterString == null)
                return DependencyProperty.UnsetValue;

            if (Enum.IsDefined(value.GetType(), value) == false)
                return DependencyProperty.UnsetValue;

            object parameterValue = Enum.Parse(value.GetType(), parameterString);

            return parameterValue.Equals(value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string culture)
        {
            if ((bool)value == true)
            {
                string parameterString = parameter as string;
                if (parameterString == null)
                    return DependencyProperty.UnsetValue;

                return Enum.Parse(typeof(AccentColors), parameterString);
            }
            else
            {
                return Enum.Parse(typeof(AccentColors), CompositeSettings.localSettings.Values["CurrentAccentColor"].ToString());
            }
        }

    }
}
