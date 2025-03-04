using WytSky.Mobile.Maui.Skoola.Helpers;
using WytSky.Mobile.Maui.Skoola.ViewModels;

namespace WytSky.Mobile.Maui.Skoola.CustomControl;

public partial class BaseContentView : ContentView
{
	public BaseContentView()
	{
		InitializeComponent();
        // BindingContext = new BaseViewModel();
        this.FlowDirection = Settings.Language == "ar" ?
                                 FlowDirection.RightToLeft : FlowDirection.LeftToRight;
    }
}