using System;
using System.Globalization;
using Avalonia.Controls;
using Avalonia.Data.Converters;

namespace TestBinding.Views;

public class FilterIsVisibleConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return !((bool) value);
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
