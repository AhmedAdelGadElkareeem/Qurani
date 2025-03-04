
using WytSky.Mobile.Maui.Skoola.Helpers;
using WytSky.Mobile.Maui.Skoola.Validations;

namespace WytSky.Mobile.Maui.Skoola.CustomControl;

public partial class ValidationEntry : BaseContentView
{
    public ValidationEntry()
    {
        try
        {
            InitializeComponent();
            // container.HeightRequest = App.ScreenHeight / 50;
            this.FlowDirection = Settings.Language == "ar" ? FlowDirection.RightToLeft : FlowDirection.LeftToRight;
        }
        catch (Exception ex)
        {
            ExtensionLogMethods.LogExtension(ex.Message, "", "ValidationEntry", "Constructor");
        }
    }

    #region IsPassword

    public static readonly BindableProperty IsPasswordProperty =
        BindableProperty.Create(nameof(IsPassword),
        typeof(bool), typeof(ValidationEntry), false,
        BindingMode.TwoWay);
    // Gets or sets IsPassword value  
    public bool IsPassword
    {
        get => (bool)GetValue(IsPasswordProperty);
        set => SetValue(IsPasswordProperty, value);
    }
    #endregion

    #region HasPasswordImage

    public static readonly BindableProperty HasPasswordImageProperty =
        BindableProperty.Create(nameof(HasPasswordImage),
        typeof(bool), typeof(ValidationEntry), false,
        BindingMode.TwoWay);
    public bool HasPasswordImage
    {
        get => (bool)GetValue(HasPasswordImageProperty);
        set => SetValue(HasPasswordImageProperty, value);
    }
    #endregion

    #region EntryIsEnabled
    public static readonly BindableProperty EntryIsEnabledProperty =
        BindableProperty.Create(nameof(EntryIsEnabled),
        typeof(bool), typeof(ValidationEntry), true,
        BindingMode.TwoWay);
    public bool EntryIsEnabled
    {
        get => (bool)GetValue(EntryIsEnabledProperty);
        set => SetValue(EntryIsEnabledProperty, value);
    }
    #endregion

    #region EntryValidatableObject
    public static readonly BindableProperty EntryValidatableObjectProperty =
        BindableProperty.Create(
            propertyName: "EntryValidatableObject",
            returnType: typeof(ValidatableObject<string>),
            declaringType: typeof(ValidationEntry),
            new ValidatableObject<string>(),
            BindingMode.TwoWay,
            propertyChanged: EntryValidatableObjectChanged);
    public ValidatableObject<string> EntryValidatableObject
    {
        get => (ValidatableObject<string>)GetValue(EntryValidatableObjectProperty);
        set => SetValue(EntryValidatableObjectProperty, value);
    }
    private static void EntryValidatableObjectChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var control = (ValidationEntry)bindable;
        control.EntryValidatableObject = (ValidatableObject<string>)newValue;
    }
    #endregion

    #region KeyboardType 
    public static readonly BindableProperty KeyboardTypeProperty =
        BindableProperty.Create(nameof(KeyboardType), typeof(Keyboard),
        typeof(Keyboard), Keyboard.Default, BindingMode.TwoWay);
    public Keyboard KeyboardType
    {
        get => (Keyboard)GetValue(KeyboardTypeProperty);
        set => SetValue(KeyboardTypeProperty, value);
    }
    #endregion

    #region Placeholder
    public static readonly BindableProperty PlaceholderProperty =
        BindableProperty.Create(nameof(Placeholder),
        typeof(string), typeof(ValidationEntry), "", BindingMode.TwoWay);
    // Gets or sets Header value  
    public string Placeholder
    {
        get => (string)GetValue(PlaceholderProperty);
        set => SetValue(PlaceholderProperty, value);
    }
    #endregion

    #region BorderColor
    public static readonly BindableProperty BorderColorProperty =
        BindableProperty.Create(nameof(BorderColor),
        typeof(Color), typeof(ValidationEntry), Colors.Transparent,
        BindingMode.TwoWay);
    public Color BorderColor
    {
        get => (Color)GetValue(BorderColorProperty);
        set => SetValue(BorderColorProperty, value);
    }
    #endregion

    #region TextLabel
    public static readonly BindableProperty TextLabelProperty =
        BindableProperty.Create(nameof(TextLabel),
        typeof(string), typeof(ValidationEntry), "", BindingMode.TwoWay);
    public string TextLabel
    {
        get => (string)GetValue(TextLabelProperty);
        set => SetValue(TextLabelProperty, value);
    }
    #endregion

    private void ShowHidePassword(object sender, TappedEventArgs e)
    {
        try
        {
            IsPassword = !IsPassword;
        }
        catch (Exception ex)
        {
            ExtensionLogMethods.LogExtension(ex.Message, "", "ValidationEntry", "ShowHidePassword");
        }
    }

    private void HideKeyboard(object sender, FocusEventArgs e)
    {

    }

    private void HideKeyboardCompleted(object sender, EventArgs e)
    {

    }
}