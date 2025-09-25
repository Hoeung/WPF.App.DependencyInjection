using System.Windows;

namespace WPF.Core.Interfaces;

/// <summary>
/// 뷰 생성을 담당하는 팩토리 인터페이스입니다.
/// </summary>
/// <typeparam name="TViewType">뷰 타입을 나타내는 열거형</typeparam>
public interface IViewFactory<in TViewType> where TViewType : Enum
{
    /// <summary>
    /// 지정된 뷰 타입에 해당하는 뷰를 생성합니다.
    /// </summary>
    /// <param name="viewType">생성할 뷰의 타입</param>
    /// <returns>생성된 뷰 인스턴스</returns>
    FrameworkElement CreateView(TViewType viewType);
}
