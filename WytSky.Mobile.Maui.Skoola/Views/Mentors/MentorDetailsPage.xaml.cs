using WytSky.Mobile.Maui.Skoola.ViewModels;

namespace WytSky.Mobile.Maui.Skoola.Views.Mentors;

public partial class MentorDetailsPage : BaseContentPage
{
	public MentorDetailsPage()
	{
		InitializeComponent();
        BindingContext = new MentorDetailsVM();
    }

    private void CoursesClicked(object sender, TappedEventArgs e)
    {
        coursesStack.IsVisible = true;
        studentsStack.IsVisible = false;
        reviewsStack.IsVisible = false;

        coursesBoxView.Color = Color.FromRgba("#2F9946");
        coursesLabel.TextColor = Color.FromRgba("#2F9946");
        studentsBoxView.Color = Color.FromRgba("#E7EAEE");
        studentsLabel.TextColor = Color.FromRgba("#353535");
        reviewsBoxView.Color = Color.FromRgba("#E7EAEE");
        reviewsLabel.TextColor = Color.FromRgba("#353535");
    }

    private void StudentsClicked(object sender, TappedEventArgs e)
    {
        coursesStack.IsVisible = false;
        studentsStack.IsVisible = true;
        reviewsStack.IsVisible = false;
        coursesBoxView.Color = Color.FromRgba("#E7EAEE");
        coursesLabel.TextColor = Color.FromRgba("#353535");
        studentsBoxView.Color = Color.FromRgba("#2F9946");
        studentsLabel.TextColor = Color.FromRgba("#2F9946");
        reviewsBoxView.Color = Color.FromRgba("#E7EAEE");
        reviewsLabel.TextColor = Color.FromRgba("#353535");
    }

    private void ReviewsClicked(object sender, TappedEventArgs e)
    {
        coursesStack.IsVisible = false;
        studentsStack.IsVisible = false;
        reviewsStack.IsVisible = true;
        coursesBoxView.Color = Color.FromRgba("#E7EAEE");
        coursesLabel.TextColor = Color.FromRgba("#353535");
        studentsBoxView.Color = Color.FromRgba("#E7EAEE");
        studentsLabel.TextColor = Color.FromRgba("#353535");
        reviewsBoxView.Color = Color.FromRgba("#2F9946");
        reviewsLabel.TextColor = Color.FromRgba("#2F9946");
    }
}