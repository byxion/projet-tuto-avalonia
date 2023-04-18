using Avalonia.Data.Converters;
using Serilog;
using TestBinding.Models;

namespace TestBinding.Views;

public class CloseVisibilityConverter : IValueConverter
{
    public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        if (value is Item item)
        {
            return true;
        }
        else
        {
            return true;
        }
    }

    public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        throw new System.NotImplementedException();
    }
}