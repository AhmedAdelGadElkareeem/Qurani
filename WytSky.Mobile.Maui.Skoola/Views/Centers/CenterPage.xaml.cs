using System.Numerics;
using WytSky.Mobile.Maui.Skoola.Models;
using WytSky.Mobile.Maui.Skoola.ViewModels;

namespace WytSky.Mobile.Maui.Skoola.Views.Centers;

public partial class CenterPage : BaseContentPage
{
    private CenterVM CenterVM ;

    public CenterPage(ComplexModel complex)
    {
        InitializeComponent();
        CenterVM = new CenterVM();
        //Title = complex.ComplexName;
        BindingContext = CenterVM;
        CenterVM.CountryName = complex.CountryName;
        CenterVM.ComplexNamee = complex.ComplexName;
        CenterVM.ComplexRegionName = complex.RegionName;
    }
    public CenterPage()
    {
        CenterVM = new CenterVM();
        BindingContext = CenterVM;
    }
    
    protected async override void OnAppearing()
    {
        base.OnAppearing();
        await CenterVM.GetCenters();
    }
}
