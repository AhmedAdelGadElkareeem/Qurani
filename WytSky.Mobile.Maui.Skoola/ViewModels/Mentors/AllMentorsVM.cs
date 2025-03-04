using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WytSky.Mobile.Maui.Skoola.Dtos;
using WytSky.Mobile.Maui.Skoola.Views.Mentors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WytSky.Mobile.Maui.Skoola.ViewModels.Mentors
{
    public partial class AllMentorsVM : BaseViewModel
    {
        [ObservableProperty]
        public List<StMentor> mentors;

        public AllMentorsVM()
        {
            Mentors = new List<StMentor>()
            {
                new StMentor(){Name = "Anaya Singh",Title="Student",Image="avatar",NumberOfCourses="25",NumberOfReviews="1,450",NumberOfStudents="3,150"},
                new StMentor(){Name = "Deep Lumari",Title="Junior Developer",Image="avatar",NumberOfCourses="25",NumberOfReviews="1,450",NumberOfStudents="3,150"},
                new StMentor(){Name = "Rishita Lal",Title="Student", Image = "avatar", NumberOfCourses = "25", NumberOfReviews = "1,450", NumberOfStudents = "3,150"},
                new StMentor(){Name = "Anaya Bai",Title="Junior Developer", Image = "avatar", NumberOfCourses = "25", NumberOfReviews = "1,450", NumberOfStudents = "3,150"},
                new StMentor(){Name = "Mark Brown",Title="Student", Image = "avatar", NumberOfCourses = "25", NumberOfReviews = "1,450", NumberOfStudents = "3,150"},
                new StMentor(){Name = "Anaya Singh",Title="Junior Developer", Image = "avatar", NumberOfCourses = "25", NumberOfReviews = "1,450", NumberOfStudents = "3,150"},
                new StMentor(){Name = "Deep Lumari",Title="Student", Image = "avatar", NumberOfCourses = "25", NumberOfReviews = "1,450", NumberOfStudents = "3,150"},
                new StMentor(){Name = "Rishita Lal",Title="Junior Developer", Image = "avatar", NumberOfCourses = "25", NumberOfReviews = "1,450", NumberOfStudents = "3,150"},
                new StMentor(){Name = "Anaya Bai",Title="Student", Image = "avatar", NumberOfCourses = "25", NumberOfReviews = "1,450", NumberOfStudents = "3,150"},
                new StMentor(){Name = "Mark Brown",Title="Junior Developer", Image = "avatar", NumberOfCourses = "25", NumberOfReviews = "1,450", NumberOfStudents = "3,150"},
            };
        }

        [RelayCommand]
        public void MentorDetails()
        {
            NavigateToPage.OpenPage(new MentorDetailsPage());
        }
    }
}
