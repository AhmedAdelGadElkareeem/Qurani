
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using WytSky.Mobile.Maui.Skoola.APIs;
using WytSky.Mobile.Maui.Skoola.AppResources;
using WytSky.Mobile.Maui.Skoola.Helpers;
using WytSky.Mobile.Maui.Skoola.Models;
using WytSky.Mobile.Maui.Skoola.ViewModels.StudyGroups;
using WytSky.Mobile.Maui.Skoola.Views.Schedules;
using WytSky.Mobile.Maui.Skoola.Views.Students;
using WytSky.Mobile.Maui.Skoola.Views.StudyGroupStudentList;


namespace WytSky.Mobile.Maui.Skoola.ViewModels.Students;

public partial class StudyGroupStudentListVM : StudyGroupVM
{

    #region Properties
    [ObservableProperty] private ObservableCollection<StudyGroupStudentList> studyGroupStudentList;
    [ObservableProperty] private ObservableCollection<StudyGroupStudentList> filteredStudyGroupStudentList = new ObservableCollection<StudyGroupStudentList>();
    [ObservableProperty] private string searchText;
    [ObservableProperty] private ObservableCollection<StudentModel> studentList;


    #endregion


    #region Methods
    public async Task GetStudyGroupStudentList()
    {
        IsRunning = true;
        StudyGroupStudentList = await StudentService.GetStudyGroupStudentList();
        FilteredStudyGroupStudentList = new ObservableCollection<StudyGroupStudentList>(StudyGroupStudentList);
        IsRunning = false;
    }

    partial void OnSearchTextChanging(string value)
    {
        try
        {
            if (!string.IsNullOrEmpty(value))
            {
                FilteredStudyGroupStudentList =
                    new ObservableCollection<StudyGroupStudentList>(StudyGroupStudentList.Where(x => x.StudentFullName.ToLower().Contains(value)).ToList());
            }
            else
            {
                FilteredStudyGroupStudentList = StudyGroupStudentList;
            }
        }
        catch (Exception ex)
        {
            ExtensionLogMethods.LogExtension(ex, "", "StaffVM", "OnSearchTextChanging");
        }
    }
    #endregion

    #region Commands
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
                await GetStudyGroupStudentList();
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
    public async Task GetAllStudents()
    {
        IsRunning = true;
        StudentList = await StudentService.GetAllStudents();
        //FilteredStudyGroupStudentList = new ObservableCollection<StudyGroupStudentList>(StudyGroupStudentList);
        IsRunning = false;
    }
    [RelayCommand]
    private async Task OpenSchedules()
    {
        await OpenPushAsyncPage(new SchedulesPage());
    }

    #endregion

}
