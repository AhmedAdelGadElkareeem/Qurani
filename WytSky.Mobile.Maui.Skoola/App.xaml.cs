using WytSky.Mobile.Maui.Skoola.Helpers;
using WytSky.Mobile.Maui.Skoola.Views.User;

namespace WytSky.Mobile.Maui.Skoola
{
    public partial class App : Application
    {
        public static bool IsArabic { get;set; }

        public App()
        {
            try
            {
                InitializeComponent();
                Application.Current.UserAppTheme = AppTheme.Light;
                IsArabic = Settings.Language == "ar";
                if (Settings.IsLogedin)
                {
                    App.Current.MainPage = new NavigationPage(new MainPage());
                }
                else
                {
                    App.Current.MainPage = new SignInSignUpPage();
                }
            }
            catch (Exception ex)
            {
                ExtensionLogMethods.LogExtension(ex.Message, "", "App", "Constructor");
            }
        }
    }
}
