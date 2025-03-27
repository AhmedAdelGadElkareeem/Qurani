using WytSky.Mobile.Maui.Skoola.AppResources;
using WytSky.Mobile.Maui.Skoola.Helpers;
using WytSky.Mobile.Maui.Skoola.Models;
using WytSky.Mobile.Maui.Skoola.ViewModels.Students;
using WytSky.Mobile.Maui.Skoola.ViewModels.StudyGroupSession;

namespace WytSky.Mobile.Maui.Skoola.Views.StudyGroupStudentList;

public partial class StudyGroupSessionDetailsPage : ContentPage
{
    private readonly Dictionary<Button, bool> _buttonStates = new(); // Dictionary to track button states

    StudyGroupStudentListVM StudyGroupSessionDetails = new StudyGroupStudentListVM();
    public StudyGroupSessionDetailsPage(SessionModel model)
	{
        InitializeComponent();
        BindingContext = StudyGroupSessionDetails;
        StudyGroupSessionDetails.ComplexNamee = model.GroupComplexName;
        StudyGroupSessionDetails.CenterName = model.GroupCenterName;
        StudyGroupSessionDetails.GroupName = model.GroupName;
        Settings.StudyGroupId = model.GroupID.ToString();
        StudyGroupSessionDetails.AllStudents = true;
    }
    public StudyGroupSessionDetailsPage(ScheduleModel model)
    {
        InitializeComponent();
        BindingContext = StudyGroupSessionDetails;
        StudyGroupSessionDetails.ComplexNamee = model.GroupCenterComplexName;
        StudyGroupSessionDetails.CenterName = model.GroupCenterName;
        StudyGroupSessionDetails.GroupName = model.GroupName;
        Settings.StudyGroupId = model.GroupID.ToString();
        StudyGroupSessionDetails.AllStudents = true;
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        StudyGroupSessionDetails.IsGroupSessionList = true;
        await StudyGroupSessionDetails.GetStudentAttendance();
        await StudyGroupSessionDetails.GetStudentEvulation();
        await StudyGroupSessionDetails.GetGroupStudents();
        await StudyGroupSessionDetails.GetGroupAttendance();
        StudyGroupSessionDetails.PageTitle = SharedResources.SessionDetails;

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
