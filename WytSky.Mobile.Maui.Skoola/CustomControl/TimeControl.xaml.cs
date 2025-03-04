namespace WytSky.Mobile.Maui.Skoola.CustomControl;

public partial class TimeControl : ContentView
{
    #region Time : TimeSpan
    public static readonly BindableProperty TimeProperty =
    BindableProperty.Create(nameof(Time),
        typeof(TimeSpan), typeof(TimeControl), null , BindingMode.TwoWay);
    public TimeSpan Time
    {
        get => (TimeSpan)GetValue(TimeProperty);
        set => SetValue(TimeProperty, value);
    }
    #endregion

    public TimeControl()
	{
        try
        {
            InitializeComponent();
        }
        catch (Exception ex)
        {
            ExtensionLogMethods.LogExtension(ex,"","","");
        }
    }

    private void OpenTimePicker(object sender, TappedEventArgs e)
    {
        timePicker.Focus();
    }
}