namespace WytSky.Mobile.Maui.Skoola.Views.User;

public partial class SecurityPage : BaseContentPage
{
	public SecurityPage()
	{
		InitializeComponent();
	}

    private async void OpenChangePasswordPage(object sender, EventArgs e)
    {
		await NavigateToPage.OpenPage(new ChangePasswordPage());
    }
}