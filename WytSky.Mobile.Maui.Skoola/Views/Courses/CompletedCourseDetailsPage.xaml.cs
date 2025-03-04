using WytSky.Mobile.Maui.Skoola.ViewModels.Courses;

namespace WytSky.Mobile.Maui.Skoola.Views.Courses;

public partial class CompletedCourseDetailsPage : BaseContentPage
{
    public CompletedCourseDetailsPage()
    {
        try
        {
            InitializeComponent();
            BindingContext = new CompletedCourseDetailsVM();
        }
        catch (Exception ex)
        {
            string er = ex.Message;
            ExtensionLogMethods.LogExtension(ex, "", "CompletedCourseDetailsPage", "Constuctor");
        }
    }

    private void CommentsClicked(object sender, TappedEventArgs e)
    {
        commentsStack.IsVisible = true;
        questionsStack.IsVisible = false;
        attachmentsStack.IsVisible = false;
        lessonsStack.IsVisible = false;

        commentsBoxView.Color = StringExtensions.ToColorFromResourceKey("PrimaryColor");
        commentsLabel.TextColor = StringExtensions.ToColorFromResourceKey("PrimaryColor");
        lessonsBoxView.Color = StringExtensions.ToColorFromResourceKey("Gray100");
        lessonsLabel.TextColor = StringExtensions.ToColorFromResourceKey("Black100");
        attachmentsBoxView.Color = StringExtensions.ToColorFromResourceKey("Gray100");
        attachmentsLabel.TextColor = StringExtensions.ToColorFromResourceKey("Black100");
        questionsBoxView.Color = StringExtensions.ToColorFromResourceKey("Gray100");
        questionsLabel.TextColor = StringExtensions.ToColorFromResourceKey("Black100");
    }

    private void LessonsClicked(object sender, TappedEventArgs e)
    {
        lessonsStack.IsVisible = true;
        commentsStack.IsVisible = false;
        questionsStack.IsVisible = false;
        attachmentsStack.IsVisible = false;

        lessonsBoxView.Color = StringExtensions.ToColorFromResourceKey("PrimaryColor");
        lessonsLabel.TextColor = StringExtensions.ToColorFromResourceKey("PrimaryColor");
        questionsBoxView.Color = StringExtensions.ToColorFromResourceKey("Gray100");
        questionsLabel.TextColor = StringExtensions.ToColorFromResourceKey("Black100");
        attachmentsBoxView.Color = StringExtensions.ToColorFromResourceKey("Gray100");
        attachmentsLabel.TextColor = StringExtensions.ToColorFromResourceKey("Black100");
        commentsBoxView.Color = StringExtensions.ToColorFromResourceKey("Gray100");
        commentsLabel.TextColor = StringExtensions.ToColorFromResourceKey("Black100");
    }

    private void QuestionsClicked(object sender, TappedEventArgs e)
    {
        questionsStack.IsVisible = true;
        commentsStack.IsVisible = false;
        attachmentsStack.IsVisible = false;
        lessonsStack.IsVisible = false;

        questionsBoxView.Color = StringExtensions.ToColorFromResourceKey("PrimaryColor");
        questionsLabel.TextColor = StringExtensions.ToColorFromResourceKey("PrimaryColor");
        lessonsBoxView.Color = StringExtensions.ToColorFromResourceKey("Gray100");
        lessonsLabel.TextColor = StringExtensions.ToColorFromResourceKey("Black100");
        attachmentsBoxView.Color = StringExtensions.ToColorFromResourceKey("Gray100");
        attachmentsLabel.TextColor = StringExtensions.ToColorFromResourceKey("Black100");
        commentsBoxView.Color = StringExtensions.ToColorFromResourceKey("Gray100");
        commentsLabel.TextColor = StringExtensions.ToColorFromResourceKey("Black100");
    }

    private void AttachmentsClicked(object sender, TappedEventArgs e)
    {
        attachmentsStack.IsVisible = true;
        commentsStack.IsVisible = false;
        questionsStack.IsVisible = false;
        lessonsStack.IsVisible = false;

        attachmentsBoxView.Color = StringExtensions.ToColorFromResourceKey("PrimaryColor");
        attachmentsLabel.TextColor = StringExtensions.ToColorFromResourceKey("PrimaryColor");
        lessonsBoxView.Color = StringExtensions.ToColorFromResourceKey("Gray100");
        lessonsLabel.TextColor = StringExtensions.ToColorFromResourceKey("Black100");
        questionsBoxView.Color = StringExtensions.ToColorFromResourceKey("Gray100");
        questionsLabel.TextColor = StringExtensions.ToColorFromResourceKey("Black100");
        commentsBoxView.Color = StringExtensions.ToColorFromResourceKey("Gray100");
        commentsLabel.TextColor = StringExtensions.ToColorFromResourceKey("Black100");
    }

    private void OpenMentorDetailsPage(object sender, TappedEventArgs e)
    {

    }
}