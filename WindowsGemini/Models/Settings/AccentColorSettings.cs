using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Media;

namespace WindowsGemini.Models.Settings
{
    internal static class AccentColorSettings
    {
        private static List<Color> _accentColors = new List<Color>() {
            GetSolidColorBrush("#f7630c").Color , GetSolidColorBrush("#ff4343").Color ,
            GetSolidColorBrush("#ea005e").Color , GetSolidColorBrush("#b146c2").Color,
            GetSolidColorBrush("#107c10").Color , GetSolidColorBrush("#0078d7").Color};
        public static List<Color> AccentColors
        {
            get { return _accentColors; }
            private set { _accentColors = value; }
        }
        public static Color SelectedColor;
        private static SolidColorBrush GetSolidColorBrush(string hex)
        {
            hex = hex.Replace("#", string.Empty);
            byte a = (byte)(Convert.ToUInt32(hex.Substring(0, 2), 16));
            byte r = (byte)(Convert.ToUInt32(hex.Substring(2, 2), 16));
            byte g = (byte)(Convert.ToUInt32(hex.Substring(4, 2), 16));
            byte b = (byte)(Convert.ToUInt32(hex.Substring(6, 2), 16));
            SolidColorBrush myBrush = new SolidColorBrush(Windows.UI.Color.FromArgb(a, r, g, b));
            return myBrush;
        }

    }
}
