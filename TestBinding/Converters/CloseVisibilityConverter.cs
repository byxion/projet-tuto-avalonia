using Avalonia.Data.Converters;
using Serilog;
using TestBinding.Models;

namespace TestBinding.Converters;

public class CloseVisibilityConverter : IValueConverter
{
    public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        return (bool)value;
    }

    public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        throw new System.NotImplementedException();
    }
}