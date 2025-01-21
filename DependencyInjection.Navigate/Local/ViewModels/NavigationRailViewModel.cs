using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using DependencyInjection.Database.Themes.Views;
using DependencyInjection.DataCheck.Themes.Views;
using DependencyInjection.History.Themes.Views;
using DependencyInjection.Home.Themes.Views;
using DependencyInjection.Navigate.Local.Models;
using MaterialDesignThemes.Wpf;
using System.Collections.ObjectModel;
using WPF.Core;

namespace DependencyInjection.Navigate.Local.ViewModels;

public partial class NavigationRailViewModel : ViewModelBase
{
    [ObservableProperty]
    private ObservableCollection<NavigationItem> _itemList;

    [ObservableProperty]
    private object? _selectedItem;

    /// <summary>
    /// NavigationRailViewModel의 생성자입니다.
    /// </summary>
    public NavigationRailViewModel()
    {
        ItemList =
        [
            new()
            {
                Title = "Home",
                SelectedIcon = PackIconKind.Home,
                UnselectedIcon = PackIconKind.HomeOutline,
                ViewType = ViewType.Home
            },
            new()
            {
                Title = "Data Check",
                SelectedIcon = PackIconKind.CheckboxMarkedCircle,
                UnselectedIcon = PackIconKind.CheckboxMarkedCircleOutline,
                ViewType = ViewType.DataCheck
            },
            new()
            {
                Title = "Database",
                SelectedIcon = PackIconKind.DatabaseSync,
                UnselectedIcon = PackIconKind.DatabaseSyncOutline,
                ViewType = ViewType.Database
            },
            new()
            {
                Title = "History",
                SelectedIcon = PackIconKind.ClipboardTextClock,
                UnselectedIcon = PackIconKind.ClipboardTextClockOutline,
                ViewType = ViewType.History
            }
        ];

        // 초기 선택 항목 설정
        SelectedItem = ItemList[0];
    }

    /// <summary>
    /// 선택된 항목이 변경될 때 호출되는 메서드입니다.
    /// </summary>
    /// <param name="value">새로 선택된 항목</param>
    partial void OnSelectedItemChanged(object? value)
    {
        if (value is NavigationItem item)
        {
            switch (item.ViewType)
            {
                case ViewType.Home:
                    SelectedItem = Ioc.Default.GetRequiredService<HomeView>();
                    break;
                case ViewType.DataCheck:
                    SelectedItem = Ioc.Default.GetRequiredService<DataCheckView>();
                    break;
                case ViewType.Database:
                    SelectedItem = Ioc.Default.GetRequiredService<DatabaseView>();
                    break;
                case ViewType.History:
                    SelectedItem = Ioc.Default.GetRequiredService<HistoryView>();
                    break;
            }
        }
    }
}
