
using CommunityToolkit.Mvvm.Input;
using WytSky.Mobile.Maui.Skoola.APIs;
using WytSky.Mobile.Maui.Skoola.Views.Students;

namespace WytSky.Mobile.Maui.Skoola.ViewModels.Students;

public partial class StudyGroupStudentListVM : StudentsVM
{

    public async Task GetStudentsByStudyGroupId()
    {
        IsRunning = true;
        Students = await StudentService.GetStudents();
        IsRunning = false;
    }

}
