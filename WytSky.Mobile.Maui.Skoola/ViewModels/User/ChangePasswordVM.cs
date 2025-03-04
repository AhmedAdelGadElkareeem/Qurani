using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WytSky.Mobile.Maui.Skoola.AppResources;
using WytSky.Mobile.Maui.Skoola.Views.Public;

namespace WytSky.Mobile.Maui.Skoola.ViewModels.User
{
    public partial class ChangePasswordVM : BaseViewModel
    {
        public ChangePasswordVM()
        {

        }

        [ObservableProperty]
        public string currentPassword;

        [ObservableProperty]
        public string newPassword;

        [ObservableProperty]
        public string confirmPassword;

        [RelayCommand]
        public void OnChangePassword()
        {
            NavigateToPage.OpenPage(new SuccessPage(SharedResources.Text_NewPasswordCreatedSuccessfully));
        }
    }
}
