using WytSky.Mobile.Maui.Skoola.Helpers;
using WytSky.Mobile.Maui.Skoola.Models;
using WytSky.Mobile.Maui.Skoola.ViewModels.Students;
using WytSky.Mobile.Maui.Skoola.ViewModels.StudyGroupSession;

namespace WytSky.Mobile.Maui.Skoola.Views.StudyGroupStudentList;

public partial class StudyGroupSessionDetailsPage : ContentPage
{
    StudyGroupStudentListVM StudyGroupSessionDetails = new StudyGroupStudentListVM();
    public StudyGroupSessionDetailsPage(SessionModel model)
	{
        InitializeComponent();
        BindingContext = StudyGroupSessionDetails;
        StudyGroupSessionDetails.ComplexNamee = model.GroupComplexName;
        StudyGroupSessionDetails.CenterName = model.GroupCenterName;
        StudyGroupSessionDetails.GroupName = model.GroupName;
        Settings.StudyGroupId = model.GroupID.ToString();
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await StudyGroupSessionDetails.GetStudentAttendance();
    }
}
