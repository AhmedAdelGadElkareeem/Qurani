using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;
using WytSky.Mobile.Maui.Skoola.APIs.Students;
using WytSky.Mobile.Maui.Skoola.AppResources;
using WytSky.Mobile.Maui.Skoola.Helpers;
using WytSky.Mobile.Maui.Skoola.Models.Qurani.Students;
using WytSky.Mobile.Maui.Skoola.Views.Quarni.Students;

namespace WytSky.Mobile.Maui.Skoola.ViewModels.Students
{
    public partial class StudentsVM : BaseViewModel
    {
        [ObservableProperty]
        public ObservableCollection<StudentModel> students;

        [ObservableProperty] public string groupId;

        // add student popup
        [ObservableProperty] public string  studentName;
        
        public async Task GetStudentsByGroupId()
        {
            IsRunning = true;
            Students = await StudentService.GetStudents(GroupId);
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
                    { "GroupId", GroupId },
                    { "StudentFullName", StudentName },
                });

                if (addedStudent != null && addedStudent.rowsAffected > 0)
                    Toast.ShowToastError(SharedResources.Msg_AddedSuccessfully);
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
