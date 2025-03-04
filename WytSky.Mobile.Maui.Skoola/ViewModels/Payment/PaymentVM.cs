using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WytSky.Mobile.Maui.Skoola.AppResources;
using WytSky.Mobile.Maui.Skoola.Dtos.Used;
using WytSky.Mobile.Maui.Skoola.Views.Payment;
using WytSky.Mobile.Maui.Skoola.Views.Public;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WytSky.Mobile.Maui.Skoola.ViewModels.Payment
{
    public partial class PaymentVM : BaseViewModel
    {
        [ObservableProperty]
        public List<StPayment> payments;

        [ObservableProperty]
        public string cardNumber;
        [ObservableProperty]
        public string holderName;
        [ObservableProperty]
        public string cVV;
        [ObservableProperty]
        public string expiration;

        public PaymentVM()
        {
            Payments = new List<StPayment>()
            {
                new StPayment(){Image="paypal",Name="Paypal",IsConnected = true},
                new StPayment(){Image="apple",Name="Apple pay",IsConnected = false},
                new StPayment(){Image="google",Name="Google pay", IsConnected = true},
                new StPayment(){Image="mastercard",Name="**** **** **** 5245", IsConnected = true},
            };
        }

        [RelayCommand]
        public void OpenCreditCardPage()
        {
            NavigateToPage.OpenPage(new AddCreditCardPage());
        }

        [RelayCommand]
        public void AddNewCard()
        {
            NavigateToPage.OpenPage(new SuccessPage(SharedResources.Text_CardAddedSuccessfully));
        }
    }
}
