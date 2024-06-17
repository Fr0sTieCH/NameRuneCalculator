using GalaSoft.MvvmLight.Command;
using NameRuneCalculator.Configuration;
using NameRuneCalculator.Model;
using System;
using System.Linq;
using System.Windows.Input;

namespace NameRuneCalculator.ViewModel
{
  public class ConfigurationViewModel : NRCViewModelBase
  {

    private RuneValue[] _runes = Array.Empty<RuneValue>();

    public ICommand ResetToDefault => new RelayCommand(() => Runes = Config.DefaultRunes);
    public ICommand UndoChanges => new RelayCommand(() => Runes = Config.UserDefinedRunes);
    public ICommand Save => new RelayCommand(() => Config.UserDefinedRunes = Runes);

    public ConfigurationViewModel(NameRuneCalculatorConfig config) : base(config)
    {
      Runes = config.UserDefinedRunes;
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
  }
}
