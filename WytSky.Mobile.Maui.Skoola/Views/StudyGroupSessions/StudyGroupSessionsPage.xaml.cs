using WytSky.Mobile.Maui.Skoola.Helpers;
using WytSky.Mobile.Maui.Skoola.ViewModels.StudyGroupSession;

namespace WytSky.Mobile.Maui.Skoola.Views.StudyGroupSessions;

public partial class StudyGroupSessionsPage : ContentPage
{
    private readonly StudyGroupSessionsVM _studyGroupSessionsVM;
    public StudyGroupSessionsPage(StudyGroupSessionsVM viewModel)
	{
        InitializeComponent();
        _studyGroupSessionsVM = viewModel ?? throw new ArgumentNullException(nameof(viewModel));
        BindingContext = _studyGroupSessionsVM;

    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        if (_studyGroupSessionsVM != null)
        {
            await _studyGroupSessionsVM.GetSessions();
        }
        else
        {
            Toast.ShowToastError("Error: ViewModel is null in StudyGroupSessionsPage.");
        }
    }
}