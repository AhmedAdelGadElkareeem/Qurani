using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.ObjectModel;
using WytSky.Mobile.Maui.Skoola.AppResources;
using WytSky.Mobile.Maui.Skoola.Dtos;
using WytSky.Mobile.Maui.Skoola.Helpers;

namespace WytSky.Mobile.Maui.Skoola.ViewModels
{
    public partial class OfferVM : BaseViewModel
    {
        [ObservableProperty]
        public double totalPrice;

        [ObservableProperty]
        public double subTotal;

        [ObservableProperty]
        public ObservableCollection<StOffer> offers;

        public async Task GetAllOffers()
        {
            try
            {
                if (HasInternetConnection())
                {
                    var res = await APIs.ServiceOffer.GetAllOffers();
                    if (res != null)
                    {
                        Offers = res;
                    }
                    else
                    {
                        // TempData();
                    }
                }
                else
                {
                    Toast.ShowCustomToast(SharedResources.Msg_NoInternetConnection);
                }
            }
            catch (Exception ex)
            {
                ExtensionLogMethods.LogExtension(ex,"", "OfferVM", "GetAllOffers");
                // TempData();
            }
        }

        public void TempData()
        {
            Offers = new ObservableCollection<StOffer>()
                        {
                            new StOffer(){NameEn="Name",DescriptionEn="Description",PriceAfter=16.56,PriceBefore=72.63},
                            new StOffer(){NameEn="Name",DescriptionEn="Description",PriceAfter=16.56,PriceBefore=72.63},
                            new StOffer(){NameEn="Name",DescriptionEn="Description",PriceAfter=16.56,PriceBefore=72.63},
                            new StOffer(){NameEn="Name",DescriptionEn="Description",PriceAfter=16.56,PriceBefore=72.63},
                            new StOffer(){NameEn="Name",DescriptionEn="Description",PriceAfter=16.56,PriceBefore=72.63},
                            new StOffer(){NameEn="Name",DescriptionEn="Description",PriceAfter=16.56,PriceBefore=72.63},
                            new StOffer(){NameEn="Name",DescriptionEn="Description",PriceAfter=16.56,PriceBefore=72.63},
                            new StOffer(){NameEn="Name",DescriptionEn="Description",PriceAfter=16.56,PriceBefore=72.63},
                            new StOffer(){NameEn="Name",DescriptionEn="Description",PriceAfter=16.56,PriceBefore=72.63},
                            new StOffer(){NameEn="Name",DescriptionEn="Description",PriceAfter=16.56,PriceBefore=72.63},
                            new StOffer(){NameEn="Name",DescriptionEn="Description",PriceAfter=16.56,PriceBefore=72.63},
                            new StOffer(){NameEn="Name",DescriptionEn="Description",PriceAfter=16.56,PriceBefore=72.63},
                            new StOffer(){NameEn="Name",DescriptionEn="Description",PriceAfter=16.56,PriceBefore=72.63},
                            new StOffer(){NameEn="Name",DescriptionEn="Description",PriceAfter=16.56,PriceBefore=72.63},
                            new StOffer(){NameEn="Name",DescriptionEn="Description",PriceAfter=16.56,PriceBefore=72.63},
                            new StOffer(){NameEn="Name",DescriptionEn="Description",PriceAfter=16.56,PriceBefore=72.63},
                            new StOffer(){NameEn="Name",DescriptionEn="Description",PriceAfter=16.56,PriceBefore=72.63},
                            new StOffer(){NameEn="Name",DescriptionEn="Description",PriceAfter=16.56,PriceBefore=72.63},
                            new StOffer(){NameEn="Name",DescriptionEn="Description",PriceAfter=16.56,PriceBefore=72.63},
                            new StOffer(){NameEn="Name",DescriptionEn="Description",PriceAfter=16.56,PriceBefore=72.63},
                        };
        }

        [RelayCommand]
        private void IncreaseQuantity(object obj)
        {
            var item = (StItem)obj;
            item.Quantity++;
            item.IsSelected = true;
            item.ItemTotalPrice = item.PriceBefore * item.Quantity;

            if (App.CartItems.Count == 0)
            {
                App.CartItems.Add(item);
            }
            else
            {
                if (App.CartItems.Any(x => x.ItemID == item.ItemID))
                    App.CartItems.FirstOrDefault(x => x.ItemID == item.ItemID).Quantity = item.Quantity;
                else
                    App.CartItems.Add(item);
            }

            CalculatePrices();
        }

        [RelayCommand]
        private void DecreaseQuantity(object obj)
        {
            var item = (StItem)obj;
            item.Quantity--;
            item.ItemTotalPrice = (double)item.PriceBefore * item.Quantity;

            if (item.Quantity <= 0)
            {
                item.Quantity = 0;
                item.IsSelected = false;
                App.CartItems.Remove(item);
            }

            CalculatePrices();
        }

        public void CalculatePrices()
        {
            try
            {
                TotalPrice = 0;
                SubTotal = 0;

                // used in cart and checkout pages
                if (App.CartItems.Count > 0)
                {
                    foreach (var item in App.CartItems)
                    {
                        SubTotal += item.ItemTotalPrice;
                    }

                    CartDetailsVisibility = true;
                }
                else
                {
                    CartDetailsVisibility = false;
                }

                TotalPrice = SubTotal;
            }
            catch (Exception ex)
            {
                string er = ex.Message;
            }
        }
    }
}
