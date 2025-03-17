using CommunityToolkit.Mvvm.Input;
using WytSky.Mobile.Maui.Skoola.AppResources;
using WytSky.Mobile.Maui.Skoola.Helpers;
using WytSky.Mobile.Maui.Skoola.ViewModels;
using WytSky.Mobile.Maui.Skoola.Views.Centers;
using WytSky.Mobile.Maui.Skoola.Views.Complexes;

namespace WytSky.Mobile.Maui.Skoola.Views;


public partial class MainPage : BaseContentPage
{

    BaseViewModel BaseModelVM = new BaseViewModel();
    public MainPage()
	{
		InitializeComponent();
		BindingContext = BaseModelVM;
	}
}