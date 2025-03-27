using System.Threading.Tasks;
using WytSky.Mobile.Maui.Skoola.AppResources;
using WytSky.Mobile.Maui.Skoola.Models;
using WytSky.Mobile.Maui.Skoola.ViewModels.Students;

namespace WytSky.Mobile.Maui.Skoola.Views.StudyGroupStudentList;

public partial class StudyGroupStudentListPage : ContentPage
{
	private StudyGroupStudentListVM studyGroupStudentListVM = new StudyGroupStudentListVM();
    private readonly Dictionary<Button, bool> _buttonStates = new(); // Dictionary to track button states

    public StudyGroupStudentListPage(StudyGroupModel model)
	{
		InitializeComponent();
		BindingContext = studyGroupStudentListVM;
        studyGroupStudentListVM.ComplexRegionName = model.ComplexRegionName;
        studyGroupStudentListVM.ComplexNamee = model.ComplexName;
        studyGroupStudentListVM.CenterName = model.CenterName;
        studyGroupStudentListVM.GroupName = model.GroupName;
        studyGroupStudentListVM.TeacherFullName = model.TeacherFullName;
        studyGroupStudentListVM.AddStudentFromCenter = true;


    }
    protected override async void OnAppearing()
    {
       await studyGroupStudentListVM.GetSessionsByGroupId();
        //studyGroupStudentListVM.GetSessions();
        studyGroupStudentListVM.PageTitle = SharedResources.Txt_Sessions;
        await studyGroupStudentListVM.GetAllStudents();
        await studyGroupStudentListVM.GetSchedules();
        await studyGroupStudentListVM.GetGroupAttendance();
        await studyGroupStudentListVM.GetGroupStudents();

        base.OnAppearing();
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