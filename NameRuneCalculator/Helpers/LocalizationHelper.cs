using System.Globalization;

namespace NameRuneCalculator.Helpers
{
  public static class LocalizationHelper
  {
    public static void SwitchLanguage(string cultureName)
    {
      var cultureInfo = new CultureInfo(cultureName);
      CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
      CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
    }
  }
}
