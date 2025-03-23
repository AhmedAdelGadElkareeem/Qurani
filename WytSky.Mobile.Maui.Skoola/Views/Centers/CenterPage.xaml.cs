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
        CenterVM.CountryName = complex.CountryName;
        CenterVM.ComplexNamee = complex.ComplexName;
        CenterVM.ComplexRegionName = complex.RegionName;
        BindingContext = CenterVM;
        
    }
    public CenterPage()
    {
        InitializeComponent();
        CenterVM = new CenterVM();
        CenterVM.FromMainPage = true;
        BindingContext = CenterVM;
    }
    
    protected async override void OnAppearing()
    {
        base.OnAppearing();
        await CenterVM.GetCenters();
    }
}
