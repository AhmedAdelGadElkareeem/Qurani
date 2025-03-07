using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Globalization;
using Mopups.Pages;
using Mopups.Services;
using WytSky.Mobile.Maui.Skoola.AppResources;
using WytSky.Mobile.Maui.Skoola.Helpers;
using WytSky.Mobile.Maui.Skoola.Views;
using WytSky.Mobile.Maui.Skoola.Views.User;
using WytSky.Mobile.Maui.Skoola.Models;
using System.Collections.ObjectModel;
using WytSky.Mobile.Maui.Skoola.Utilities;
using WytSky.Mobile.Maui.Skoola.Views.Centers;
using WytSky.Mobile.Maui.Skoola.Views.Complexes;
using WytSky.Mobile.Maui.Skoola.Views.Zekr;
using WytSky.Mobile.Maui.Skoola.Views.Tawhed;

namespace WytSky.Mobile.Maui.Skoola.ViewModels
{
    public partial class BaseViewModel : ObservableObject
    {
        #region Properties
        [ObservableProperty]
        public string lang;

        [ObservableProperty]
        private bool cartDetailsVisibility = false;

        [ObservableProperty]
        public bool isRunning;

        [ObservableProperty]
        public bool canExecute = true;

        [ObservableProperty]
        public string currentLang = Settings.Language;

        [ObservableProperty]
        private FlowDirection currentFlowDirection = FlowDirection.LeftToRight;
        [ObservableProperty]
        public bool isEnglish;

        [ObservableProperty]
        public string languageTitle;

        [ObservableProperty]
        ObservableCollection<CountryModel> countries;

        [ObservableProperty]
        ObservableCollection<RegionModel> regions;
        #endregion


        #region Constractor
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
        #endregion

        #region Methods
        private void UpdateFlowDirection()
        {
            if (Settings.Language == "ar")
            {
                CurrentFlowDirection = FlowDirection.RightToLeft;
            }
            else
            {
                CurrentFlowDirection = FlowDirection.LeftToRight;
            }
        }
        [RelayCommand(CanExecute = nameof(CanExecute))]
        private async Task ChangeLanguage(string lang)
        {
            try
            {
                // Save the current page route
                var currentRoute = Shell.Current.CurrentState.Location.ToString();

                if (lang == "ar")
                {
                    AppSettings.NewSetAppLanguage("en");
                    CurrentLang = "en";
                }
                else
                {
                    AppSettings.NewSetAppLanguage("ar");
                    CurrentLang = "ar";
                }

                if (Application.Current.MainPage is AppShell shell)
                {
                    shell.SetFlyoutState(true); // Set FlyoutIsPresented to true
                }

                // Notify the application to update the UI
                Application.Current.MainPage = new AppShell();

                // Navigate to the previously saved route
                await Shell.Current.GoToAsync(currentRoute);

                UpdateFlowDirection();
            }
            catch (Exception ex)
            {
                ExtensionLogMethods.LogExtension(ex, "", "BaseViewModel", "ChangeLanguage");
            }
        }

        [RelayCommand(CanExecute = nameof(CanExecute))]
        private async void ChangeLanguages(object obj)
        {
            try
            {
                if (obj.ToString() == "ar")
                {
                    AppSettings.SetAppLanguage("ar");
                    CurrentLang = Settings.Language;
                }
                else
                {
                    AppSettings.SetAppLanguage("en");
                    CurrentLang = Settings.Language;
                }
            }
            catch (Exception ex)
            {
                ExtensionLogMethods.LogExtension(ex, "", "LoginVM", "ChangeLanguage");
            }
        }
        public bool HasInternetConnection()
        {
            try
            {

                NetworkAccess accessType = Connectivity.Current.NetworkAccess;
                return accessType == NetworkAccess.Internet;
            }
            catch (Exception ex)
            {
                ExtensionLogMethods.LogExtension(ex, null, "", "");
                return false;
            }
        }
        public void SetUserNameAndPassword()
        {
            if (!Settings.IsLogedin)
            {
                Settings.Password = "sky365@365";
                Settings.UserName = "sky365";
            }
        }

        public static void OpenMainPage()
        {
            App.Current.MainPage = new MainPage();
        }
       
