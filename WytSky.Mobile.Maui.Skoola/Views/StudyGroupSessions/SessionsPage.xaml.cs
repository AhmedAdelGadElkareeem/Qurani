using System.Numerics;
using WytSky.Mobile.Maui.Skoola.Models;
using WytSky.Mobile.Maui.Skoola.ViewModels.StudyGroupSession;

namespace WytSky.Mobile.Maui.Skoola.Views.StudyGroupSessions;

public partial class SessionsPage : ContentPage
{
    SessionsVM SessionsVM = new SessionsVM();
    public SessionsPage(StudentModel model)
	{
		InitializeComponent();
        BindingContext = SessionsVM;
        SessionsVM.ComplexNamee = model.ComplexName;
        SessionsVM.CenterName = model.CenterName;
        SessionsVM.GroupName = model.GroupName;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await SessionsVM.GetSessions();
    }
}