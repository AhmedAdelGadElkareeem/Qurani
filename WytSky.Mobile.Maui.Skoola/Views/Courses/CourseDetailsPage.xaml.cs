using WytSky.Mobile.Maui.Skoola.ViewModels.Courses;
using WytSky.Mobile.Maui.Skoola.Views.Mentors;

namespace WytSky.Mobile.Maui.Skoola.Views.Courses;

public partial class CourseDetailsPage : BaseContentPage
{
	public CourseDetailsPage()
	{
		InitializeComponent();
        BindingContext = new CourseDetailsVM();
    }

    private async Task GoBack(object sender, TappedEventArgs e)
    {
		await NavigateToPage.ClosePage();
    }

    private void LessonsClicked(object sender, TappedEventArgs e)
    {
        aboutsStack.IsVisible = false;
        lessonsStack.IsVisible = true;
        reviewsStack.IsVisible = false;
        aboutusBoxView.Color = StringExtensions.ToColorFromResourceKey("Gray100");
        aboutLabel.TextColor = StringExtensions.ToColorFromResourceKey("Black100");
        lessonsBoxView.Color = StringExtensions.ToColorFromResourceKey("PrimaryColor");
        lessonsLabel.TextColor = StringExtensions.ToColorFromResourceKey("PrimaryColor");
        reviewsBoxView.Color = StringExtensions.ToColorFromResourceKey("Gray100");
        reviewsLabel.TextColor = StringExtensions.ToColorFromResourceKey("Black100");
    }

    private void ReviewsClicked(object sender, TappedEventArgs e)
    {
        aboutsStack.IsVisible = false;
        lessonsStack.IsVisible = false;
        reviewsStack.IsVisible = true;
        aboutusBoxView.Color = StringExtensions.ToColorFromResourceKey("Gray100");
        aboutLabel.TextColor = StringExtensions.ToColorFromResourceKey("Black100");
        lessonsBoxView.Color = StringExtensions.ToColorFromResourceKey("Gray100");
        lessonsLabel.TextColor = StringExtensions.ToColorFromResourceKey("Black100");
        reviewsBoxView.Color = StringExtensions.ToColorFromResourceKey("PrimaryColor");
        reviewsLabel.TextColor = StringExtensions.ToColorFromResourceKey("PrimaryColor");
    }

    private void AboutClicked(object sender, TappedEventArgs e)
    {
        aboutsStack.IsVisible = true;
        lessonsStack.IsVisible = false;
        reviewsStack.IsVisible = false;
        aboutusBoxView.Color = StringExtensions.ToColorFromResourceKey("PrimaryColor");
        aboutLabel.TextColor = StringExtensions.ToColorFromResourceKey("PrimaryColor");
        lessonsBoxView.Color = StringExtensions.ToColorFromResourceKey("Gray100"); 
        lessonsLabel.TextColor = StringExtensions.ToColorFromResourceKey("Black100");
        reviewsBoxView.Color = StringExtensions.ToColorFromResourceKey("Gray100");
        reviewsLabel.TextColor = StringExtensions.ToColorFromResourceKey("Black100");

    }

    private async void OpenMentorDetailsPage(object sender, TappedEventArgs e)
    {
        await NavigateToPage.OpenPage(new MentorDetailsPage());
    }
}