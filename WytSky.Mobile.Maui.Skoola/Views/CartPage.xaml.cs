namespace WytSky.Mobile.Maui.Skoola.Views;

public partial class CartPage : BaseContentPage
{
    public CartPage()
    {
        InitializeComponent();
        cartItems.ItemsSource = App.CartItems;
    }

    private async void Back(object sender, EventArgs e)
    {
        await NavigateToPage.ClosePage();
    }
}