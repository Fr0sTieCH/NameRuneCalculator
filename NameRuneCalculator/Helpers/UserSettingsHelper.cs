using NameRuneCalculator.Configuration;
using System;
using System.IO;
using System.Text.Json;

namespace NameRuneCalculator.Helpers
{

  public static class UserSettingsHelper
  {
    private static readonly string _appDataFolder = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
        "NameRuneCalculator");

    public static string UserSettingsFile => Path.Combine(_appDataFolder, "userSettings.json");

    static UserSettingsHelper()
    {
      if (!Directory.Exists(_appDataFolder))
      {
        Directory.CreateDirectory(_appDataFolder);
      }
    }

    public static NameRuneCalculatorConfig LoadUserSettings(NameRuneCalculatorConfig defaultConfig)
    {
      if (File.Exists(UserSettingsFile))
      {
        var json = File.ReadAllText(UserSettingsFile);
        return JsonSerializer.Deserialize<NameRuneCalculatorConfig>(json) ?? new NameRuneCalculatorConfig();
      }


      return new NameRuneCalculatorConfig()
      {
        DefaultRunes = defaultConfig.DefaultRunes,
        UserDefinedRunes = defaultConfig.DefaultRunes,
        Language = defaultConfig.Language,
        NormalizeCharacters = defaultConfig.NormalizeCharacters
      };

    }

    public static void SaveUserSettings(NameRuneCalculatorConfig config)
    {
      var json = JsonSerializer.Serialize(config, new JsonSerializerOptions { WriteIndented = true });
      File.WriteAllText(UserSettingsFile, json);
    }
  }

}
