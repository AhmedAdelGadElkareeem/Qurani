using System.Windows.Input;

namespace WytSky.Mobile.Maui.Skoola.CustomControl;

public partial class HomeCard : ContentView
{
    #region Constractor
    public HomeCard()
	{
		InitializeComponent();
	}
    #endregion

    #region Properties

    #region CommandParameter
    public static readonly BindableProperty CommandParameterProperty =
    BindableProperty.Create(nameof(CommandParameter),
        typeof(object), typeof(HomeCard), defaultValue: null, BindingMode.TwoWay);
    public object CommandParameter
    {
        get => (object)GetValue(CommandParameterProperty);
        set => SetValue(CommandParameterProperty, value);
    }
    #endregion

    #region Command
    public static readonly BindableProperty CommandProperty =
    BindableProperty.Create(nameof(Command),
        typeof(ICommand), typeof(HomeCard), defaultValue: null, BindingMode.TwoWay);
    public ICommand Command
    {
        get => (ICommand)GetValue(CommandProperty);
        set => SetValue(CommandProperty, value);
    }
    #endregion

    #region HeightRequest
    public new static readonly BindableProperty HeightRequestProperty =
   BindableProperty.Create(nameof(HeightRequest),
       typeof(int), typeof(HomeCard), 17, BindingMode.TwoWay);
    public new int HeightRequest
    {
        get => (int)GetValue(HeightRequestProperty);
        set => SetValue(HeightRequestProperty, value);
    }
    #endregion

    #region WidthRequest
    public new static readonly BindableProperty WidthRequestProperty =
   BindableProperty.Create(nameof(WidthRequest),
       typeof(int), typeof(HomeCard), 17, BindingMode.TwoWay);
    public new int WidthRequest
    {
        get => (int)GetValue(WidthRequestProperty);
        set => SetValue(WidthRequestProperty, value);
    }
    #endregion

    #region TextLable

    public static readonly BindableProperty TextLableProperty =
        BindableProperty.Create(nameof(TextLable),
        typeof(string), typeof(HomeCard), default,
        BindingMode.TwoWay);
    public string TextLable
    {
        get => (string)GetValue(TextLableProperty);
        set => SetValue(TextLableProperty, value);
    }

    #endregion

    #region FontSize
    public static readonly BindableProperty FontSizeProperty =
    BindableProperty.Create(nameof(FontSize),
        typeof(string), typeof(HomeCard), default, 
        BindingMode.TwoWay);
    public string FontSize
    {
        get => (string)GetValue(FontSizeProperty);
        set => SetValue(FontSizeProperty, value);
    }
    #endregion

    #region BackColor

    public static readonly BindableProperty BackColorProperty =
        BindableProperty.Create(nameof(BackColor),
        typeof(Color), typeof(HomeCard), Colors.Silver,
        BindingMode.TwoWay);
    // Gets or sets BackColor value  
    public Color BackColor
    {
        get => (Color)GetValue(BackColorProperty);
        set => SetValue(BackColorProperty, value);
    }

    #endregion   

    #endregion


}