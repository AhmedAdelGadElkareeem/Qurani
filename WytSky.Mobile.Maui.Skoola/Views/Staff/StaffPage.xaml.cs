using WytSky.Mobile.Maui.Skoola.Models;
using WytSky.Mobile.Maui.Skoola.ViewModels;

namespace WytSky.Mobile.Maui.Skoola.Views.Staff;

public partial class StaffPage : BaseContentPage
{
    StaffVM StaffVM = new StaffVM();
    public StaffPage(CentersModel centerIdModel)
    {
        InitializeComponent();
        BindingContext = StaffVM;
        StaffVM.CountryName = centerIdModel.ComplexRegionCountryName;
        StaffVM.ComplexNamee = centerIdModel.ComplexName;
        StaffVM.CenterName = centerIdModel.CenterName;
        StaffVM.ComplexRegionName = centerIdModel.ComplexRegionName;
        //Title = App.IsArabic ? centerIdModel.CenterName : centerIdModel.CenterNameEn;
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        await StaffVM.GetStaff();
        await StaffVM.GetCenters();
        await StaffVM.GetStaffType();

    }

}
