using System.Globalization;
using System.Text;

namespace NameRuneCalculator.Helpers;

public static class StringExtensions
{
  public static string NormalizeString(this string input)
  {
    if (string.IsNullOrEmpty(input))
      return input;

    var normalizedString = input.Normalize(NormalizationForm.FormD);
    var stringBuilder = new StringBuilder();

    foreach (var c in normalizedString)
    {
      var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
      if (unicodeCategory != UnicodeCategory.NonSpacingMark &&
          char.IsLetter(c)) // Ensure only alphabetic characters are included
      {
        stringBuilder.Append(c);
      }
    }

    return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
  }
}

