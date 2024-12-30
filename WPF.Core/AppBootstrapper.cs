using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace WPF.Core;

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
