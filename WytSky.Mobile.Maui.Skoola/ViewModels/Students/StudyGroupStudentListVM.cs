
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using WytSky.Mobile.Maui.Skoola.APIs;
using WytSky.Mobile.Maui.Skoola.AppResources;
using WytSky.Mobile.Maui.Skoola.Helpers;
using WytSky.Mobile.Maui.Skoola.Models;
using WytSky.Mobile.Maui.Skoola.Views.Students;
using WytSky.Mobile.Maui.Skoola.Views.StudyGroupStudentList;

namespace WytSky.Mobile.Maui.Skoola.ViewModels.Students;

public partial class StudyGroupStudentListVM : StudentsVM
{

    [ObservableProperty] 
    private ObservableCollection<StudentModel> studentsList;

    [ObservableProperty]
    private ObservableCollection<StudyGroupStudentList> studyGroupStudentsList;

    [ObservableProperty]
    private StudentModel selectedStudent;
    
    [ObservableProperty]
    public bool isxsistStudent = false;
    [ObservableProperty]
    public bool isNewStudent = false;


    public async Task GetAllStudents()
    {
        IsRunning = true;
        StudentsList = await StudentService.GetAllStudents();
        IsRunning = false;
    }
    public async Task GetStudeyGrouStudenList()
    {
        IsRunning = true;
        StudyGroupStudentsList = await StudentService.GetStudyGroupStudentList();
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
    public async Task AddExsistingStudent()
    {
        try
        {
            var formData = new Dictionary<string, object>()
            {
                { "StudentID", SelectedStudent.StudentID },
                { "GroupID", Settings.StudyGroupId },
            };
            var result = await StudentStudyGroupList.AddStudyGroupStudentList(formData);
            if (result != null && result.rowsAffected > 0)
            {
                await GetStudeyGrouStudenList();
                Toast.ShowToastError(SharedResources.AddedSuccessfully);
            } 

        }
        catch (Exception e)
        {
            ExtensionLogMethods.LogExtension(e, "", "StudyGroupStudentListVM", "AddExsistingStudent");
        }
        finally
        {
            HidePopup();
        }
    }

    [RelayCommand]
    public async Task AddStudyGroupStudentList()
    {
        try
        {
            await AddStudent();
        }
        catch (Exception e)
        {

            ExtensionLogMethods.LogExtension(e, "", "AddStudyGroupStudentList", "StudyGroupStudentListVM");
        }
    }

    partial void OnSelectedStudentChanged(StudentModel value )
    {
        SelectedStudent = value;
        IsNewStudent = false;
    }





}
