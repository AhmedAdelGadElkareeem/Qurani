using CommunityToolkit.Mvvm.ComponentModel;
using WytSky.Mobile.Maui.Skoola.Dtos.Used;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;
using WytSky.Mobile.Maui.Skoola.Views.Courses;

namespace WytSky.Mobile.Maui.Skoola.ViewModels.User
{
    public partial class MyCoursesVM : BaseViewModel
    {
        [ObservableProperty]
        public ObservableCollection<StCourse> ongoingCourses;

        [ObservableProperty]
        public ObservableCollection<StCourse> tempCourses;

        public MyCoursesVM()
        {
            TempCourses = new ObservableCollection<StCourse>()
            {
                new StCourse(){IsCompleted = false, Percentage ="50%"},
                new StCourse(){IsCompleted = true,Percentage ="100%"},
                new StCourse(){IsCompleted = false, Percentage ="50%"},
                new StCourse(){IsCompleted = true,Percentage ="100%"},
                new StCourse(){IsCompleted = false, Percentage ="50%"},
                new StCourse(){IsCompleted = true,Percentage ="100%"},
                new StCourse(){IsCompleted = false, Percentage ="50%"},
                new StCourse(){IsCompleted = true,Percentage ="100%"},
                new StCourse(){ IsCompleted = false,Percentage ="50%"},
                new StCourse(){IsCompleted = true,Percentage ="100%"},
                new StCourse(){ IsCompleted = false,Percentage ="50%"},
                new StCourse(){IsCompleted = true,Percentage ="100%"},
                new StCourse(){ IsCompleted = false,Percentage ="50%"},
                new StCourse(){IsCompleted = true,Percentage ="100%"},
                new StCourse(){ IsCompleted = false,Percentage ="50%"},
                new StCourse(){IsCompleted = true,Percentage ="100%"},
                new StCourse(){ IsCompleted = false,Percentage ="50%"},
                new StCourse(){IsCompleted = true,Percentage ="100%"},
                new StCourse(){ IsCompleted = false,Percentage ="50%"},
                new StCourse(){IsCompleted = true,Percentage ="100%"},
                new StCourse(){ IsCompleted = false,Percentage ="50%"},
                new StCourse(){IsCompleted = true,Percentage ="100%"},
                new StCourse(){ IsCompleted = false,Percentage ="50%"},
                new StCourse(){IsCompleted = true,Percentage ="100%"},
                new StCourse(){ IsCompleted = false,Percentage ="50%"},
                new StCourse(){IsCompleted = true,Percentage ="100%"},
                new StCourse(){ IsCompleted = false,Percentage ="50%"},
                new StCourse(){IsCompleted = true,Percentage ="100%"},
                new StCourse(){ IsCompleted = false,Percentage ="50%"},
                new StCourse(){IsCompleted = true,Percentage ="100%"},
                new StCourse(){ IsCompleted = false,Percentage ="50%"},
                new StCourse(){IsCompleted = true,Percentage ="100%"},
                new StCourse(){ IsCompleted = false,Percentage ="50%"},
                new StCourse(){IsCompleted = true,Percentage ="100%"},
                new StCourse(){ IsCompleted = false,Percentage ="50%"},
                new StCourse(){IsCompleted = true,Percentage ="100%"},
            };
            OngoingCourses = new ObservableCollection<StCourse>(TempCourses.Where(x => !x.IsCompleted));
        }
    }
}
