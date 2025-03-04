using WytSky.Mobile.Maui.Skoola.ViewModels.Courses;

namespace WytSky.Mobile.Maui.Skoola.Views.Courses;

public partial class EnrollCoursePage : BaseContentPage
{
	public EnrollCoursePage()
	{
		InitializeComponent();
        BindingContext = new CourseDetailsVM();
    }
}