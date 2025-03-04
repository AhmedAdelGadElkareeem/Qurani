
namespace WytSky.Mobile.Maui.Skoola.CustomControl;

public class CustomButton : Button
{
    public static readonly BindableProperty IsValidProperty = BindableProperty.Create(nameof(IsValid),
        typeof(bool), typeof(CustomButton), false, defaultBindingMode: BindingMode.TwoWay);
    public bool IsValid
    {
        get { return (bool)GetValue(IsValidProperty); }
        set { SetValue(IsValidProperty, value); }
    }
}
