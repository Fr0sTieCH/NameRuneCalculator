using GalaSoft.MvvmLight.Command;
using NameRuneCalculator.Configuration;
using NameRuneCalculator.Helpers;
using NameRuneCalculator.Model;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows.Input;

namespace NameRuneCalculator.ViewModel
{
  public class ConfigurationViewModel : NRCViewModelBase
  {
    private RuneValue[] _runes = Array.Empty<RuneValue>();
    private string _selectedLanguage = "en";
    private bool _autoNormalizeStrings = true;

    public ICommand ResetToDefault => new RelayCommand(() => Runes = Config.DefaultRunes);
    public ICommand UndoChanges => new RelayCommand(() => Runes = Config.UserDefinedRunes);
    public ICommand Save => new RelayCommand(() => SaveSettings());
    public ICommand ChangeLanguageCommand => new RelayCommand<string>(ChangeLanguage);

    public ConfigurationViewModel(NameRuneCalculatorConfig config) : base(config)
    {
      Runes = config.UserDefinedRunes;
      Languages = new ObservableCollection<string> { "en", "de" }; // Add more languages as needed
      SelectedLanguage = CultureInfo.DefaultThreadCurrentUICulture?.Name ?? "en";
      _autoNormalizeStrings = config.NormalizeCharacters;
    }

    public RuneValue[] Runes
    {
      get => _runes;
      set
      {
        if (_runes != value)
        {
          _runes = value.Select(rune => RuneValue.DeepCopy(rune)).ToArray();
          OnPropertyChanged();
        }
      }
    }

    public ObservableCollection<string> Languages { get; }
    public bool AutoNormalizeStrings
    {
      get => _autoNormalizeStrings;
      set
      {
        if (_autoNormalizeStrings != value)
        {
          _autoNormalizeStrings = value;
          OnPropertyChanged();
        }
      }
    }
    public string SelectedLanguage
    {
      get => _selectedLanguage;
      set
      {
        if (_selectedLanguage != value)
        {
          _selectedLanguage = value;
          ChangeLanguage(value);
          OnPropertyChanged();
        }
      }
    }

    private void ChangeLanguage(string cultureName)
    {
      LocalizationHelper.SwitchLanguage(cultureName);
      // Notify the UI to update based on the new culture
      var uilang = System.Windows.Application.Current.MainWindow?.Language;
      if (uilang is not null)
      {
        uilang = System.Windows.Markup.XmlLanguage.GetLanguage(cultureName);
      }
      RefreshUI();
    }

    private void RefreshUI()
    {
      OnPropertyChanged(nameof(Runes));
      OnPropertyChanged(nameof(SelectedLanguage));
    }

    private void SaveSettings()
    {
      Config.Language = SelectedLanguage;
      Config.NormalizeCharacters = _autoNormalizeStrings;
      Config.UserDefinedRunes = Runes;
      // reassign to ensure that we do not have references to the config objects
      Runes = Config.UserDefinedRunes;
      UserSettingsHelper.SaveUserSettings(Config);
    }
  }
}
