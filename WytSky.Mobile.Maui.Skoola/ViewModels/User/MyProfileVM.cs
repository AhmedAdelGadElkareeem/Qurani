using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WytSky.Mobile.Maui.Skoola.Helpers;
using System.Collections.ObjectModel;
using WytSky.Mobile.Maui.Skoola.Dtos.Used;
using CommunityToolkit.Mvvm.Input;
using WytSky.Mobile.Maui.Skoola.Views.User;
using WytSky.Mobile.Maui.Skoola.Views.Notification;
using WytSky.Mobile.Maui.Skoola.Views.Public;
using CommunityToolkit.Maui.Alerts;
using WytSky.Mobile.Maui.Skoola.AppResources;
using WytSky.Mobile.Maui.Skoola.Views.Payment;
using System.Globalization;

namespace WytSky.Mobile.Maui.Skoola.ViewModels.User
{
    public partial class MyProfileVM : BaseViewModel
    {
        [ObservableProperty]
        public string name;

        [ObservableProperty]
        public string email;

        [ObservableProperty]
        public string modeTitle;

        [ObservableProperty]
        public ObservableCollection<StInterest> interests;

        public MyProfileVM()
        {
            Name = "Alani Kimathi";
            Email = "alani.kimathi@gmail.com";

            if (Application.Current.UserAppTheme == AppTheme.Light ||
                Application.Current.UserAppTheme == AppTheme.Unspecified)
            {
                ModeTitle = "Light Mode";
            }
            else
            {
                ModeTitle = SharedResources.Text_DarkMode;
            }

            Interests = new ObservableCollection<StInterest>()
            {
                new StInterest(){Name="Introduction to Programming"},
                new StInterest(){Name="HTML"},
                new StInterest(){Name="Data Science"},
                new StInterest(){Name="Machine Learning"},
                new StInterest(){Name="Python"},
                new StInterest(){Name="Introduction to Programming"},
                new StInterest(){Name="HTML"},
                new StInterest(){Name="Data Science"},
                new StInterest(){Name="Machine Learning"},
                new StInterest(){Name="Python"},
                new StInterest(){Name="Introduction to Programming"},
                new StInterest(){Name="HTML"},
                new StInterest(){Name="Data Science"},
                new StInterest(){Name="Machine Learning"},
                new StInterest(){Name="Python"},
                new StInterest(){Name="Introduction to Programming"},
                new StInterest(){Name="HTML"},
                new StInterest(){Name="Data Science"},
                new StInterest(){Name="Machine Learning"},
                new StInterest(){Name="Python"},
            };
        }

        [RelayCommand]
        public async Task OpenEditProfile()
        {
            await NavigateToPage.OpenPage(new EditProfilePage());
        }

        [RelayCommand]
        public async Task OpenNotificationSettingsPage()
        {
            await NavigateToPage.OpenPage(new NotificationSettingsPage());
        }

        [RelayCommand]
        public async Task OpenSecurityPage()
        {
            await NavigateToPage.OpenPage(new SecurityPage());
        }

        [RelayCommand]
        public void OpenLanguagePage()
        {
            try
            {
                // await NavigateToPage.OpenPage(new LanguagePage());

                CultureInfo culture;
                if (Settings.Language == "en")
                {
                    Settings.Language = "ar";
                    culture = new CultureInfo("ar-AE");
                }
                else
                {
                    Settings.Language = "en";
                    culture = new CultureInfo("en-US");
                }
                Thread.CurrentThread.CurrentCulture = culture;
                Thread.CurrentThread.CurrentUICulture = culture;
                SharedResources.Culture = culture;
                Thread.CurrentThread.CurrentUICulture.NumberFormat = new CultureInfo("en").NumberFormat;
                Thread.CurrentThread.CurrentUICulture.DateTimeFormat = new CultureInfo("en").DateTimeFormat;
                App.Current.MainPage = new MainPage();
            }
            catch (Exception ex)
            {
                ExtensionLogMethods.LogExtension(ex, "", "NotificationSettingsCard", "RadioButton_CheckedChanged");
            }
        }

        [RelayCommand]
        public void OpenChatPage()
        {
            Helpers.Toast.ShowCustomToast("Comming soon ....");
        }


        [RelayCommand]
        public void ChangeDarkMode()
        {
            if (Application.Current.UserAppTheme == AppTheme.Light ||
                Application.Current.UserAppTheme == AppTheme.Unspecified)
            {
                Application.Current.UserAppTheme = AppTheme.Dark;
                ModeTitle = "Light";
            }
            else
            {
                Application.Current.UserAppTheme = AppTheme.Light;
                ModeTitle = SharedResources.Text_DarkMode;
            }

            App.Current.MainPage = new MainPage();
        }

        [RelayCommand]
        public async Task OpenPaymentPage()
        {
            await NavigateToPage.OpenPage(new PaymentPage());
        }

        [RelayCommand]
        public async Task OpenPrivacyPolicyPage()
        {
            await NavigateToPage.OpenPage(new PrivacyPolicyPage());
        }

        [RelayCommand]
        public async Task OpenHelpCenterPage()
        {
            await NavigateToPage.OpenPage(new HelpCenterPage());
        }

        [RelayCommand]
        public async Task OpenInviteFreindsPage()
        {
            await NavigateToPage.OpenPage(new InviteFriendsPage());
        }

        [RelayCommand]
        public void LogoutExcute()
        {
            Logout();
        }
    }
}
