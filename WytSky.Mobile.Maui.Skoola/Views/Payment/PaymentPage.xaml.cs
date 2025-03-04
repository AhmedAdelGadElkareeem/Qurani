using WytSky.Mobile.Maui.Skoola.ViewModels.Payment;

namespace WytSky.Mobile.Maui.Skoola.Views.Payment;

public partial class PaymentPage : BaseContentPage
{
	public PaymentPage()
	{
		InitializeComponent();
		BindingContext = new PaymentVM();
	}
}