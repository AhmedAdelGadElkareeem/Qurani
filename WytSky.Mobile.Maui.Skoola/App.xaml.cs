using WytSky.Mobile.Maui.Skoola.Dtos;
using WytSky.Mobile.Maui.Skoola.Helpers;
using WytSky.Mobile.Maui.Skoola.Services.Implementation;
using WytSky.Mobile.Maui.Skoola.ViewModels;
using WytSky.Mobile.Maui.Skoola.Views;
using WytSky.Mobile.Maui.Skoola.Views.User;
using System.Collections.ObjectModel;

namespace WytSky.Mobile.Maui.Skoola
{
    public partial class App : Application
    {
        public static ObservableCollection<StItem> CartItems = new ObservableCollection<StItem>();
        public static HomeVM HomeVM = new HomeVM();
        public static ShowPopupService ShowPopupService = ShowPopupService.Instance;

        public App()
        {
            try
            {
                InitializeComponent();
                Application.Current.UserAppTheme = AppTheme.Light;
                if (Settings.IsLogedin)
                {
                    App.Current.MainPage = new NavigationPage(new HomePage());
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

        public async static Task ShowConfirmationDeleteOrSendCachedCartItemsPopup()
        {
            if (Settings.CartItems.Count > 0)
            {
                var result = await App.Current.MainPage
                                    .DisplayAlert(AppResources.SharedResources.Text_Alert,
                                    AppResources.SharedResources.Text_YouHaveCartItems,
                                    AppResources.SharedResources.Text_Yes,
                                    AppResources.SharedResources.Text_No);
                if (result)
                {
                    App.CartItems = Settings.CartItems;
                    // used to show stack prices in cart page
                    await NavigateToPage.OpenPage(new CartPage());
                }
                else
                {
                    Settings.CartItems = new ObservableCollection<StItem>();
                    App.CartItems = new ObservableCollection<StItem>();
                    Toast.ShowCustomToast(AppResources.SharedResources.Text_CartItemsDeleted);
                }
            }
        }
    }
}
