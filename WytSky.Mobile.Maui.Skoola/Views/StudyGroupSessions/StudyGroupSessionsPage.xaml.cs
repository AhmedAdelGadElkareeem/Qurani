using System.Diagnostics;
using WytSky.Mobile.Maui.Skoola.Helpers;
using WytSky.Mobile.Maui.Skoola.Models;
using WytSky.Mobile.Maui.Skoola.ViewModels.StudyGroupSession;

namespace WytSky.Mobile.Maui.Skoola.Views.StudyGroupSessions;

public partial class StudyGroupSessionsPage : ContentPage
{
    StudyGroupSessionsVM _studyGroupSessionsVM = new StudyGroupSessionsVM();
    private readonly Dictionary<Button, bool> _buttonStates = new(); // Dictionary to track button states

    public StudyGroupSessionsPage(ScheduleModel schedule)
	{
        InitializeComponent();
        Debug.WriteLine("Start StudyGroupSessionsPage Constractor");

        BindingContext = _studyGroupSessionsVM;
        _studyGroupSessionsVM.SessionSchedule = schedule;
        _studyGroupSessionsVM.ComplexNamee = schedule.GroupCenterComplexName;
        _studyGroupSessionsVM.CenterName = schedule.GroupCenterName;
        _studyGroupSessionsVM.GroupName = schedule.GroupName;
        Debug.WriteLine("End of Constractor");
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        if (_studyGroupSessionsVM != null)
        {
            //await _studyGroupSessionsVM.GetSessions();
            _studyGroupSessionsVM.AllStudents = false;
            await _studyGroupSessionsVM.GetAllStudents();
            await _studyGroupSessionsVM.GetGroupAttendance();
        }
        else
        {
            Toast.ShowToastError("Error: ViewModel is null in StudyGroupSessionsPage.");
        }
    }
    private void OnAttendanceButtonClicked(object sender, EventArgs e)
    {
        if (sender is Button button)
        {
            if (!_buttonStates.ContainsKey(button))
            {
                _buttonStates[button] = false; // Initialize state if not present
            }

            _buttonStates[button] = !_buttonStates[button];

            // Change button appearance based on state
            button.BackgroundColor = _buttonStates[button] ? Colors.Gray : Colors.White;
            button.Text = _buttonStates[button] ? "Present" : "Mark Attendance"; // Update text
        }
    }

}