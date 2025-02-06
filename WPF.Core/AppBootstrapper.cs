using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Controls;

namespace WPF.Core;

/// <summary>
/// WPF 애플리케이션의 부트스트래핑을 담당하는 추상 클래스입니다.
/// </summary>
public abstract class AppBootstrapper
{
    /// <summary>
    /// 뷰모델을 서비스 컬렉션에 등록합니다.
    /// </summary>
    /// <param name="services">서비스 컬렉션</param>
    protected abstract void RegisterViewModels(IServiceCollection services);

    /// <summary>
    /// 뷰를 서비스 컬렉션에 등록합니다.
    /// </summary>
    /// <param name="services">서비스 컬렉션</param>
    protected abstract void RegisterViews(IServiceCollection services);

    /// <summary>
    /// 애플리케이션 시작 시 호출되는 메서드입니다.
    /// </summary>
    protected abstract void OnStartup();

    /// <summary>
    /// 뷰와 뷰모델의 종속성을 설정하고 서비스 컬렉션에 일시적으로 추가합니다.
    /// </summary>
    /// <typeparam name="TView">추가할 뷰의 타입</typeparam>
    /// <typeparam name="TViewModel">추가할 뷰모델의 타입</typeparam>
    /// <param name="services">서비스 컬렉션</param>
    protected static void AddTransientView<TView, TViewModel>(IServiceCollection services)
        where TView : UserControl, new()
        where TViewModel : class
    {
        services.AddTransient(provider =>
        {
            return new TView
            {
                DataContext = provider.GetRequiredService<TViewModel>()
            };
        });
    }

    /// <summary>
    /// 애플리케이션을 실행합니다.
    /// </summary>
    public void Run()
    {
        var services = new ServiceCollection();
        RegisterViewModels(services);
        RegisterViews(services);

        Ioc.Default.ConfigureServices(services.BuildServiceProvider());

        OnStartup();
    }
}
