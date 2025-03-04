using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WytSky.Mobile.Maui.Skoola.AppResources;
using WytSky.Mobile.Maui.Skoola.Dtos.Used;
using WytSky.Mobile.Maui.Skoola.Views.Courses;
using WytSky.Mobile.Maui.Skoola.Views.Payment;
using WytSky.Mobile.Maui.Skoola.Views.User;

namespace WytSky.Mobile.Maui.Skoola.ViewModels.Courses
{
    public partial class CourseDetailsVM : BaseViewModel
    {
        #region Properties
        [ObservableProperty]
        public StCourse course;

        [ObservableProperty]
        public List<StLesson> lessons;

        [ObservableProperty]
        public List<StReview> reviewsCount;

        [ObservableProperty]
        public List<StReview> reviews;
        #endregion

        public CourseDetailsVM()
        {
            Course = new StCourse()
            {
                Name = "Java",
                PriceBefore = "300",
                PriceAfter = "150",
                Rate = "4.5",
                NumberOfEnroll = "315",
                Lessons = new List<StLesson>()
                {
                    new StLesson()
                    {
                        Name = "Section 1 : Introduction",
                        Duration = "30 min",
                        Subjects = new List<StSubjects>()
                        {
                            new StSubjects()
                            {
                                Name = "Inroduction To JavaScript",
                                Duration = "10 min" , IsFree = true,
                            },
                            new StSubjects()
                            {
                                Name = "Inroduction To JavaScript",
                                Duration = "10 min"
                            },
                            new StSubjects()
                            {
                                Name = "Inroduction To JavaScript",
                                Duration = "10 min"
                            },
                        }
                    },
                    new StLesson()
                    {
                        Name = "Section 2 : Installing Software",
                        Duration = "30 min",
                        Subjects = new List<StSubjects>()
                        {
                            new StSubjects()
                            {
                                Name = "Inroduction To JavaScript",
                                Duration = "10 min",IsFree = true
                            },
                            new StSubjects()
                            {
                                Name = "Inroduction To JavaScript",
                                Duration = "10 min"
                            },
                            new StSubjects()
                            {
                                Name = "Inroduction To JavaScript",
                                Duration = "10 min"
                            },
                        }
                    },
                    new StLesson()
                    {
                        Name = "Section 3 : Installing Software",
                        Duration = "30 min",
                        Subjects = new List<StSubjects>()
                        {
                            new StSubjects()
                            {
                                Name = "Inroduction To JavaScript",
                                Duration = "10 min",IsFree = true
                            },
                            new StSubjects()
                            {
                                Name = "Inroduction To JavaScript",
                                Duration = "10 min"
                            },
                            new StSubjects()
                            {
                                Name = "Inroduction To JavaScript",
                                Duration = "10 min"
                            },
                        }
                    },
                },
                ReviewsCount = new List<StReview>()
                {
                    new StReview(){Number = SharedResources.Text_All,IsSelected = true},
                    new StReview(){Number = "1",IsSelected = false},
                    new StReview(){Number = "2",IsSelected = false},
                    new StReview(){Number = "3",IsSelected = false},
                    new StReview(){Number = "4",IsSelected = false},
                    new StReview(){Number = "5",IsSelected = false},
                },
                Reviews = new List<StReview>()
                {
                    new StReview(){ReviewerName="Ali Mahmoud",Time="2 week ago", Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum mollis nunc a molestie dictum."},
                    new StReview(){ReviewerName="Ali Mahmoud",Time="2 week ago", Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum mollis nunc a molestie dictum."},
                    new StReview(){ReviewerName="Ali Mahmoud",Time="2 week ago", Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum mollis nunc a molestie dictum."},
                    new StReview(){ReviewerName="Ali Mahmoud",Time="2 week ago", Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum mollis nunc a molestie dictum."},
                    new StReview(){ReviewerName="Ali Mahmoud",Time="2 week ago", Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum mollis nunc a molestie dictum."},
                    new StReview(){ReviewerName="Ali Mahmoud",Time="2 week ago", Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum mollis nunc a molestie dictum."},
                    new StReview(){ReviewerName="Ali Mahmoud",Time="2 week ago", Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum mollis nunc a molestie dictum."},
                },
                Comments = new List<StComment>()
                {
                    new StComment(){ Replies = new List<StComment>(){ new StComment(), new StComment() } },
                    new StComment(){ Replies = new List<StComment>(){ new StComment(), new StComment() } },
                    new StComment(){},
                }
            };
        }

        [RelayCommand]
        public void SelectedReview(StReview stReview)
        {
            try
            {
                if (ReviewsCount != null)
                    foreach (var item in ReviewsCount)
                    {
                        item.IsSelected = false;
                    }

                stReview.IsSelected = true;
            }
            catch (Exception ex)
            {
                ExtensionLogMethods.LogExtension(ex, "", "CourseDetailsVM", "SelectedReview");
            }
        }

        [RelayCommand]
        public async Task EnrollCourse()
        {
            try
            {
                await NavigateToPage.OpenPage(new EnrollCoursePage());
            }
            catch (Exception ex)
            {
                ExtensionLogMethods.LogExtension(ex, "", "CourseDetailsVM", "EnrollCourse");
            }
        }

        [RelayCommand]
        public async Task PayNow()
        {
            try
            {
                var paymentPage = new PaymentSuccessfullyPage();
                paymentPage.BindingContext = this;
                await NavigateToPage.OpenPage(paymentPage);
            }
            catch (Exception ex)
            {
                ExtensionLogMethods.LogExtension(ex, "", "CourseDetailsVM", "PayNow");
            }
        }

        // for payment page
        [RelayCommand]
        public async Task OpenMyCourses()
        {
            await NavigateToPage.OpenPage(new MyCoursesPage());
        }
    }
}
