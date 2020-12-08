using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace Jeremy_sCuteTimeLoggingApp.Converters
{
    [ValueConversion(typeof(TimeSpan), typeof(String))]
    class DurationConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((TimeSpan)value).ToString("hh'h 'mm'm'");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string strValue = value as string;
            if (int.TryParse(strValue.Substring(0, 2), out int hours) && int.TryParse(strValue.Substring(4, 2), out int minutes))
            {
                return new TimeSpan(hours, minutes, 0);
            }
            return DependencyProperty.UnsetValue;
        }
    }
}
