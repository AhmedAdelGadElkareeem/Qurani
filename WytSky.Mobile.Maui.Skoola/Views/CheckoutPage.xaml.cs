namespace WytSky.Mobile.Maui.Skoola.Views;

public partial class CheckoutPage : BaseContentPage
{
    public CheckoutPage()
    {
        InitializeComponent();
        cartItems.ItemsSource = App.CartItems;
    }
    private void Back(object sender, EventArgs e)
    {
        NavigateToPage.ClosePage();
    }
}