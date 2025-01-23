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
    /// <summary>
    /// 뷰모델을 서비스 컬렉션에 등록합니다.
    /// </summary>
    /// <param name="services"></param>
    protected override void RegisterViewModels(IServiceCollection services)
    {
        services.AddSingleton<HistoryViewModel>();
        services.AddSingleton<DatabaseViewModel>();
        services.AddSingleton<DataCheckViewModel>();
        services.AddSingleton<HomeViewModel>();
        services.AddSingleton<NavigationRailViewModel>();
        services.AddSingleton<MainViewModel>();
    }

    /// <summary>
    /// 뷰를 서비스 컬렉션에 등록합니다.
    /// </summary>
    /// <param name="services"></param>
    protected override void RegisterViews(IServiceCollection services)
    {
        AddTransientView<HistoryView, HistoryViewModel>(services);
        AddTransientView<DatabaseView, DatabaseViewModel>(services);
        AddTransientView<DataCheckView, DataCheckViewModel>(services);
        AddTransientView<HomeView, HomeViewModel>(services);
        AddTransientView<NavigationRailView, NavigationRailViewModel>(services);
        AddTransientView<MainView, MainViewModel>(services);
    }

    protected override void OnStartup()
    {
    }
}
