﻿using System.Windows;

namespace WPF.App.DependencyInjection;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private void Application_Startup(object sender, StartupEventArgs e)
    {
        var mainWindow = new MainWindow()
        {
        };

        mainWindow.Show();
    }
}
