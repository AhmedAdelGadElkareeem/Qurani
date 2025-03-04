namespace WytSky.Mobile.Maui.Skoola.Views.User;

public partial class AccountCreatedSuccessfullyPage : BaseContentPage
{
	public AccountCreatedSuccessfullyPage()
	{
		InitializeComponent();
	}

    private void Login(object sender, EventArgs e)
    {
		App.Current.MainPage = new SignInSignUpPage();
    }
}