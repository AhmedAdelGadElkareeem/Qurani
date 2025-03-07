using Microsoft.Maui.Handlers;
using WytSky.Mobile.Maui.Skoola.AppResources;

namespace WytSky.Mobile.Maui.Skoola.CustomControl;

//public partial class DatePickerFromTo : ContentView
//{
//	public DatePickerFromTo()
//	{
//		InitializeComponent();
//	}
//}

public partial class DatePickerFromTo : ContentView
{
    public DatePickerFromTo()
    {
        InitializeComponent();
        fromDatePicker.MaximumDate = DateTime.Now;
        toDatePicker.MaximumDate = DateTime.Now;
        UpdateDateRangeValue();
    }

    public static readonly BindableProperty FromDateProperty =
      BindableProperty.Create(
          nameof(FromDate),
          typeof(DateTime?),
          typeof(DatePickerFromTo),
          DateTime.Now,
          BindingMode.TwoWay);
    public DateTime? FromDate
    {
        get => (DateTime?)GetValue(FromDateProperty);
        set => SetValue(FromDateProperty, value);
    }

    public static readonly BindableProperty ToDateProperty =
        BindableProperty.Create(
            nameof(ToDate),
            typeof(DateTime?),
            typeof(DatePickerFromTo),
            DateTime.Now,
            BindingMode.TwoWay);

    public static readonly BindableProperty DateRangeValueProperty =
        BindableProperty.Create(
            nameof(DateRangeValue),
            typeof(string),
            typeof(DatePickerFromTo),
            string.Empty,
            BindingMode.TwoWay);

    public static readonly BindableProperty IsFromDateChangedProperty =
        BindableProperty.Create(
            nameof(IsFromDateChanged),
            typeof(bool),
            typeof(DatePickerFromTo),
            false,
            BindingMode.TwoWay);

    public static readonly BindableProperty IsToDateChangedProperty =
        BindableProperty.Create(
            nameof(IsToDateChanged),
            typeof(bool),
            typeof(DatePickerFromTo),
            false,
            BindingMode.TwoWay);

    public DateTime? ToDate
    {
        get => (DateTime?)GetValue(ToDateProperty);
        set => SetValue(ToDateProperty, value);
    }

    public string DateRangeValue
    {
        get => (string)GetValue(DateRangeValueProperty);
        set => SetValue(DateRangeValueProperty, value);
    }

    public bool IsFromDateChanged
    {
        get => (bool)GetValue(IsFromDateChangedProperty);
        set => SetValue(IsFromDateChangedProperty, value);
    }

    public bool IsToDateChanged
    {
        get => (bool)GetValue(IsToDateChangedProperty);
        set => SetValue(IsToDateChangedProperty, value);
    }

    private void FromDateSelected(object sender, DateChangedEventArgs e)
    {
        FromDate = e.NewDate;
        UpdateDateRangeValue();
        IsFromDateChanged = true;
        IsToDateChanged = false;

#if ANDROID
        var handler = toDatePicker.Handler as IDatePickerHandler;
        handler?.PlatformView.PerformClick();
#endif
    }

    private void ToDateSelected(object sender, DateChangedEventArgs e)
    {
        ToDate = e.NewDate;
        UpdateDateRangeValue();
        IsFromDateChanged = true;
        IsToDateChanged = true;
    }

    private void SelectFromDate(object sender, TappedEventArgs e)
    {
#if ANDROID
        var handler = fromDatePicker.Handler as IDatePickerHandler;
        handler?.PlatformView.PerformClick();
#endif
    }

    private void UpdateDateRangeValue()
    {
        DateRangeValue = $"{SharedResources.FromDate} {FromDate:yyyy/MM/dd}  {SharedResources.ToDate} {ToDate:yyyy/MM/dd}";
    }
}