using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WytSky.Mobile.Maui.Skoola.Models;
using WytSky.Mobile.Maui.Skoola.ViewModels.Students;

namespace WytSky.Mobile.Maui.Skoola.Views.Students;

public partial class StudentDetailsPage : BaseContentPage
{
    StudentsVM StudentsVM = new StudentsVM();
    public StudentDetailsPage(StudentModel student)
	{
		InitializeComponent();
        BindingContext = StudentsVM;
        StudentsVM.StudentID = student.StudentID.ToString();
        StudentsVM.GroupId = student.GroupID.ToString();
        StudentsVM.CountryName = student.CountryName;
        StudentsVM.ComplexNamee = student.ComplexName;
        StudentsVM.CenterName = student.CenterName;
        StudentsVM.ComplexRegionName = student.RegionName;
    }
    protected override async void OnAppearing()
    {
        try
        {
            await StudentsVM.GetStudentAttendanceByStudyGroupID();
            base.OnAppearing();
        }
        catch (Exception ex)
        {

            ExtensionLogMethods.LogExtension(ex, "", "OnAppearing", "StudentDetailsPage");
        }
        
    }
}