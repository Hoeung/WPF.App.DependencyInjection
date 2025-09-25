using DependencyInjection.Database.Themes.Views;
using DependencyInjection.DataCheck.Themes.Views;
using DependencyInjection.History.Themes.Views;
using DependencyInjection.Home.Themes.Views;
using DependencyInjection.Navigate.Local.Enums;
using DependencyInjection.Navigate.Local.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace DependencyInjection.Navigate.Local.Services;

/// <summary>
/// 네비게이션 뷰 팩토리 구현체입니다.
/// </summary>
public class NavigationViewFactory(IServiceProvider serviceProvider) : INavigationViewFactory
{
    private readonly IServiceProvider _serviceProvider = serviceProvider;

    public FrameworkElement CreateView(NavigationViewType viewType)
    {
        try
        {
            return viewType switch
            {
                NavigationViewType.Home => _serviceProvider.GetRequiredService<HomeView>(),
                NavigationViewType.DataCheck => _serviceProvider.GetRequiredService<DataCheckView>(),
                NavigationViewType.Database => _serviceProvider.GetRequiredService<DatabaseView>(),
                NavigationViewType.History => _serviceProvider.GetRequiredService<HistoryView>(),
                _ => throw new NotSupportedException($"지원되지 않는 뷰 타입입니다: {viewType}")
            };
        }
        catch (InvalidOperationException ex)
        {
            throw new InvalidOperationException($"뷰 타입 '{viewType}'에 대한 서비스를 찾을 수 없습니다.", ex);
        }
    }
}
