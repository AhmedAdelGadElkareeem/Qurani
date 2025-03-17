
using System.Globalization;
using WytSky.Mobile.Maui.Skoola.AppResources;
using WytSky.Mobile.Maui.Skoola.Helpers;
using WytSky.Mobile.Maui.Skoola.Views.User;

namespace WytSky.Mobile.Maui.Skoola.Utilities;

public class AppSettings
{
    public static void SetAppLanguage(string lang)
    {
        try
        {
            CultureInfo culture;
            if (lang == "ar")
                culture = new CultureInfo("ar-AE");
            else
                culture = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
            CultureInfo.CurrentCulture = culture;
            CultureInfo.CurrentUICulture = culture;
            SharedResources.Culture = culture;
            Settings.Language = lang;

            //if (!Settings.IsLogedin)
            //{
            //    App.Current.MainPage = new SignInSignUpPage();
            //}
            //else
            //{
            //    App.Current.MainPage = new AppShell();
            //}
        }
        catch (Exception ex)
        {
            ExtensionLogMethods.LogExtension(ex, null, "", "");
        }
    }

    public static void NewSetAppLanguage(string lang)
    {
        try
        {
            CultureInfo culture;
            if (lang == "ar")
                culture = new CultureInfo("ar-AE");
            else
                culture = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
            CultureInfo.CurrentCulture = culture;
            CultureInfo.CurrentUICulture = culture;
            SharedResources.Culture = culture;
            Settings.Language = lang;
        }
        catch (Exception ex)
        {
            ExtensionLogMethods.LogExtension(ex, null, "", "");
        }
    }
}
