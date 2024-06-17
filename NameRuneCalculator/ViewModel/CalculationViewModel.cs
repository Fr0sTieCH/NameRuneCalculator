using GalaSoft.MvvmLight.Command;
using NameRuneCalculator.Configuration;
using NameRuneCalculator.Helpers;
using NameRuneCalculator.Model;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace NameRuneCalculator.ViewModel
{
  public class CalculationViewModel : NRCViewModelBase
  {
    private string _nameInput = string.Empty;
    private string _familyNameInput = string.Empty;
    private ObservableCollection<RuneValue> _fullNameRunes = new ObservableCollection<RuneValue>();
    private RuneDictionary _runeDictionary;

    public CalculationViewModel(NameRuneCalculatorConfig config) : base(config)
    {
      _runeDictionary = new RuneDictionary(config.UserDefinedRunes);

      CopyNameValueCommand = new RelayCommand(() => CopyToClipboard(NameValue.ToString()));
      CopyFamilyNameValueCommand = new RelayCommand(() => CopyToClipboard(FamilyNameValue.ToString()));
      CopyFullNameValueCommand = new RelayCommand(() => CopyToClipboard(FullNameValue.ToString()));
    }

    public ICommand CopyNameValueCommand { get; }
    public ICommand CopyFamilyNameValueCommand { get; }
    public ICommand CopyFullNameValueCommand { get; }

    public string NameInput
    {
      get => _nameInput;
      set
      {
        if (_nameInput != value)
        {
          if (Config.NormalizeCharacters)
          {
            value = value.NormalizeString();
          }
          _nameInput = value;
          UpdateFullName();
          OnPropertyChanged();
        }
      }
    }

    public string FamilyNameInput
    {
      get => _familyNameInput;
      set
      {
        if (_familyNameInput != value)
        {
          if (Config.NormalizeCharacters)
          {
            value = value.NormalizeString();
          }
          _familyNameInput = value;
          UpdateFullName();
          OnPropertyChanged();
        }
      }
    }

    public int NameValue { get => _runeDictionary.GetValueOfString(NameInput); set => _ = value; }
    public int FamilyNameValue { get => _runeDictionary.GetValueOfString(FamilyNameInput); set => _ = value; }
    public int FullNameValue { get => _runeDictionary.GetValueOfString($"{NameInput}{FamilyNameInput}".Trim()); set => _ = value; }


    public ObservableCollection<RuneValue> FullNameCharacters
    {
      get => _fullNameRunes;
      private set
      {
        _fullNameRunes = value;
        OnPropertyChanged();
      }
    }

    private void CopyToClipboard(string text)
    {
      Clipboard.SetText(text);
    }

    private void UpdateValues()
    {
      OnPropertyChanged("NameValue");
      OnPropertyChanged("FamilyNameValue");
      OnPropertyChanged("FullNameValue");
    }
    private void UpdateFullName()
    {
      FullNameCharacters.Clear();
      var fullName = $"{NameInput}{FamilyNameInput}".Trim();
      foreach (var c in fullName)
      {
        FullNameCharacters.Add(_runeDictionary.GetRuneValue(c) ?? new RuneValue());
      }
      UpdateValues();
    }
  }
}
