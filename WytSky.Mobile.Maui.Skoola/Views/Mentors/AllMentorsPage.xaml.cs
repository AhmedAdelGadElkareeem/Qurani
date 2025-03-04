using WytSky.Mobile.Maui.Skoola.ViewModels.Mentors;

namespace WytSky.Mobile.Maui.Skoola.Views.Mentors;

public partial class AllMentorsPage : BaseContentPage
{
	public AllMentorsPage()
	{
		InitializeComponent();
		BindingContext = new AllMentorsVM();
	}
}