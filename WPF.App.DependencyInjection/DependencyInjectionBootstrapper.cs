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
using DependencyInjection.Navigate.Local.Enums;
using DependencyInjection.Navigate.Local.Interfaces;
using DependencyInjection.Navigate.Local.Services;
using DependencyInjection.Navigate.Local.ViewModels;
using DependencyInjection.Navigate.Themes.Views;
using Microsoft.Extensions.DependencyInjection;
using WPF.Core;

namespace WPF.App.DependencyInjection;

/// <summary>
/// Dependency Injection을 사용하여 WPF 애플리케이션의 뷰와 뷰모델을 등록하는 부트스트래퍼 클래스입니다.
/// </summary>
public class DependencyInjectionBootstrapper : AppBootstrapper
{
    /// <summary>
    /// 뷰모델을 서비스 컬렉션에 등록합니다.
    /// </summary>
    /// <param name="services">서비스 컬렉션</param>
    protected override void RegisterViewModels(IServiceCollection services)
    {
        services.AddTransient<HistoryViewModel>();
        services.AddTransient<DatabaseViewModel>();
        services.AddTransient<DataCheckViewModel>();
        services.AddTransient<HomeViewModel>();

        services.AddSingleton<NavigationRailViewModel>();
        services.AddSingleton<MainViewModel>();
    }

    /// <summary>
    /// 뷰를 서비스 컬렉션에 등록합니다.
    /// </summary>
    /// <param name="services">서비스 컬렉션</param>
    protected override void RegisterViews(IServiceCollection services)
    {
        AddViewFactory<NavigationViewType, INavigationViewFactory>(services, provider => new NavigationViewFactory(provider));

        AddTransientView<HistoryView, HistoryViewModel>(services);
        AddTransientView<DatabaseView, DatabaseViewModel>(services);
        AddTransientView<DataCheckView, DataCheckViewModel>(services);
        AddTransientView<HomeView, HomeViewModel>(services);
        AddTransientView<NavigationRailView, NavigationRailViewModel>(services);
        AddTransientView<MainView, MainViewModel>(services);
    }

    /// <summary>
    /// 애플리케이션 시작 시 호출되는 메서드입니다.
    /// </summary>
    protected override void OnStartup()
    {
    }
}