using WytSky.Mobile.Maui.Skoola.Models;
using WytSky.Mobile.Maui.Skoola.ViewModels;

namespace WytSky.Mobile.Maui.Skoola.Views.Staff;

public partial class StaffPage : BaseContentPage
{
    StaffVM StaffVM = new();
    public StaffPage(CentersModel centerIdModel)
    {
        InitializeComponent();
        BindingContext = StaffVM;
        Title = App.IsArabic ? centerIdModel.CenterName : centerIdModel.CenterNameEn;
        StaffVM.CenterID = centerIdModel.CenterID.ToString();
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        if (!string.IsNullOrEmpty(StaffVM.CenterID))
        {
            await StaffVM.GetStaff();
        }
    }

}
