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
        Title = App.IsArabic ? centerIdModel.CenterName : centerIdModel.CenterNameEn;
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        await StaffVM.GetStaff();

    }

}
