using WytSky.Mobile.Maui.Skoola.ViewModels.User;

namespace WytSky.Mobile.Maui.Skoola.Views.User;

public partial class ChangePasswordPage : BaseContentPage
{
	public ChangePasswordPage()
	{
		InitializeComponent();
		BindingContext = new ChangePasswordVM();
    }
}