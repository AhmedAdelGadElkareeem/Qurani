
namespace WytSky.Mobile.Maui.Skoola.CustomControl;

public partial class DateTimeControl : ContentView
{

    #region Date : DateTime
    public static readonly BindableProperty DateProperty =
    BindableProperty.Create(nameof(Date),
        typeof(DateTime), typeof(DateTimeControl),
        DateTime.Now.Date,
        BindingMode.TwoWay);
    public DateTime Date
    {
        get => (DateTime)GetValue(DateProperty);
        set => SetValue(DateProperty, value);
    }
    #endregion

    #region Time : TimeSpan
    public static readonly BindableProperty TimeProperty =
    BindableProperty.Create(nameof(Time),
        typeof(TimeSpan), typeof(DateTimeControl), 
        DateTime.Now.TimeOfDay, BindingMode.TwoWay);
    public TimeSpan Time
    {
        get => (TimeSpan)GetValue(TimeProperty);
        set => SetValue(TimeProperty, value);
    }
    #endregion


    private string dateTimeValue;
    public string DateTimeValue
    {
        get 
        { 
            dateTimeValue =  Date + " "+ Time;
            return dateTimeValue;
        }
        set 
        {
            dateTimeValue = Date + " " + Time; 
            OnPropertyChanged();
        }
    }


    public DateTimeControl()
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

    private void OpenDatePicker(object sender, TappedEventArgs e)
    {
        try
        {
            datePicker.Focus();
        }
        catch (Exception ex)
        {
            ExtensionLogMethods.LogExtension(ex,"","","");
        }
    }

    private void datePicker_DateSelected(object sender, DateChangedEventArgs e)
    {
        try
        {
            datePicker.Unfocus();
            timePicker.Focus();
        }
        catch (Exception ex)
        {
            ExtensionLogMethods.LogExtension(ex,"","","");
        }
    }
}