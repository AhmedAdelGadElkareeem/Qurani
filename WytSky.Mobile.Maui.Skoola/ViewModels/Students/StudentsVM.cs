using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;
using WytSky.Mobile.Maui.Skoola.AppResources;
using WytSky.Mobile.Maui.Skoola.Helpers;
using WytSky.Mobile.Maui.Skoola.APIs;
using WytSky.Mobile.Maui.Skoola.Models;
using WytSky.Mobile.Maui.Skoola.Views.Students;

namespace WytSky.Mobile.Maui.Skoola.ViewModels.Students
{
    public partial class StudentsVM : BaseViewModel
    {
        [ObservableProperty] private ObservableCollection<StudentModel> students;

        // add student popup
        [ObservableProperty] private string  studentName;
        
        public async Task GetStudentsByStudyGroupId()
        {
            IsRunning = true;
            Students = await StudentService.GetStudents();
            IsRunning = false;
        }

        [RelayCommand]
        public void OpenAddStudent()
        {
            var popup = new AddStudentPopup();
            popup.BindingContext = this;
            ShowPopup(popup);
        }

        [RelayCommand]
        public async Task AddStudent()
        {
            try
            {
                var addedStudent = await StudentService.AddStudent(new Dictionary<string, object>()
                {
                    { "GroupID", Settings.StudyGroupId },
                    { "StudentFullName", StudentName },
                    { "Status", "1" },
                });

                if (addedStudent != null && addedStudent.rowsAffected > 0)
                {
                    await GetStudentsByGroupId();
                    Toast.ShowToastError(SharedResources.AddedSuccessfully);
                }
            }
            catch (Exception e)
            {
                string er = e.Message;
            }
            finally
            {
                HidePopup();
            }
        }
    }
}
