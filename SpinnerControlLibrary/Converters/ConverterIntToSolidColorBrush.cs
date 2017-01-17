using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace SpinnerControlLibrary.Converters
{
    public class ConverterIntToSolidColorBrush : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var alpha = (float) (double) (values[0]);
            var red = (float) (double) (values[1]);
            var green = (float) (double) (values[2]);
            var blue = (float) (double) (values[3]);

            return Color.FromScRgb(alpha / 255, red / 255, green / 255, blue / 255);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}