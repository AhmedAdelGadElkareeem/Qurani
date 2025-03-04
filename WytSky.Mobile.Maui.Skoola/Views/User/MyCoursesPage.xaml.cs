using System.Collections.ObjectModel;
using WytSky.Mobile.Maui.Skoola.Dtos.Used;
using WytSky.Mobile.Maui.Skoola.ViewModels.User;
using WytSky.Mobile.Maui.Skoola.Views.Courses;

namespace WytSky.Mobile.Maui.Skoola.Views.User;

public partial class MyCoursesPage : BaseContentPage
{
    private MyCoursesVM MyCoursesVM = new MyCoursesVM();
    public MyCoursesPage()
    {
        try
        {
            InitializeComponent();
            BindingContext = MyCoursesVM;
        }
        catch (Exception ex)
        {
            ExtensionLogMethods.LogExtension(ex, "", "MyCoursesPage", "Constuctor");
        }
    }

    private void OngoingClicked(object sender, TappedEventArgs e)
    {
        ongoingLabel.TextColor = StringExtensions.ToColorFromResourceKey("PrimaryColor");
        ongoingBoxView.Color = StringExtensions.ToColorFromResourceKey("PrimaryColor");
        completedBoxView.Color = StringExtensions.ToColorFromResourceKey("Gray100");
        completedLabel.TextColor = StringExtensions.ToColorFromResourceKey("Black100");

        MyCoursesVM.OngoingCourses = new ObservableCollection<StCourse>(MyCoursesVM.TempCourses.Where(x => !x.IsCompleted));
    }

    private void CompletedClicked(object sender, TappedEventArgs e)
    {
        ongoingBoxView.Color = StringExtensions.ToColorFromResourceKey("Gray100");
        ongoingLabel.TextColor = StringExtensions.ToColorFromResourceKey("Black100");

        completedLabel.TextColor = StringExtensions.ToColorFromResourceKey("PrimaryColor");
        completedBoxView.Color = StringExtensions.ToColorFromResourceKey("PrimaryColor");

        MyCoursesVM.OngoingCourses = new ObservableCollection<StCourse>(MyCoursesVM.TempCourses.Where(x => x.IsCompleted));
    }

    private async void LessonsClicked(object sender, EventArgs e)
    {
        await NavigateToPage.OpenPage(new CompletedCourseDetailsPage());
    }
}