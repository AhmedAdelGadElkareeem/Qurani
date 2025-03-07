using WytSky.Mobile.Maui.Skoola.APIs;
using WytSky.Mobile.Maui.Skoola.Helpers;
using WytSky.Mobile.Maui.Skoola.Services.Implementation;
using WytSky.Mobile.Maui.Skoola.Utilities;
using WytSky.Mobile.Maui.Skoola.Views.Complexes;
using WytSky.Mobile.Maui.Skoola.Views.User;

namespace WytSky.Mobile.Maui.Skoola
{
    public partial class App : Application
    {
        #region Properties
        public static int ScreenHeight { get; set; }
        public static int ScreenWidth { get; set; }
        public static bool IsArabic { get; set; }

        public static ShowPopupService ShowPopupService = ShowPopupService.Instance;
        #endregion

        #region Constractor
        public App()
        {
            try
            {
                InitializeComponent();
                Application.Current.UserAppTheme = AppTheme.Light;
                ScreenHeight = (int)DeviceDisplay.Current.MainDisplayInfo.Height;
                ScreenWidth = (int)DeviceDisplay.Current.MainDisplayInfo.Width;
                //Settings.UserId =  AspUserRoleService.GetUserRoles().Result.Select(_=> _.UserID).ToString();
                IsArabic = Settings.Language == "ar";
                AppSettings.SetAppLanguage(Settings.Language);

                if (Settings.IsLogedin)
                {
                    MainPage = new AppShell();
                }
                else
                {
                    MainPage = new SignInSignUpPage();
                }
            }
            catch (Exception ex)
            {
                ExtensionLogMethods.LogExtension(ex.Message, "", "App", "Constructor");
            }
        }
        #endregion

        #region Methods
        public static void OpenMainPage()
        {
            try
            {
                // App.Current.MainPage = new MainPage();
                App.Current.MainPage = new AppShell();
                //ThemeHelper.ApplyTheme();
            }
            catch (Exception ex)
            {
                ExtensionLogMethods.LogExtension(ex.Message, "", "App", "OpenMainPage");
            }
        }
        public static void ResetUserNameAndPassword()
        {
            if (!Settings.IsLogedin)
            {
                Settings.Password = "";
                Settings.UserName = "";
            }
        }
        protected override void OnStart()
        {
            base.OnStart();
            var currentAppVersion = AppInfo.Current.BuildString;

        }
        public static void Logout()
        {
            try
            {
                #region Remove pages from stack
                try
                {
                    App.Current.MainPage.Navigation.PopModalAsync();
                }
                catch (Exception)
                {
                }
                try
                {
                    App.Current.MainPage.Navigation.PopModalAsync();
                }
                catch (Exception)
                {
                }
                try
                {
                    App.Current.MainPage.Navigation.PopModalAsync();
                }
                catch (Exception)
                {
                }
                #endregion

                ResetUserNameAndPassword();

                App.Current.MainPage = new SignInSignUpPage();
            }
            catch (Exception ex)
            {
                ExtensionLogMethods.LogExtension(ex, null, "App.cs", "Logout");
            }
        }
        #endregion
    }
}
