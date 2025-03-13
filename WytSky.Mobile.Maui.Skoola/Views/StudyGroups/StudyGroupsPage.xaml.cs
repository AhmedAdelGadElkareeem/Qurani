using WytSky.Mobile.Maui.Skoola.Models;
using WytSky.Mobile.Maui.Skoola.ViewModels.StudyGroups;

namespace WytSky.Mobile.Maui.Skoola.Views.StudyGroups;

public partial class StudyGroupsPage : BaseContentPage
{
    StudyGroupVM studyGroupVM = new();
    public StudyGroupsPage(string name)
    {
        InitializeComponent();
        //Title = name;
        BindingContext = studyGroupVM;
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        await studyGroupVM.GetStudyGroupsByStaffIdOrCenterId();
    }
}