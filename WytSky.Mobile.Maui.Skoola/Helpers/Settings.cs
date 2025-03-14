﻿using System.Text.Json;
using WytSky.Mobile.Maui.Skoola.Dtos;

namespace WytSky.Mobile.Maui.Skoola.Helpers;

public class    Settings
{

    #region Setting Constants

    private const string SettingsKey = "settingsKey";
    private const string LanguageKey = "Language_Key";
    private const string UserNameKey = "UserName_Key";


    private static readonly string SettingsDefault = string.Empty;

    #endregion

    #region Properties
    public static string GeneralSettings
    {
        get { return Preferences.Get(SettingsKey, SettingsDefault); }
        set { Preferences.Set(SettingsKey, value); }
    }
    public static bool IsLogedin
    {
        get { return Preferences.Get("IsLogedinKey", false); }
        set { Preferences.Set("IsLogedinKey", value); }
    }
    public static bool ShowSliderInStart
    {
        get { return Preferences.Get("ShowSliderInStartKey", true); }
        set { Preferences.Set("ShowSliderInStartKey", value); }
    }
    public static bool IsAdmin
    {
        get { return Preferences.Get("IsAdminKey", false); }
        set { Preferences.Set("IsAdminKey", value); }
    }
    public static bool IsSupervisor
    {
        get { return Preferences.Get("IsSupervisorKey", false); }
        set { Preferences.Set("IsSupervisorKey", value); }
    }
    public static bool IsTeacher
    {
        get { return Preferences.Get("IsTeacherKey", false); }
        set { Preferences.Set("IsSupervisorKey", value); }
    }
    public static bool IsUsers
    {
        get { return Preferences.Get("IsSupervisorKey", false); }
        set { Preferences.Set("IsSupervisorKey", value); }
    }

    public static bool IsOffline
    {
        get { return Preferences.Get("IsOfflineKey", false); }
        set { Preferences.Set("IsOfflineKey", value); }
    }

    //public static string Language
    //{
    //    get { return Preferences.Get("LanguageKey", System.Threading.Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName == "ar" ? "ar" : "en"); }
    //    set { Preferences.Set("LanguageKey", value); }
    //}

    #region Language
    public static string Language
    {
        get => Preferences.Get(LanguageKey, "ar");
        set => Preferences.Set(LanguageKey, value);
    }
    #endregion

    #region UserName

    public static string UserName
    {
        get => Preferences.Get(UserNameKey, "");
        set => Preferences.Set(UserNameKey, value);
    }

    #endregion
    public static long ClientId
    {
        get { return Preferences.Get("CustomerIdKey", long.MinValue); }
        set { Preferences.Set("CustomerIdKey", value); }
    }
    public static string ClientUrl
    {
        get { return Preferences.Get("ClientUrlKey", string.Empty); }
        set { Preferences.Set("ClientUrlKey", value); }
    }
    public static string ClientName
    {
        get { return Preferences.Get("CustomerNameKey", string.Empty); }
        set { Preferences.Set("CustomerNameKey", value); }
    }

    public static string UserId
    {
        get { return Preferences.Get("UserIdKey", string.Empty); }
        set { Preferences.Set("UserIdKey", value); }
    }

    public static bool RememberMe
    {
        get { return Preferences.Get("RememberMeKey", false); }
        set { Preferences.Set("RememberMeKey", value); }
    }
    
