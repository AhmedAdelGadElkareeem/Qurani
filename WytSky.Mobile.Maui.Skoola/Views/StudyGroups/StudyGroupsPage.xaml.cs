    using WytSky.Mobile.Maui.Skoola.Models;
using WytSky.Mobile.Maui.Skoola.ViewModels.StudyGroups;

namespace WytSky.Mobile.Maui.Skoola.Views.StudyGroups;

public partial class StudyGroupsPage : BaseContentPage
{
    StudyGroupVM studyGroupVM = new StudyGroupVM();
    public StudyGroupsPage(StaffModel staffModel)
    {
        InitializeComponent();
        BindingContext = studyGroupVM;
        studyGroupVM.TeacherID = staffModel.StaffID.ToString();
        studyGroupVM.CenterID = staffModel.CenterID.ToString();
        studyGroupVM.ComplexNamee = staffModel.CenterComplexName;
        studyGroupVM.CenterName = staffModel.CenterName;
        studyGroupVM.ComplexRegionName = staffModel.CenterComplexRegionName;
        studyGroupVM.FromCenter = false;
    }
    public StudyGroupsPage(CentersModel model)
    {
        InitializeComponent();
        BindingContext = studyGroupVM;
        //studyGroupVM.TeacherID = id;
        //studyGroupVM.GetCenters();
        studyGroupVM.CountryName = model.ComplexRegionCountryName;
        studyGroupVM.ComplexNamee = model.ComplexName;
        studyGroupVM.CenterName = model.CenterName;
        studyGroupVM.ComplexRegionName = model.ComplexRegionName;
        studyGroupVM.FromCenter = true;

    }
    protected async override void OnAppearing()
    {
        base.OnAppearing();
        await studyGroupVM.GetStudyGroupsByStaffIdOrCenterId();
    }
}