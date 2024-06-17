using Microsoft.Extensions.DependencyInjection;
using NameRuneCalculator.ViewModel;
using System.Windows;

namespace NameRuneCalculator
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();
      DataContext = App.ServiceProvider?.GetRequiredService<MainViewModel>();
    }
  }
}
