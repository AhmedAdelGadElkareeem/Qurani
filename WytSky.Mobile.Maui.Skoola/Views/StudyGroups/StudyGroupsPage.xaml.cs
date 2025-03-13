using WytSky.Mobile.Maui.Skoola.Models;
using WytSky.Mobile.Maui.Skoola.ViewModels.StudyGroups;

namespace WytSky.Mobile.Maui.Skoola.Views.StudyGroups;

public partial class StudyGroupsPage : BaseContentPage
{
    StudyGroupVM studyGroupVM = new();
    public StudyGroupsPage(int? id)
    {
        InitializeComponent();
        BindingContext = studyGroupVM;
        studyGroupVM.TeacherID = id;
        studyGroupVM.FromCenter = false;
    }
    public StudyGroupsPage()
    {
        InitializeComponent();
        BindingContext = studyGroupVM;

    }
    protected async override void OnAppearing()
    {
        base.OnAppearing();
        await studyGroupVM.GetStudyGroupsByStaffIdOrCenterId();
    }
}