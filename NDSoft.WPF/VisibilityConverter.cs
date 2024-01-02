using System.Globalization;
using System.Windows.Data;

namespace NDSoft.WPF;
/// <summary>
/// Converter to assign Visible when the value passed is true, otherwise Hidden
/// </summary>
/// <seealso cref="System.Windows.Data.IValueConverter" />
public class VisibilityConverter : IValueConverter
{
   /// <summary>
   /// Converts a value from boolean to <see cref="System.Windows.Visibility"/>.
   /// </summary>
   /// <param name="value">The value produced by the binding source.</param>
   /// <param name="targetType">The type of the binding target property.</param>
   /// <param name="parameter">The converter parameter to use.</param>
   /// <param name="culture">The culture to use in the converter.</param>
   /// <returns>
   /// A converted value. If the method returns <see langword="null" />, the valid null value is used.
   /// </returns>
   public object Convert(object value, Type targetType, object parameter, CultureInfo culture)

   {
      if(value is bool)
         return (bool)value ? System.Windows.Visibility.Visible : System.Windows.Visibility.Hidden;
      return System.Windows.Visibility.Hidden;
   }
   /// <summary>
   /// Converts a value from <see cref="System.Windows.Visibility"/> to boolean.
   /// </summary>
   /// <param name="value">The value that is produced by the binding target.</param>
   /// <param name="targetType">The type to convert to.</param>
   /// <param name="parameter">The converter parameter to use.</param>
   /// <param name="culture">The culture to use in the converter.</param>
   /// <returns>
   /// A converted value. If the method returns <see langword="null" />, the valid null value is used.
   /// </returns>
   public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
   {
      if(value is System.Windows.Visibility)
         return (System.Windows.Visibility)value == System.Windows.Visibility.Visible;
      return false;
   }
}