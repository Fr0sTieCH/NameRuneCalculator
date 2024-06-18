using System;
using System.Globalization;
using System.Resources;
using System.Windows.Markup;

namespace NameRuneCalculator.Helpers
{
  public class LocExtension : MarkupExtension
  {
    private readonly ResourceManager _resourceManager;

    public string Key { get; set; } = string.Empty;

    public LocExtension()
    {
      _resourceManager = new ResourceManager("NameRuneCalculator.Resources.Language", typeof(LocExtension).Assembly);
    }

    public LocExtension(string key) : this()
    {
      Key = key;
    }

    public override object ProvideValue(IServiceProvider serviceProvider)
    {
      return _resourceManager.GetString(Key, CultureInfo.DefaultThreadCurrentUICulture) ?? $"[{Key}]";
    }
  }
}
