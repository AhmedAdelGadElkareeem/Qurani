using System.Windows.Input;

namespace WytSky.Mobile.Maui.Skoola.CustomControl;

public partial class NotificationSettingsCard : ContentView
{
	public NotificationSettingsCard()
	{
        try
        {
            InitializeComponent();
        }
        catch (Exception ex)
        {
            ExtensionLogMethods.LogExtension(ex,"", "NotificationSettingsCard", "Constructor");
        }
	}

    #region IsToggled
    public static readonly BindableProperty IsToggledProperty =
        BindableProperty.Create(nameof(IsToggled), typeof(bool), typeof(NotificationSettingsCard), false, BindingMode.TwoWay);
    public bool IsToggled
    {
        get => (bool)GetValue(IsToggledProperty);
        set => SetValue(IsToggledProperty, value);
    }
    #endregion

    #region OnSwitchClicked
    public static readonly BindableProperty OnSwitchClickedProperty =
    BindableProperty.Create(nameof(OnSwitchClicked),
        typeof(ICommand), typeof(NotificationSettingsCard), defaultValue: null, BindingMode.TwoWay);
    public ICommand OnSwitchClicked
    {
        get => (ICommand)GetValue(OnSwitchClickedProperty);
        set => SetValue(OnSwitchClickedProperty, value);
    }
    #endregion

    #region CardName
    public static readonly BindableProperty CardNameProperty =
        BindableProperty.Create(nameof(CardName), typeof(string), typeof(NotificationSettingsCard), null, BindingMode.TwoWay);
    public string CardName
    {
        get => (string)GetValue(CardNameProperty);
        set => SetValue(CardNameProperty, value);
    }
    #endregion
}