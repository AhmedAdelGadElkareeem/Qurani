using WytSky.Mobile.Maui.Skoola.Helpers;
using System.Windows.Input;

namespace WytSky.Mobile.Maui.Skoola.CustomControl;

public partial class ViewAll : BaseContentView
{
    public ViewAll()
    {
        InitializeComponent();
    }

    #region OnViewAllClicked
    public static readonly BindableProperty OnViewAllClickedProperty =
    BindableProperty.Create(nameof(OnViewAllClicked),
        typeof(ICommand), typeof(ViewAll), defaultValue: null, BindingMode.TwoWay);
    public ICommand OnViewAllClicked
    {
        get => (ICommand)GetValue(OnViewAllClickedProperty);
        set => SetValue(OnViewAllClickedProperty, value);
    }
    #endregion
}