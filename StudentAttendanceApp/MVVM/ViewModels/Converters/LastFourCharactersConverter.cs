using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Microsoft.Maui.Controls;
using System.Threading.Tasks;

namespace StudentAttendanceApp.MVVM.ViewModels.Converters
{

    public class LastFourCharactersConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string str)
            {
                return str.Length > 4 ? str.Substring(str.Length - 4) : str;
            }
            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}

