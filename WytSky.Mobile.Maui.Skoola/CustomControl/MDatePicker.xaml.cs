using System.Windows.Input;

namespace WytSky.Mobile.Maui.Skoola.CustomControl;

public partial class MDatePicker : ContentView
{

    public MDatePicker()
    {
        try
        {
            InitializeComponent();
        }
        catch (Exception ex)
        {
            System.ExtensionLogMethods.LogExtension(ex, "", "MDatePicker", "Constructor");
        }
    }

    #region Date : DateTime
    public static readonly BindableProperty DateProperty =
    BindableProperty.Create(nameof(Date),
        typeof(DateTime), typeof(MDatePicker),
        null, BindingMode.TwoWay);
    // Gets or sets Date value  
    public DateTime Date
    {
        get => (DateTime)GetValue(DateProperty);
        set => SetValue(DateProperty, value);
    }
    #endregion

    #region TextColor

    public static readonly BindableProperty TextColorProperty =
        BindableProperty.Create(nameof(TextColor),
        typeof(Color), typeof(MDatePicker), Colors.Black,
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
        typeof(Color), typeof(MDatePicker), Colors.Black,
        BindingMode.TwoWay);
    // Gets or sets BorderColor value  
    public Color BorderColor
    {
        get => (Color)GetValue(BorderColorProperty);
        set => SetValue(BorderColorProperty, value);
    }

    #endregion

    #region FontFamily

    public static readonly BindableProperty FontFamilyProperty =
        BindableProperty.Create(nameof(FontFamily),
        typeof(string), typeof(MDatePicker));
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
        typeof(TextAlignment), typeof(MDatePicker),
        defaultValue: TextAlignment.Start);
    // Gets or sets HorizontalTextAlignment value  
    public TextAlignment HorizontalTextAlignment
    {
        get => (TextAlignment)GetValue(HorizontalTextAlignmentProperty);
        set => SetValue(HorizontalTextAlignmentProperty, value);
    }

    #endregion

    #region HeaderColor

    public static readonly BindableProperty HeaderColorProperty =
        BindableProperty.Create(nameof(HeaderColor),
        typeof(Color), typeof(MDatePicker), Colors.Black,
        BindingMode.TwoWay);
    // Gets or sets HeaderColor value  
    public Color HeaderColor
    {
        get => (Color)GetValue(HeaderColorProperty);
        set => SetValue(HeaderColorProperty, value);
    }

    #endregion

    #region PlaceholderColor

    public static readonly BindableProperty PlaceholderColorProperty =
        BindableProperty.Create(nameof(PlaceholderColor),
        typeof(Color), typeof(MDatePicker), Colors.Gray,
        BindingMode.TwoWay);
    // Gets or sets PlaceholderColor value  
    public Color PlaceholderColor
    {
        get => (Color)GetValue(PlaceholderColorProperty);
        set => SetValue(PlaceholderColorProperty, value);
    }

    #endregion

    #region Header

    public static readonly BindableProperty HeaderProperty =
        BindableProperty.Create(nameof(Header),
        typeof(string), typeof(MDatePicker), "", BindingMode.TwoWay);
    // Gets or sets Header value  
    public string Header
    {
        get => (string)GetValue(HeaderProperty);
        set => SetValue(HeaderProperty, value);
    }

    #endregion

    #region DateChangeCommand

    public static readonly BindableProperty DateChangeCommandProperty =
    BindableProperty.Create(nameof(Command),
        typeof(ICommand), typeof(MDatePicker),
        defaultValue: null, BindingMode.TwoWay);
    // Gets or sets Command value  
    public ICommand DateChangeCommand
    {
        get => (ICommand)GetValue(DateChangeCommandProperty);
        set => SetValue(DateChangeCommandProperty, value);
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

    private void OpenDatePicker(object sender, TappedEventArgs e)
    {
        try
        {
            datePicker.Focus();
        }
        catch (Exception ex)
        {
            System.ExtensionLogMethods.LogExtension(ex, "", "MDatePicker", "OpenDatePicker");
        }
    }

    private void datePicker_DateSelected(object sender, DateChangedEventArgs e)
    {
        try
        {
            if (DateChangeCommand != null && DateChangeCommand.CanExecute(Date))
            {
                DateChangeCommand.Execute(Date);
            }
        }
        catch (Exception ex)
        {
            System.ExtensionLogMethods.LogExtension(ex, "", "MDatePicker", "datePicker_DateSelected");
        }
    }
}