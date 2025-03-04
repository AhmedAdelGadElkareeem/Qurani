using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WytSky.Mobile.Maui.Skoola.Views.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WytSky.Mobile.Maui.Skoola.ViewModels.User
{
    partial class ForgetPasswordVM : BaseViewModel
    {
        #region Properties
        [ObservableProperty]
        public bool forgetPasswordVisibility;

        [ObservableProperty]
        public bool resetPasswordVisibility;

        [ObservableProperty]
        public bool passwordResetSuccessfullyVisibility;

        [ObservableProperty]
        public bool isFromLogin; // للتفرقه بين نسيان كلمة المرور والتحقق من الحساب ف الديزاين

        [ObservableProperty]
        public bool accountVerifiedSuccessfully; // للتفرقه بين نسيان كلمة المرور والتحقق من الحساب ف الديزاين
        #endregion

        public ForgetPasswordVM()
        {
            ForgetPasswordVisibility = true;
        }

        [RelayCommand]
        public void Next()
        {
            ForgetPasswordVisibility = false;

            if (IsFromLogin)
            {
                ResetPasswordVisibility = true;
            }
            else
            {
                AccountVerifiedSuccessfully = true;
            }
        }

        [RelayCommand]
        public async Task NextAccountVerified()
        {
            await NavigateToPage.OpenPage(new InterestsPage());
        }

        [RelayCommand]
        public void Resend()
        {

        }

        [RelayCommand]
        public void ChangePassword()
        {
            PasswordResetSuccessfullyVisibility = true;
            ForgetPasswordVisibility = false;
            ResetPasswordVisibility = false;
        }

        [RelayCommand]
        public void SignIn()
        {
            App.Current.MainPage = new SignInSignUpPage();
        }
    }
}
