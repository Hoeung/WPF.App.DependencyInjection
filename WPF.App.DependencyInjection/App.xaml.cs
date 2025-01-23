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

    /// <summary>
    /// 애플리케이션 시작 시 호출되는 메서드입니다.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
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
