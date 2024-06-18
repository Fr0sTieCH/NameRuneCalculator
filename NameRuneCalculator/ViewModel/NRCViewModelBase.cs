using NameRuneCalculator.Configuration;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NameRuneCalculator.ViewModel
{
  public abstract class NRCViewModelBase : INotifyPropertyChanged
  {
    public event PropertyChangedEventHandler? PropertyChanged;
    protected NameRuneCalculatorConfig Config { get; private set; }

    public NRCViewModelBase(NameRuneCalculatorConfig config)
    {
      Config = config;
    }

    protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
  }
}
