
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using WytSky.Mobile.Maui.Skoola.APIs;
using WytSky.Mobile.Maui.Skoola.AppResources;
using WytSky.Mobile.Maui.Skoola.Helpers;
using WytSky.Mobile.Maui.Skoola.Models;
using WytSky.Mobile.Maui.Skoola.Views.Schedules;
using WytSky.Mobile.Maui.Skoola.Views.Students;
using WytSky.Mobile.Maui.Skoola.Views.StudyGroupStudentList;


namespace WytSky.Mobile.Maui.Skoola.ViewModels.Students;

public partial class StudyGroupStudentListVM : StudentsVM
{

    public async Task GetAllStudents()
    {
        IsRunning = true;
        StudentsList = await StudentService.GetAllStudents();
        IsRunning = false;
    }


    [RelayCommand]
    private async Task OpenAddStudyGroupStudentList()
    {
        var popup = new AddStudyGroupStudentList();
        await GetAllStudents();
        popup.BindingContext = this;
        ShowPopup(popup);
    }

     [RelayCommand]
    private async Task OpenSchedules()
    {

        await OpenPushAsyncPage(new SchedulesPage());

    }




}
