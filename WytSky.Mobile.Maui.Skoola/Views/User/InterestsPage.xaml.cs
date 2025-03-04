using WytSky.Mobile.Maui.Skoola.ViewModels.User;

namespace WytSky.Mobile.Maui.Skoola.Views.User;

public partial class InterestsPage : BaseContentPage
{
	public InterestsPage()
	{
		InitializeComponent();
		BindingContext = new InterestsVM();
    }
}