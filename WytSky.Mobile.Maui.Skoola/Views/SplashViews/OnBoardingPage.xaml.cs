using WytSky.Mobile.Maui.Skoola.ViewModels;

namespace WytSky.Mobile.Maui.Skoola.Views.SplashViews;

public partial class OnBoardingPage : BaseContentPage
{
	public OnBoardingPage()
	{
		InitializeComponent();
		BindingContext = new CarouselVM();
    }
}