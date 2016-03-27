using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace main.Dialogs
{
    public class RadioButtonCheckedConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value.Equals(parameter))
            {
                return true;
            }
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value.Equals(true))
            {
                return parameter;
            }
            return Binding.DoNothing;
        }
    }
}
