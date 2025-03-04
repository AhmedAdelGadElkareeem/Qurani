using CommunityToolkit.Mvvm.ComponentModel;
using WytSky.Mobile.Maui.Skoola.AppResources;
using WytSky.Mobile.Maui.Skoola.Dtos.Used;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;

namespace WytSky.Mobile.Maui.Skoola.ViewModels
{
    public partial class MentorDetailsVM : BaseViewModel
    {
        #region Properties
        [ObservableProperty]
        public ObservableCollection<StCourse> courses;

        [ObservableProperty]
        public ObservableCollection<StStudent> students;

        [ObservableProperty]
        public List<StReview> reviewsCount;

        [ObservableProperty]
        public List<StReview> reviews;
        #endregion

        #region Constructor
        public MentorDetailsVM()
        {
            Courses = new ObservableCollection<StCourse>()
            {
               new StCourse(),
               new StCourse(),
               new StCourse(),
               new StCourse(),
               new StCourse(),
               new StCourse(),
               new StCourse(),
            };
            Students = new ObservableCollection<StStudent>()
            {
               new StStudent(){Name="Naquan Gbeho",Title="Student"},
               new StStudent(){Name="Maryam Shariq",Title="Junior Developer"},
               new StStudent(){Name="Natalia Díaz",Title="Front End Developer"},
               new StStudent(){Name="Naquan Gbeho",Title="Student"},
               new StStudent(){Name="Maryam Shariq",Title="Junior Developer"},
               new StStudent(){Name="Natalia Díaz",Title="Front End Developer"},
               new StStudent(){Name="Naquan Gbeho",Title="Student"},
               new StStudent(){Name="Maryam Shariq",Title="Junior Developer"},
               new StStudent(){Name="Natalia Díaz",Title="Front End Developer"},
            };
            ReviewsCount = new List<StReview>()
            {
                new StReview(){Number = SharedResources.Text_All,IsSelected = true},
                new StReview(){Number = "1",IsSelected = false},
                new StReview(){Number = "2",IsSelected = false},
                new StReview(){Number = "3",IsSelected = false},
                new StReview(){Number = "4",IsSelected = false},
                new StReview(){Number = "5",IsSelected = false},
            };
            Reviews = new List<StReview>()
            {
                new StReview(){ReviewerName="Ali Mahmoud",Time="2 week ago", Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum mollis nunc a molestie dictum."},
                new StReview(){ReviewerName="Ali Mahmoud",Time="2 week ago", Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum mollis nunc a molestie dictum."},
                new StReview(){ReviewerName="Ali Mahmoud",Time="2 week ago", Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum mollis nunc a molestie dictum."},
                new StReview(){ReviewerName="Ali Mahmoud",Time="2 week ago", Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum mollis nunc a molestie dictum."},
                new StReview(){ReviewerName="Ali Mahmoud",Time="2 week ago", Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum mollis nunc a molestie dictum."},
                new StReview(){ReviewerName="Ali Mahmoud",Time="2 week ago", Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum mollis nunc a molestie dictum."},
                new StReview(){ReviewerName="Ali Mahmoud",Time="2 week ago", Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum mollis nunc a molestie dictum."},
            };
        } 
        #endregion

        [RelayCommand]
        public void SelectedReview(StReview stReview)
        {
            try
            {
                foreach (var item in ReviewsCount)
                {
                    item.IsSelected = false;
                }
                stReview.IsSelected = true;
            }
            catch (Exception ex)
            {
                ExtensionLogMethods.LogExtension(ex,"", "MentorDetailsVM", "SelectedReview");
            }
        }
    }
}
