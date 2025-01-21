using CommunityToolkit.Mvvm.DependencyInjection;
using DependencyInjection.Main.Themes.Views;
using System.Windows;

namespace WPF.App.DependencyInjection;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private readonly DependencyInjectionBootstrapper _bootstrapper = new();

    private void Application_Startup(object sender, StartupEventArgs e)
    {
        _bootstrapper.Run();

        var mainWindow = new MainWindow()
        {
            Content = Ioc.Default.GetRequiredService<MainView>()
        };

        mainWindow.Show();
    }
}
