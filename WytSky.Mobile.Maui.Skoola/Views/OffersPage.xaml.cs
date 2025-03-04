using WytSky.Mobile.Maui.Skoola.ViewModels;

namespace WytSky.Mobile.Maui.Skoola.Views;

public partial class OffersPage : BaseContentPage
{
    OfferVM offerVM = new OfferVM();
    public OffersPage()
    {
        InitializeComponent();
        BindingContext = offerVM;
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        await offerVM.GetAllOffers();
    }
}