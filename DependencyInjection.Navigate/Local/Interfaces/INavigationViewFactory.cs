using DependencyInjection.Navigate.Local.Enums;
using WPF.Core.Interfaces;

namespace DependencyInjection.Navigate.Local.Interfaces;

/// <summary>
/// 네비게이션 뷰 생성을 담당하는 팩토리 인터페이스입니다.
/// </summary>
public interface INavigationViewFactory : IViewFactory<NavigationViewType>
{
}
