using WytSky.Mobile.Maui.Skoola.Helpers;
using WytSky.Mobile.Maui.Skoola.ViewModels.User;

namespace WytSky.Mobile.Maui.Skoola.Views.User;

public partial class SignInSignUpPage : BaseContentPage
{
    private SignInSignUpVM signInSignUpVM = new SignInSignUpVM();
    public SignInSignUpPage()
    {
        try
        {
            InitializeComponent();
            BindingContext = signInSignUpVM;
        }
        catch (Exception ex)
        {
            ExtensionLogMethods.LogExtension(ex, "", "SignInSignUpPage", "Constructor");
        }
    }

    private void Back(object sender, TappedEventArgs e)
    {
        signInSignUpVM.IsVisibleLogin = true;
        signInSignUpVM.IsVisibleRegister = false;
    }
}