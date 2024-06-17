using Microsoft.Extensions.DependencyInjection;
using NameRuneCalculator.ViewModel;
using System.Windows.Controls;

namespace NameRuneCalculator.View
{
  /// <summary>
  /// Interaction logic for CalculationView.xaml
  /// </summary>
  public partial class CalculationView : UserControl
  {
    public CalculationView()
    {
      InitializeComponent();
      DataContext = App.ServiceProvider?.GetRequiredService<CalculationViewModel>();
    }
  }
}
