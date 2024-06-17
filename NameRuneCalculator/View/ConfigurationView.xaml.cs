using Microsoft.Extensions.DependencyInjection;
using NameRuneCalculator.ViewModel;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Input;

namespace NameRuneCalculator.View
{
  /// <summary>
  /// Interaction logic for ConfigurationView.xaml
  /// </summary>
  public partial class ConfigurationView : UserControl
  {
    public ConfigurationView()
    {
      InitializeComponent();
      DataContext = App.ServiceProvider?.GetRequiredService<ConfigurationViewModel>();
    }
    public void AllowOnlyNumericInput(object sender, TextCompositionEventArgs e)
    {
      e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
    }
  }
}
