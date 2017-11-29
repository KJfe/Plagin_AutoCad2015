using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Plagin_AutoCad.View.UcerControls
{
    public class ShowDataGridToVisibilityConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (System.Convert.ToBoolean(value))
            {
                return Visibility.Visible; 
            }
            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
