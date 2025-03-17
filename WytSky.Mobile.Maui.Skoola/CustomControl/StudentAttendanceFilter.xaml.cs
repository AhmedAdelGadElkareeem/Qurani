using System.Windows.Input;

namespace WytSky.Mobile.Maui.Skoola.CustomControl;

public partial class StudentAttendanceFilter : ContentView
{
    #region Constractor
    public StudentAttendanceFilter()
    {
        try
        {
            InitializeComponent();
        }
        catch (System.Exception ex)
        {
            System.ExtensionLogMethods.LogExtension(ex, "", "StudentAttendanceFilter", "Constructor");
        }
    }
    #endregion

    #region TextLable

    public static readonly BindableProperty TextLableProperty =
        BindableProperty.Create(nameof(TextLable),
        typeof(string), typeof(StudentAttendanceFilter), default,
        BindingMode.TwoWay);
    // Gets or sets TextLable value  
    public string TextLable
    {
        get => (string)GetValue(TextLableProperty);
        set => SetValue(TextLableProperty, value);
    }

    public static readonly BindableProperty TextLabelProperty =
    BindableProperty.Create(nameof(TextLabel),
    typeof(string), typeof(StudentAttendanceFilter), default,
    BindingMode.TwoWay);

    public string TextLabel
    {
        get => (string)GetValue(TextLabelProperty);
        set => SetValue(TextLabelProperty, value);
    }


    #endregion

    #region TextCount

    public static readonly BindableProperty TextCountProperty =
        BindableProperty.Create(nameof(TextCount),
        typeof(string), typeof(StudentAttendanceFilter), default,
        BindingMode.TwoWay);
    // Gets or sets TextCount value  
    public string TextCount
    {
        get => (string)GetValue(TextCountProperty);
        set => SetValue(TextCountProperty, value);
    }

    #endregion

    #region BackColor

    public static readonly BindableProperty BackColorProperty =
        BindableProperty.Create(nameof(BackColor),
        typeof(Color), typeof(StudentAttendanceFilter), Colors.Silver,
        BindingMode.TwoWay);
    // Gets or sets BackColor value  
    public Color BackColor
    {
        get => (Color)GetValue(BackColorProperty);
        set => SetValue(BackColorProperty, value);
    }

    #endregion

    #region Command
    public static readonly BindableProperty CommandProperty =
    BindableProperty.Create(nameof(Command),
        typeof(ICommand), typeof(StudentAttendanceFilter), defaultValue: null, BindingMode.TwoWay);
    public ICommand Command
    {
        get => (ICommand)GetValue(CommandProperty);
        set => SetValue(CommandProperty, value);
    }
    #endregion

    #region CommanParamter

    public static readonly BindableProperty CommanParamterProperty =
        BindableProperty.Create(nameof(CommanParamter),
        typeof(Enums.StudentsStatus), typeof(StudentAttendanceFilter), default,
        BindingMode.TwoWay);
    // Gets or sets TextLable value  
    public Enums.StudentsStatus CommanParamter
    {
        get => (Enums.StudentsStatus)GetValue(CommanParamterProperty);
        set => SetValue(CommanParamterProperty, value);
    }


    public static readonly BindableProperty CommandParameterProperty =
    BindableProperty.Create(nameof(CommandParameter),
    typeof(Enums.StudentsStatus), typeof(StudentAttendanceFilter), default,
    BindingMode.TwoWay);

    public Enums.StudentsStatus CommandParameter
    {
        get => (Enums.StudentsStatus)GetValue(CommandParameterProperty);
        set => SetValue(CommandParameterProperty, value);
    }

    #endregion

    #region buttontext
    public static readonly BindableProperty ButtonTextProperty =
    BindableProperty.Create(nameof(ButtonText),
    typeof(string), typeof(StudentAttendanceFilter), default,
    BindingMode.TwoWay);

    public string ButtonText
    {
        get => (string)GetValue(ButtonTextProperty);
        set => SetValue(ButtonTextProperty, value);
    }

    #endregion
}