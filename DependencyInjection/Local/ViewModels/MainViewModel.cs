using DependencyInjection.Navigate.Themes.Views;
using WPF.Core;

namespace DependencyInjection.Main.Local.ViewModels;

public class MainViewModel(NavigationRailView navigationRail) : ViewModelBase
{
    /// <summary>
    /// NavigationRailView를 가져옵니다.
    /// </summary>
    public NavigationRailView NavigationRail { get; } = navigationRail;
}
