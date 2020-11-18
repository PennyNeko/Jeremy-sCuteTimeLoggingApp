using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace Jeremy_sCuteTimeLoggingApp
{
    class TitleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((DateTime)value).ToString("ddd d, MMMM") + Environment.NewLine + "I love Jeremy!";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //To-Do: Logging
            throw new NotImplementedException();
        }
    }
}
