
namespace WytSky.Mobile.Maui.Skoola.CustomControl;

public partial class WhiteBackView : BaseContentView
{
	public WhiteBackView()
	{
		InitializeComponent();
	}

    #region HasPageName
    public static readonly BindableProperty HasPageNameProperty =
        BindableProperty.Create(nameof(HasPageName), typeof(bool), typeof(WhiteBackView), false, BindingMode.TwoWay);
    public bool HasPageName
    {
        get => (bool)GetValue(HasPageNameProperty);
        set => SetValue(HasPageNameProperty, value);
    }
    #endregion

    #region PageName
    public static readonly BindableProperty PageNameProperty =
        BindableProperty.Create(nameof(PageName), typeof(string), typeof(WhiteBackView), null, BindingMode.TwoWay);
    public string PageName
    {
        get => (string)GetValue(PageNameProperty);
        set => SetValue(PageNameProperty, value);
    }
    #endregion
    private void GoBack(object sender, TappedEventArgs e)
    {
        NavigateToPage.ClosePage();
    }
}