using CommunityToolkit.Mvvm.ComponentModel;
using DependencyInjection.Navigate.Local.Enums;
using DependencyInjection.Navigate.Local.Interfaces;
using DependencyInjection.Navigate.Local.Models;
using MaterialDesignThemes.Wpf;
using System.Collections.ObjectModel;
using System.Windows;
using WPF.Core;

namespace DependencyInjection.Navigate.Local.ViewModels;

public partial class NavigationRailViewModel : ViewModelBase
{
    private readonly INavigationViewFactory? _viewFactory;

    /// <summary>
    /// 네비게이션 항목의 리스트입니다.
    /// </summary>
    [ObservableProperty]
    private ObservableCollection<NavigationItem> _itemList;

    /// <summary>
    /// 선택된 네비게이션 항목입니다.
    /// </summary>
    [ObservableProperty]
    private NavigationItem? _selectedItem;

    /// <summary>
    /// 현재 활성화된 뷰입니다.
    /// </summary>
    [ObservableProperty]
    private FrameworkElement? _currentView;

    /// <summary>
    /// NavigationRailViewModel의 생성자입니다.
    /// </summary>
    public NavigationRailViewModel(INavigationViewFactory? viewFactory = null)
    {
        _viewFactory = viewFactory;

        ItemList =
        [
            new NavigationItem
            {
                Title = "Home",
                SelectedIcon = PackIconKind.Home,
                UnselectedIcon = PackIconKind.HomeOutline,
                ViewType = NavigationViewType.Home
            },
            new NavigationItem
            {
                Title = "Data Check",
                SelectedIcon = PackIconKind.CheckboxMarkedCircle,
                UnselectedIcon = PackIconKind.CheckboxMarkedCircleOutline,
                ViewType = NavigationViewType.DataCheck
            },
            new NavigationItem
            {
                Title = "Database",
                SelectedIcon = PackIconKind.DatabaseSync,
                UnselectedIcon = PackIconKind.DatabaseSyncOutline,
                ViewType = NavigationViewType.Database
            },
            new NavigationItem
            {
                Title = "History",
                SelectedIcon = PackIconKind.ClipboardTextClock,
                UnselectedIcon = PackIconKind.ClipboardTextClockOutline,
                ViewType = NavigationViewType.History
            }
        ];

        // 초기 선택 항목 설정
        SelectedItem = ItemList[0];
        SetCurrentView(SelectedItem);
    }

    /// <summary>
    /// 선택된 항목이 변경될 때 호출되는 메서드입니다.
    /// </summary>
    /// <param name="value">새로 선택된 항목</param>
    partial void OnSelectedItemChanged(NavigationItem? value)
    {
        if (value != null)
        {
            SetCurrentView(value);
        }
    }

    /// <summary>
    /// 현재 뷰를 설정합니다.
    /// </summary>
    /// <param name="item">네비게이션 항목</param>
    private void SetCurrentView(NavigationItem item)
    {
        CurrentView = _viewFactory?.CreateView(item.ViewType);
    }
}
