using Microsoft.Maui;
using Color = Microsoft.Maui.Graphics.Color;

namespace WytSky.Mobile.Maui.Skoola.CustomControl;

public partial class MEntry : ContentView
{
    #region Constructor

    public MEntry()
    {
        try
        {
            InitializeComponent();
        }
        catch (System.Exception ex)
        {
            System.ExtensionLogMethods.LogExtension(ex, "", "MEntry", "Constructor");
        }
    }

    #endregion

    #region TextColor

    public static readonly BindableProperty TextColorProperty =
        BindableProperty.Create(nameof(TextColor),
        typeof(Color), typeof(MEntry), Colors.Black,
        BindingMode.TwoWay);
    // Gets or sets TextColor value  
    public Color TextColor
    {
        get => (Color)GetValue(TextColorProperty);
        set => SetValue(TextColorProperty, value);
    }

    #endregion

    #region BorderColor

    public static readonly BindableProperty BorderColorProperty =
        BindableProperty.Create(nameof(BorderColor),
        typeof(Color), typeof(MEntry), Colors.Black,
        BindingMode.TwoWay);
    // Gets or sets BorderColor value  
    public Color BorderColor
    {
        get => (Color)GetValue(BorderColorProperty);
        set => SetValue(BorderColorProperty, value);
    }

    #endregion

    #region KeyboardType 

    public static readonly BindableProperty KeyboardTypeProperty =
        BindableProperty.Create(nameof(KeyboardType), typeof(Keyboard),
        typeof(MEntry), defaultValue: Keyboard.Default, BindingMode.OneWay);
    public Keyboard KeyboardType
    {
        get => (Keyboard)GetValue(KeyboardTypeProperty);
        set => SetValue(KeyboardTypeProperty, value);
    }

    #endregion

    #region FontFamily

    public static readonly BindableProperty FontFamilyProperty =
        BindableProperty.Create(nameof(FontFamily),
        typeof(string), typeof(MEntry));
    // Gets or sets FontFamily value  
    public string FontFamily
    {
        get => (string)GetValue(FontFamilyProperty);
        set => SetValue(FontFamilyProperty, value);
    }

    #endregion

    #region HorizontalTextAlignment

    public static readonly BindableProperty HorizontalTextAlignmentProperty =
        BindableProperty.Create(nameof(HorizontalTextAlignment),
        typeof(TextAlignment), typeof(MEntry),
        defaultValue: TextAlignment.Start);
    // Gets or sets HorizontalTextAlignment value  
    public TextAlignment HorizontalTextAlignment
    {
        get => (TextAlignment)GetValue(HorizontalTextAlignmentProperty);
        set => SetValue(HorizontalTextAlignmentProperty, value);
    }

    #endregion

    #region PlaceholderColor

    public static readonly BindableProperty PlaceholderColorProperty =
        BindableProperty.Create(nameof(PlaceholderColor),
        typeof(Color), typeof(MEntry), Colors.Gray,
        BindingMode.TwoWay);
    // Gets or sets PlaceholderColor value  
    public Color PlaceholderColor
    {
        get => (Color)GetValue(PlaceholderColorProperty);
        set => SetValue(PlaceholderColorProperty, value);
    }

    #endregion

    #region Placeholder

    public static readonly BindableProperty PlaceholderProperty =
        BindableProperty.Create(nameof(Placeholder),
        typeof(string), typeof(MEntry), "", BindingMode.TwoWay);
    // Gets or sets Header value  
    public string Placeholder
    {
        get => (string)GetValue(PlaceholderProperty);
        set => SetValue(PlaceholderProperty, value);
    }

    #endregion

    #region IconSource

    public static readonly BindableProperty IconSourceProperty =
        BindableProperty.Create(nameof(IconSource),
        typeof(string), typeof(MEntry), "", BindingMode.TwoWay);
    // Gets or sets IconSource value  
    public string IconSource
    {
        get => (string)GetValue(IconSourceProperty);
        set => SetValue(IconSourceProperty, value);
    }

    #endregion

    #region Text

    public static readonly BindableProperty TextProperty =
        BindableProperty.Create(nameof(Text),
        typeof(string), typeof(MEntry), "", BindingMode.TwoWay);
    // Gets or sets Text value  
    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    #endregion

    #region IsPassword

    public static readonly BindableProperty IsPasswordProperty =
        BindableProperty.Create(nameof(IsPassword),
        typeof(bool), typeof(MEntry), false,
        BindingMode.TwoWay);
    // Gets or sets IsPassword value  
    public bool IsPassword
    {
        get => (bool)GetValue(IsPasswordProperty);
        set => SetValue(IsPasswordProperty, value);
    }
    #endregion

    #region IsRequired
    public static readonly BindableProperty IsRequiredProperty =
        BindableProperty.Create(nameof(IsRequired),
        typeof(bool), typeof(MEntry), false,
        BindingMode.TwoWay);
    public bool IsRequired
    {
        get => (bool)GetValue(IsRequiredProperty);
        set => SetValue(IsRequiredProperty, value);
    }
    #endregion
    

    #region IsShowPassword

    public static readonly BindableProperty IsShowPasswordProperty =
        BindableProperty.Create(nameof(IsShowPassword),
        typeof(bool), typeof(MEntry), true,
        BindingMode.TwoWay);

    // Gets or sets IsShowPassword value  
    public bool IsShowPassword
    {
        get => (bool)GetValue(IsShowPasswordProperty);
        set => SetValue(IsShowPasswordProperty, value);
    }

    #endregion

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        try
        {
            IsPassword = !IsPassword;
        }
        catch (System.Exception ex)
        {
            System.ExtensionLogMethods.LogExtension(ex, "", "MEntry", "TapGestureRecognizer_Tapped");
        }
    }
}