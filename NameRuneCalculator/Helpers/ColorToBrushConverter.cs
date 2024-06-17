using System;

using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace NameRuneCalculator.Helpers;
public class ColorToBrushConverter : IValueConverter
{
  public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
  {
    if (value is System.Drawing.Color drawingColor)
    {
      // Convert System.Drawing.Color to System.Windows.Media.Color
      System.Windows.Media.Color mediaColor = System.Windows.Media.Color.FromArgb(drawingColor.A, drawingColor.R, drawingColor.G, drawingColor.B);
      return new SolidColorBrush(mediaColor);
    }

    return Brushes.Transparent;
  }

  public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
  {
    if (value is SolidColorBrush brush)
    {
      return System.Drawing.Color.FromArgb(brush.Color.A, brush.Color.R, brush.Color.G, brush.Color.B);

    }
    else if (value is System.Drawing.Color color)
    {
      return color;
    }
    else if (value is System.Windows.Media.Color mediaColor)
    {
      return System.Drawing.Color.FromArgb(mediaColor.A, mediaColor.R, mediaColor.G, mediaColor.B);
    }

    return System.Drawing.Color.White;
  }
}