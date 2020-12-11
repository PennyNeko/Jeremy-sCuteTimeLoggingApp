using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Jeremy_sCuteTimeLoggingApp.Converters
{
    [ValueConversion(typeof(TimeSpan), typeof(String))]
    class TotalTimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return $"Total time logged: {(TimeSpan)value:hh'h 'mm'm'} >^.^<";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
