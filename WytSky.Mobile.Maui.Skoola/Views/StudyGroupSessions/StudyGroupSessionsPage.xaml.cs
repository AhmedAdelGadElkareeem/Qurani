using WytSky.Mobile.Maui.Skoola.Helpers;
using WytSky.Mobile.Maui.Skoola.Models;
using WytSky.Mobile.Maui.Skoola.ViewModels.StudyGroupSession;

namespace WytSky.Mobile.Maui.Skoola.Views.StudyGroupSessions;

public partial class StudyGroupSessionsPage : ContentPage
{
    private readonly StudyGroupSessionsVM _studyGroupSessionsVM = new StudyGroupSessionsVM();
    private readonly Dictionary<Button, bool> _buttonStates = new(); // Dictionary to track button states

    public StudyGroupSessionsPage(ScheduleModel schedule)
	{
        InitializeComponent();
        BindingContext = _studyGroupSessionsVM;
        _studyGroupSessionsVM.SessionSchedule = schedule;
        _studyGroupSessionsVM.ComplexNamee = schedule.GroupCenterComplexName;
        _studyGroupSessionsVM.CenterName = schedule.GroupCenterName;
        _studyGroupSessionsVM.GroupName = schedule.GroupName;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        if (_studyGroupSessionsVM != null)
        {
            await _studyGroupSessionsVM.GetSessions();
            await _studyGroupSessionsVM.GetAllStudents();
            await _studyGroupSessionsVM.GetGroupAttendance();
        }
        else
        {
            Toast.ShowToastError("Error: ViewModel is null in StudyGroupSessionsPage.");
        }
    }
   

}