using WytSky.Mobile.Maui.Skoola.Models;
using WytSky.Mobile.Maui.Skoola.ViewModels.Students;

namespace WytSky.Mobile.Maui.Skoola.Views.StudyGroupStudentList;

public partial class StudyGroupStudentListPage : ContentPage
{
	private StudyGroupStudentListVM studyGroupStudentListVM = new StudyGroupStudentListVM();
    public StudyGroupStudentListPage(StudyGroupModel model)
	{
		InitializeComponent();
		BindingContext = studyGroupStudentListVM;
        studyGroupStudentListVM.ComplexRegionName = model.ComplexRegionName;
        studyGroupStudentListVM.ComplexNamee = model.ComplexName;
        studyGroupStudentListVM.CenterName = model.CenterName;
        studyGroupStudentListVM.GroupName = model.GroupName;
        studyGroupStudentListVM.TeacherFullName = model.TeacherFullName;


    }
    protected override void OnAppearing()
    {
        studyGroupStudentListVM.GetStudeyGrouStudenList();
        studyGroupStudentListVM.GetAllStudents();
        base.OnAppearing();
    }
}