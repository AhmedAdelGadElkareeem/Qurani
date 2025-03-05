using WytSky.Mobile.Maui.Skoola.Models;
using WytSky.Mobile.Maui.Skoola.ViewModels;

namespace WytSky.Mobile.Maui.Skoola.Views.Centers;

public partial class CenterPage : BaseContentPage
{
    private CenterVM CenterVM;

    public CenterPage(ComplexModel complex)
    {
        InitializeComponent();
        CenterVM = new CenterVM();
        Title = complex.ComplexName;
        BindingContext = CenterVM;
    }
    
    protected async override void OnAppearing()
    {
        base.OnAppearing();
        await CenterVM.GetCenters();
    }
}
