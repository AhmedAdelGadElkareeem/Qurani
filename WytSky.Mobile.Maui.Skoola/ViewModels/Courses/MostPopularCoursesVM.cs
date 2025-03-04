using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WytSky.Mobile.Maui.Skoola.Dtos;
using WytSky.Mobile.Maui.Skoola.Dtos.Used;
using WytSky.Mobile.Maui.Skoola.Views.Courses;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WytSky.Mobile.Maui.Skoola.ViewModels.Courses
{
    public partial class MostPopularCoursesVM:BaseViewModel
    {
        [ObservableProperty]
        public ObservableCollection<StCatgeory> categories;

        [ObservableProperty]
        public ObservableCollection<StCourse> mostPopularCourses;

        public MostPopularCoursesVM()
        {
            Categories = new ObservableCollection<StCatgeory>()
            {
                new StCatgeory(){IsSelected = true,NameEn="All"},
                new StCatgeory(){IsSelected = false,NameEn="Graphic Designer"},
                new StCatgeory(){IsSelected = false,NameEn="Software Development"},
            };
            MostPopularCourses = new ObservableCollection<StCourse>()
            {
                new StCourse(),
                new StCourse(),
                new StCourse(),
                new StCourse(),
                new StCourse(),
                new StCourse(),
                new StCourse(),
                new StCourse(),
                new StCourse(),
            };
        }

        [RelayCommand]
        public void SelectCategory(StCatgeory stCatgeory)
        {
            try
            {
                foreach (var item in Categories)
                {
                    item.IsSelected = false;
                }
                stCatgeory.IsSelected = true;
            }
            catch (Exception ex)
            {
                ExtensionLogMethods.LogExtension(ex.Message, "", "MostPopularCoursesVM", "SelectCategory");
            }
        }

        [RelayCommand]
        public void SelectCourse(StCourse stCourse)
        {
            try
            {
                NavigateToPage.OpenPage(new CourseDetailsPage());
            }
            catch (Exception ex)
            {
                ExtensionLogMethods.LogExtension(ex.Message, "", "MostPopularCoursesVM", "SelectCourse");
            }
        }
    }
}
