using WytSky.Mobile.Maui.Skoola.ViewModels.Payment;

namespace WytSky.Mobile.Maui.Skoola.Views.Payment;

public partial class AddCreditCardPage : BaseContentPage
{
	public AddCreditCardPage()
	{
		InitializeComponent();
		BindingContext = new PaymentVM();
	}
}