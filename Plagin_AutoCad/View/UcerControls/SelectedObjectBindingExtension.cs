using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Data;
using Model.Objects;

namespace Plagin_AutoCad.View.UcerControls
{
    class SelectedObjectBindingExtension: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return new object[] { value };
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
