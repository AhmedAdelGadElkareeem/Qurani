using WytSky.Mobile.Maui.Skoola.ViewModels.Students;

namespace WytSky.Mobile.Maui.Skoola.Views.StudyGroupStudentList;

public partial class StudyGroupStudentListPage : ContentPage
{
	private StudyGroupStudentListVM studyGroupStudentListVM = new StudyGroupStudentListVM();
    public StudyGroupStudentListPage()
	{
		InitializeComponent();
		BindingContext = studyGroupStudentListVM;

    }
    protected override void OnAppearing()
    {
        studyGroupStudentListVM.GetStudeyGrouStudenList();
        base.OnAppearing();
    }
}