    //public static string UserName
    //{
    //    get { return Preferences.Get("UserNameKey", string.Empty); }
    //    set { Preferences.Set("UserNameKey", value); }
    //}
    public static string ClientEmail
    {
        get { return Preferences.Get("ClientEmailKey", string.Empty); }
        set { Preferences.Set("ClientEmailKey", value); }
    }
    public static string ClientPhone
    {
        get { return Preferences.Get("ClientPhoneKey", string.Empty); }
        set { Preferences.Set("ClientPhoneKey", value); }
    }
    public static string SocialID
    {
        get { return Preferences.Get("SocialIDKey", string.Empty); }
        set { Preferences.Set("SocialIDKey", value); }
    }
    public static string Password
    {
        get { return Preferences.Get("PasswordKey", string.Empty); }
        set { Preferences.Set("PasswordKey", value); }
    }
    public static string DeviceToken
    {
        get { return Preferences.Get("DeviceTokenKey", string.Empty); }
        set { Preferences.Set("DeviceTokenKey", value); }
    }
    public static string AuthoToken
    {
        get { return Preferences.Get("AuthoTokenKey", string.Empty); }
        set { Preferences.Set("AuthoTokenKey", value); }
    }
    public static string AuthoUserName
    {
        get { return Preferences.Get("AuthoUserNameKey", string.Empty); }
        set { Preferences.Set("AuthoUserNameKey", value); }
    }
    public static string AuthoPassword
    {
        get { return Preferences.Get("AuthoPasswordKey", string.Empty); }
        set { Preferences.Set("AuthoPasswordKey", value); }
    }
    public static string OrgCode
    {
        get { return Preferences.Get("OrgCodeKey", string.Empty); }
        set { Preferences.Set("OrgCodeKey", value); }
    }
    public static string URL
    {
        get { return Preferences.Get("URLKey", "http://box20.saskw.online/"); }
        set { Preferences.Set("URLKey", value); }
    }
    public static string IMEI
    {
        get { return Preferences.Get("IMEIKey", DependencyService.Get<Services.IDevice>().GetIdentifier()); }
        set { Preferences.Set("IMEIKey", value); }
    }
    public static string ComplexId
    {
        get { return Preferences.Get("ComplexId", null); }
        set { Preferences.Set("ComplexId", value); }
    }
    public static string CenterId
    {
        get { return Preferences.Get("CenterId", null); }
        set { Preferences.Set("CenterId", value); }
    }
    public static string StaffId
    {
        get { return Preferences.Get("StaffId", null); }
        set { Preferences.Set("StaffId", value); }
    }
    public static string StudyGroupId
    {
        get { return Preferences.Get("StudyGroupId", null); }
        set { Preferences.Set("StudyGroupId", value); }
    }
    public static string ScheduleId
    {
        get { return Preferences.Get("ScheduleId", null); }
        set { Preferences.Set("ScheduleId", value); }
    }
    public static string StudentId
    {
        get { return Preferences.Get("StudentId", null); }
        set { Preferences.Set("StudentId", value); }
    }
    public static System.Collections.ObjectModel.ObservableCollection<StItem> FavoriteItems
    {
        get
        {
            try
            {
                string value = Preferences.Get("FavoritesItemsKey", string.Empty);
                System.Collections.ObjectModel.ObservableCollection<StItem> myList;
                if (string.IsNullOrEmpty(value))
                    myList = new System.Collections.ObjectModel.ObservableCollection<StItem>();
                else
                    myList = System.Text.Json.JsonSerializer.Deserialize<System.Collections.ObjectModel.ObservableCollection<StItem>>(value);
                return myList;
            }
            catch (System.Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(string.Format(" Error : {0} - {1} ", ex.Message, ex.InnerException != null ? ex.InnerException.FullMessage() : ""));
                return new System.Collections.ObjectModel.ObservableCollection<StItem>();
            }
        }
        set
        {
            string listValue = System.Text.Json.JsonSerializer.Serialize(value);
            Preferences.Set("FavoritesItemsKey", listValue);
        }
    }
    public static StClient Client
    {
        get
        {
            try
            {
                string value = Preferences.Get("ClientKey", string.Empty);
                if (!string.IsNullOrEmpty(value))
                {
                    return System.Text.Json.JsonSerializer.Deserialize<StClient>(value);
                }
                else
                {
                    return null;
                }
            }
            catch (System.Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(string.Format(" Error : {0} - {1} ", ex.Message, ex.InnerException != null ? ex.InnerException.FullMessage() : ""));
                return null;
            }
        }
        set
        {
            Preferences.Set("ClientKey", System.Text.Json.JsonSerializer.Serialize(value));
        }
    }

    public static void SetAppLanguage()
    {
        try
        {
            if (Settings.Language == "ar")
            {
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("ar");
                Settings.Language = "ar";
            }
            else
            {
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en");
                Settings.Language = "en";
            }
            Thread.CurrentThread.CurrentUICulture.NumberFormat = new System.Globalization.CultureInfo("en").NumberFormat;
            Thread.CurrentThread.CurrentUICulture.DateTimeFormat = new System.Globalization.CultureInfo("en").DateTimeFormat;
            /*(DependencyService.Get<Services.ILocalize>()).SetLocale(Settings.Language);
            if (DeviceInfo.Current.Platform == DevicePlatform.iOS)
            {
                if (Settings.Language == "ar")
                {
                    (DependencyService.Get<Services.IIOSFlowDirection>()).SetLayoutRTL();
                }
                else
                {
                    (DependencyService.Get<Services.IIOSFlowDirection>()).SetLayoutLTR();
                }
            }
            var page = (NavigationPage)((Views.Public.MenuPage)((NavigationPage)App.Current.MainPage).CurrentPage).Detail;
            page.Title = "";
            page.CurrentPage.Title = "";*/
            //App.Current.MainPage = new MainPage();
            App.OpenMainPage();
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(string.Format(" Error : {0} - {1} ", ex.Message, ex.InnerException != null ? ex.InnerException.FullMessage() : ""));
        }
    }
    #endregion
}
