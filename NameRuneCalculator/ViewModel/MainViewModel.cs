using GalaSoft.MvvmLight.CommandWpf;
using NameRuneCalculator.Configuration;
using NameRuneCalculator.View;
using System.Windows.Controls;
using System.Windows.Input;

namespace NameRuneCalculator.ViewModel;

public class MainViewModel : NRCViewModelBase
{
  private UserControl? _currentView;

  private CalculationView _calculationView = new CalculationView();
  private ConfigurationView _configurationView = new ConfigurationView();
  private int _selectedMenuIndex = 0;

  public UserControl? CurrentView
  {
    get => _currentView;
    set
    {
      _currentView = value;
      OnPropertyChanged();
    }
  }

  public ICommand ShowCalculationViewCommand { get; }
  public ICommand ShowConfigurationViewCommand { get; }

  public MainViewModel(NameRuneCalculatorConfig config) : base(config)
  {
    ShowCalculationViewCommand = new RelayCommand(() => CurrentView = _calculationView);
    ShowConfigurationViewCommand = new RelayCommand(() => CurrentView = _configurationView);
    CurrentView = _calculationView;
  }

  public int SelectedMenuIndex
  {
    get => _selectedMenuIndex;
    set
    {
      if (_selectedMenuIndex != value)
      {
        _selectedMenuIndex = value;
        OnPropertyChanged();
        OnMenuSelectionChanged();
      }
    }
  }

  private void OnMenuSelectionChanged()
  {
    switch (_selectedMenuIndex)
    {
      case 0:
        ShowCalculationViewCommand.Execute(null);
        break;
      case 1:
        ShowConfigurationViewCommand.Execute(null);
        break;
    }
  }

}