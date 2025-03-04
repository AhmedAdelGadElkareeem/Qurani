using WytSky.Mobile.Maui.Skoola.Helpers;
using WytSky.Mobile.Maui.Skoola.ViewModels;

namespace WytSky.Mobile.Maui.Skoola.CustomControl;

public partial class BackView : BaseContentView
{
	public BackView()
	{
		InitializeComponent();
	}

    #region PageTitle
    public static readonly BindableProperty PageTitleProperty =
        BindableProperty.Create(nameof(PageTitle), typeof(string), typeof(BackView), null, BindingMode.TwoWay);
    public string PageTitle
    {
        get => (string)GetValue(PageTitleProperty);
        set => SetValue(PageTitleProperty, value);
    }
    #endregion

    private async void Back(object sender, TappedEventArgs e)
    {
		await NavigateToPage.ClosePage();
    }
}