        //public void Logout()
        //{
        //    try
        //    {
        //        Settings.IsLogedin = false;
        //        Settings.ClientId = long.MinValue;
        //        Settings.ClientName = "";
        //        Settings.ClientEmail = "";
        //        Settings.ClientPhone = "";
        //        Settings.Client = null;
        //        Settings.Password = "";
        //        Settings.AuthoToken = "";
        //        if (!string.IsNullOrEmpty(Settings.SocialID))
        //        {
        //            Settings.UserName = "";
        //        }
        //        Settings.SocialID = "";
        //        App.Current.MainPage = new NavigationPage(new SignInSignUpPage())
        //        {
        //            FlowDirection = Settings.Language == "ar" ? FlowDirection.RightToLeft : FlowDirection.LeftToRight
        //        };
        //    }
        //    catch (System.Exception ex)
        //    {
        //        System.Diagnostics.Debug.WriteLine($"Error : {ex.Message}");
        //    }
        //}

        [RelayCommand(CanExecute = nameof(CanExecute))]
        public async Task Logout()
        {
            bool confirm = await Shell.Current.DisplayAlert(SharedResources.Text_LogOut,
                                                                          SharedResources.Msg_CloseApp,
                                                                          SharedResources.Text_Yes,
                                                                          SharedResources.Text_No);
            if (confirm)
            {
                App.Logout();
            }
        }
        public async Task OpenPushAsyncPage(Page page)
        {
            try
            {
                await App.Current.MainPage.Navigation.PushAsync(page);
            }
            catch (Exception e)
            {
                string er = e.Message;
            }
        }
        public void ShowPopup(PopupPage popup)
        {
            MopupService.Instance.PushAsync(popup);
        }
        public void HidePopup()
        {
            if (MopupService.Instance.PopupStack.Count > 0)
                MopupService.Instance.PopAsync();
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
                    culture = new CultureInfo("ar-EG");
                }
                Thread.CurrentThread.CurrentCulture = culture;
                Thread.CurrentThread.CurrentUICulture = culture;
                SharedResources.Culture = culture;
                Thread.CurrentThread.CurrentUICulture.NumberFormat = new CultureInfo("en").NumberFormat;
                Thread.CurrentThread.CurrentUICulture.DateTimeFormat = new CultureInfo("en").DateTimeFormat;
                OpenMainPage();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(string.Format(" Error : {0} - {1} ", ex.Message, ex.InnerException != null ? ex.InnerException.FullMessage() : ""));
            }
        }
        public async Task GetCountries()
        {
            Countries = await APIs.ServiceCountriesRegions.GetCountries();
            await GetRegions(Countries[0].CountryID.Value.ToString());
        }
        public async Task GetRegions(string countryId)
        {
            Regions = await APIs.ServiceCountriesRegions.GetRegions(countryId);
        }

        [RelayCommand]
        private async Task OpenComplexes()
        {
            try
            {
                IsRunning = true;
                await App.Current.MainPage.Navigation.PushModalAsync(new ComplexesPage());
            }
            catch (Exception ex)
            {
                ExtensionLogMethods.LogExtension(ex, null, "BaseViewModel", "OpenComplexes");
            }
            finally
            {
                IsRunning = false;
            }
        }

        [RelayCommand]
        private async Task OpenCenters()
        {
            try
            {
                IsRunning = true;

                await App.Current.MainPage.Navigation.PushModalAsync(new CenterPage());
            }
            catch (Exception ex)
            {
                ExtensionLogMethods.LogExtension(ex, null, "BaseViewModel", "OpenCenters");
            }
            finally
            {
                IsRunning = false;
            }
        }
        [RelayCommand]
        private async Task OpenTawhed()
        {
            try
            {
                IsRunning = true;

                await App.Current.MainPage.Navigation.PushModalAsync(new TawhedPage());
            }
            catch (Exception ex)
            {
                ExtensionLogMethods.LogExtension(ex, null, "BaseViewModel", "OpenTawhed");
            }
            finally
            {
                IsRunning = false;
            }
        }
        [RelayCommand]
        private async Task OpenZekr()
        {
            try
            {
                IsRunning = true;

                await App.Current.MainPage.Navigation.PushModalAsync(new ZekrPage());
            }
            catch (Exception ex)
            {
                ExtensionLogMethods.LogExtension(ex, null, "BaseViewModel", "OpenZekr");
            }
            finally
            {
                IsRunning = false;
            }
        }

        #endregion
    }
}
