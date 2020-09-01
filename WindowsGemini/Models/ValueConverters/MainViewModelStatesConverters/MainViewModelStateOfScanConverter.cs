using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace WindowsGemini.Models.ValueConverters.MainViewModelStatesConverters
{
    class MainViewModelStateOfScanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            int? iValue = value as int?;
            int iPam = int.Parse(parameter.ToString());

            if(iValue.HasValue)
            {
                return iValue.Value == iPam;
            }

            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
