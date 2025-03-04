namespace WytSky.Mobile.Maui.Skoola.Template.Chat;

public partial class RecievedMessageTemplate : VerticalStackLayout
{
	public RecievedMessageTemplate()
	{
		InitializeComponent();
	}

    #region Title
    public static readonly BindableProperty TitleProperty =
        BindableProperty.Create(nameof(Title),
        typeof(string), typeof(SentMessageTemplate), null,
        BindingMode.TwoWay);
    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }
    #endregion

    #region Time
    public static readonly BindableProperty TimeProperty =
        BindableProperty.Create(nameof(Time),
        typeof(string), typeof(SentMessageTemplate), null,
        BindingMode.TwoWay);
    public string Time
    {
        get => (string)GetValue(TimeProperty);
        set => SetValue(TimeProperty, value);
    }
    #endregion
}