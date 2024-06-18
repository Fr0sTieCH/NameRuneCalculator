using System;
using System.Globalization;
using System.Windows.Data;

namespace NameRuneCalculator.Helpers;
public class LanguageNameConverter : IValueConverter
{
  public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
  {
    if (value is string langCode)
    {
      try
      {
        CultureInfo cultureInfo = new CultureInfo(langCode);
        return cultureInfo.NativeName; // Display the native name of the language
      }
      catch (CultureNotFoundException)
      {
        return langCode; // Fallback to the language code if not found
      }
    }
    return value;
  }

  public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
  {
    throw new NotImplementedException();
  }
}