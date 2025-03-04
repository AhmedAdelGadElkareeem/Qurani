using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using WytSky.Mobile.Maui.Skoola.Helpers;
using WytSky.Mobile.Maui.Skoola.Dtos;
using WytSky.Mobile.Maui.Skoola.ViewModels;
using WytSky.Mobile.Maui.Skoola.Views;
using WytSky.Mobile.Maui.Skoola.Views.User;
using WytSky.Mobile.Maui.Skoola.AppResources;
using WytSky.Mobile.Maui.Skoola.Views.Public;

namespace WytSky.Mobile.Maui.Skoola.ViewPublic
{
    public partial class MenuVM : BaseViewModel
    {
        #region Properties
        [ObservableProperty]
        public ObservableCollection<MenuModelItem> menuItems;
        [ObservableProperty]
        public string isVisibleUser;
        [ObservableProperty]
        public string isVisibleVip;
        [ObservableProperty]
        public string iVisibleExpert;
        [ObservableProperty]
        public string isPresented;
        [ObservableProperty]
        public string isVisibleStack;
        [ObservableProperty]
        public string name;
        [ObservableProperty]
        public string clientName;
        [ObservableProperty]
        public string points;
        [ObservableProperty]
        public string email;
        #endregion

        #region Command
        public Command Command_ItemTapped { get; private set; }
        #endregion

        #region Constructor
        public MenuVM()
        {
            try
            {
                SetMune();
                Name = Settings.ClientName;
                Email = Settings.ClientEmail;

            }
            catch (System.Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(string.Format(" Error : {0} - {1} ", ex.Message, ex.InnerException != null ? ex.InnerException.FullMessage() : ""));
            }
        }
        #endregion

        #region Methods
        public void SetMune()
        {
            try
            {
                MenuItems = new ObservableCollection<MenuModelItem>(new[]
                {
                        new MenuModelItem { Icon="menu_my_profile",Title = SharedResources.Text_MyProfile , TargetType = typeof(MyProfilePage)},

                        //new MenuModelItem { Icon="menu_voucher",Title = SharedResources.Text_Voucher , TargetType = typeof(HomePage)},
                        //new MenuModelItem { Icon="menu_address",Title = SharedResources.Text_DeliveryAddress , TargetType = typeof(HomePage)},
                        //new MenuModelItem { Icon="menu_payment",Title = SharedResources.Text_PaymentMethods , TargetType = typeof(HomePage)},
                        //new MenuModelItem { Icon="menu_contact_us",Title = SharedResources.Text_ContactUs , TargetType = typeof(HomePage)},
                        //new MenuModelItem { Icon="menu_settings",Title = SharedResources.Text_Settings , TargetType = typeof(HomePage)},
                        //new MenuModelItem { Icon="menu_helps",Title = SharedResources.Text_HelpsFaqs , TargetType = typeof(HomePage)},

                        new MenuModelItem { Icon="menu_language",Title = SharedResources.Text_Language , CommandE = new Command(ChangeLanguage) ,TargetType = null},
                        new MenuModelItem { Icon="menu_logout",Title = SharedResources.Text_LogOut  , CommandE = new Command(Logout)  , TargetType = null },
                        //new MenuModelItem { Icon="menu_share",Title = SharedResources.Text_ShareApp  , CommandE = new Command(ShareApp)  , TargetType = null },
                });
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(string.Format(" Error : {0} - {1} ", ex.Message, ex.InnerException != null ? ex.InnerException.FullMessage() : ""));
            }
        }
       
        private void CustomerLogin()
        {
            try
            {
                App.Current.MainPage.Navigation.PushAsync(new SignInSignUpPage());
            }
            catch (System.Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error : {ex.Message}");
            }
        }
        
        private async void ShareApp()
        {
            try
            {
                await Share.Default.RequestAsync(new ShareTextRequest
                {
                    Title = "WytSky Store",
                    Text =
                    $"Google Play :{Environment.NewLine}https://play.google.com/store/apps/details {Environment.NewLine}" +
                    $"App Store   :{Environment.NewLine}https://itunes.apple.com ",
                });
            }
            catch (System.Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error : {ex.Message}");
            }
        }
        #endregion
    }
}
