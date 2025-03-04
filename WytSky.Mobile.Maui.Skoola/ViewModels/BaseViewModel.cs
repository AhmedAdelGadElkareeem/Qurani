using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Globalization;
using WytSky.Mobile.Maui.Skoola.AppResources;
using WytSky.Mobile.Maui.Skoola.Helpers;
using WytSky.Mobile.Maui.Skoola.Views.User;

namespace WytSky.Mobile.Maui.Skoola.ViewModels
{
    public partial class BaseViewModel : ObservableObject
    {
        [ObservableProperty]
        public string lang;

        [ObservableProperty]
        private bool cartDetailsVisibility = false;

        [ObservableProperty]
        public bool isRunning;

        [ObservableProperty]
        public bool isEnglish;

        [ObservableProperty]
        public string languageTitle;

        public BaseViewModel()
        {
            Lang = Settings.Language;
            if (Lang == "ar")
            {
                IsEnglish = false;
                LanguageTitle = "English";
            }
            else
            {
                IsEnglish = true;
                LanguageTitle = "العربية";
            }
        }

        public bool HasInternetConnection()
        {
            NetworkAccess accessType = Connectivity.Current.NetworkAccess;
            return accessType == NetworkAccess.Internet;
        }

        public void SetUserNameAndPassword()
        {
            if (!Settings.IsLogedin)
            {
                Settings.Password = "sky365@365";
                Settings.UserName = "sky365";
            }
        }

        public void ResetUserNameAndPassword()
        {
            if (!Settings.IsLogedin)
            {
                Settings.Password = "";
                Settings.UserName = "";
            }
        }

        public void Logout()
        {
            try
            {
                Settings.IsLogedin = false;
                Settings.ClientId = long.MinValue;
                Settings.ClientName = "";
                Settings.ClientEmail = "";
                Settings.ClientPhone = "";
                Settings.Client = null;
                Settings.Password = "";
                Settings.AuthoToken = "";
                if (!string.IsNullOrEmpty(Settings.SocialID))
                {
                    Settings.UserName = "";
                }
                Settings.SocialID = "";
                App.Current.MainPage = new NavigationPage(new SignInSignUpPage())
                {
                    FlowDirection = Settings.Language == "ar" ? FlowDirection.RightToLeft : FlowDirection.LeftToRight
                };
            }
            catch (System.Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error : {ex.Message}");
            }
        }


        public void ChangeLanguage()
        {
            try
            {
                CultureInfo culture;
                if (Settings.Language == "ar")
                {
                    Settings.Language = "en";
                    culture = new CultureInfo("en-US");
                }
                else
                {
                    Settings.Language = "ar";
                    culture = new CultureInfo("ar-AE");
                }
                Thread.CurrentThread.CurrentCulture = culture;
                Thread.CurrentThread.CurrentUICulture = culture;
                AppResources.SharedResources.Culture = culture;
                Thread.CurrentThread.CurrentUICulture.NumberFormat = new CultureInfo("en").NumberFormat;
                Thread.CurrentThread.CurrentUICulture.DateTimeFormat = new CultureInfo("en").DateTimeFormat;
                App.Current.MainPage = new MainPage();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(string.Format(" Error : {0} - {1} ", ex.Message, ex.InnerException != null ? ex.InnerException.FullMessage() : ""));
            }
        }
    }
}
