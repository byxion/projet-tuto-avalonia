using System;
using System.Globalization;
using Avalonia.Controls;
using Avalonia.Data.Converters;

namespace TestBinding.Views;

public class FilterIsVisibleConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is DataGrid dataGrid)
        {
            return true;
        }
        return true;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
