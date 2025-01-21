using DependencyInjection.Database.Local.ViewModels;
using DependencyInjection.Database.Themes.Views;
using DependencyInjection.DataCheck.Local.ViewModels;
using DependencyInjection.DataCheck.Themes.Views;
using DependencyInjection.History.Local.ViewModels;
using DependencyInjection.History.Themes.Views;
using DependencyInjection.Home.Local.ViewModels;
using DependencyInjection.Home.Themes.Views;
using DependencyInjection.Main.Local.ViewModels;
using DependencyInjection.Main.Themes.Views;
using DependencyInjection.Navigate.Local.ViewModels;
using DependencyInjection.Navigate.Themes.Views;
using Microsoft.Extensions.DependencyInjection;
using WPF.Core;

namespace WPF.App.DependencyInjection;

public class DependencyInjectionBootstrapper : AppBootstrapper
{
    protected override void RegisterViewModels(IServiceCollection services)
    {
        services.AddSingleton<HistoryViewModel>();
        services.AddSingleton<DatabaseViewModel>();
        services.AddSingleton<DataCheckViewModel>();
        services.AddSingleton<HomeViewModel>();
        services.AddSingleton<NavigationRailViewModel>();
        services.AddSingleton<MainViewModel>();
    }

    protected override void RegisterViews(IServiceCollection services)
    {
        services.AddTransient(provider =>
        {
            return new HistoryView
            {
                DataContext = provider.GetRequiredService<HistoryViewModel>()
            };
        });

        services.AddTransient(provider =>
        {
            return new DatabaseView
            {
                DataContext = provider.GetRequiredService<DatabaseViewModel>()
            };
        });

        services.AddTransient(provider =>
        {
            return new DataCheckView
            {
                DataContext = provider.GetRequiredService<DataCheckViewModel>()
            };
        });

        services.AddTransient(provider =>
        {
            return new HomeView
            {
                DataContext = provider.GetRequiredService<HomeViewModel>()
            };
        });

        services.AddTransient(provider =>
        {
            return new NavigationRailView
            {
                DataContext = provider.GetRequiredService<NavigationRailViewModel>()
            };
        });

        services.AddTransient(provider =>
        {
            return new MainView
            {
                DataContext = provider.GetRequiredService<MainViewModel>()
            };
        });
    }

    protected override void OnStartup()
    {
    }
}
