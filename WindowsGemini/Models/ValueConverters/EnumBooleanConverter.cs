﻿using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;
using WindowsGemini.Models.Settings;

namespace WindowsGemini.Models.ValueConverters
{
    public class EnumBooleanConverter : IValueConverter
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

                return Enum.Parse(typeof(ApplTheme), parameterString);
            }
            else
            {
                return Enum.Parse(typeof(ApplTheme), CompositeSettings.localSettings.Values["ApplicationTheme"].ToString());
            }
        }
    }
}
