using MaterialDesignThemes.Wpf;

namespace DependencyInjection.Navigate.Local.Models;

/// <summary>
/// 네비게이션 항목을 나타내는 클래스입니다.
/// </summary>
public class NavigationItem
{
    public string? Title { get; set; }
    public PackIconKind SelectedIcon { get; set; }
    public PackIconKind UnselectedIcon { get; set; }
    public ViewType ViewType { get; set; }
}
