using WytSky.Mobile.Maui.Skoola.ViewModels.Courses;

namespace WytSky.Mobile.Maui.Skoola.Views.Courses;

public partial class MostPopularCoursesPage : BaseContentPage
{
	public MostPopularCoursesPage()
	{
		InitializeComponent();
		BindingContext = new MostPopularCoursesVM();
    }
}