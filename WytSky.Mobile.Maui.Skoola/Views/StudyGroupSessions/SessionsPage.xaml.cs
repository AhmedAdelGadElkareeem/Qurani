using WytSky.Mobile.Maui.Skoola.ViewModels.StudyGroupSession;

namespace WytSky.Mobile.Maui.Skoola.Views.StudyGroupSessions;

public partial class SessionsPage : ContentPage
{
    SessionsVM SessionsVM = new SessionsVM();
    public SessionsPage()
	{
		InitializeComponent();
        BindingContext = SessionsVM;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        SessionsVM.GetSessions();
    }
}