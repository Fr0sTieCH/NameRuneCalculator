using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NameRuneCalculator.Configuration;
using NameRuneCalculator.Helpers;
using NameRuneCalculator.View;
using NameRuneCalculator.ViewModel;
using System;
using System.IO;
using System.Windows;

namespace NameRuneCalculator
{
  public partial class App : Application
  {
    public static IServiceProvider? ServiceProvider { get; private set; }

    protected override void OnStartup(StartupEventArgs e)
    {
      base.OnStartup(e);

      var serviceCollection = new ServiceCollection();
      ConfigureServices(serviceCollection);

      ServiceProvider = serviceCollection.BuildServiceProvider();

      var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
      mainWindow.Show();
    }

    private void ConfigureServices(IServiceCollection services)
    {
      var builder = new ConfigurationBuilder()
          .SetBasePath(Directory.GetCurrentDirectory())
          .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

      IConfiguration configuration = builder.Build();
      services.AddSingleton(configuration);
      var defaultConfig = new NameRuneCalculatorConfig();
      configuration.GetSection("NameRuneCalculatorConfig").Bind(defaultConfig);

      var nameRuneConfig = UserSettingsHelper.LoadUserSettings(defaultConfig);

      LocalizationHelper.SwitchLanguage(nameRuneConfig.Language);
      services.AddSingleton(nameRuneConfig);

      // Register ViewModels
      services.AddTransient<MainViewModel>();
      services.AddTransient<ConfigurationViewModel>();
      services.AddTransient<CalculationViewModel>();

      // Register Views
      services.AddTransient<MainWindow>();
      services.AddTransient<ConfigurationView>();
      services.AddTransient<CalculationView>();
    }
  }
}
