using WytSky.Mobile.Maui.Skoola.AppResources;
using WytSky.Mobile.Maui.Skoola.ViewModels.User;

namespace WytSky.Mobile.Maui.Skoola.Views.User;

public partial class ForgotPasswordPage : BaseContentPage
{
    ForgetPasswordVM ForgetPasswordVM = new ForgetPasswordVM();
    public ForgotPasswordPage(bool isFromLogin)
    {
        InitializeComponent();

        if (!isFromLogin)
            pageName.Text = SharedResources.VerifyAccount;

        ForgetPasswordVM.IsFromLogin = isFromLogin;
        BindingContext = ForgetPasswordVM;
    }
}