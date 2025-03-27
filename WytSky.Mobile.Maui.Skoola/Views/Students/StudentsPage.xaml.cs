using WytSky.Mobile.Maui.Skoola.Models;
using WytSky.Mobile.Maui.Skoola.ViewModels.Students;

namespace WytSky.Mobile.Maui.Skoola.Views.Students;

public partial class StudentsPage : BaseContentPage
{
    StudentsVM StudentsVM = new();
    public StudentsPage(CentersModel model)
    {
        InitializeComponent();
        //Title = name;
        BindingContext = StudentsVM;
        StudentsVM.CountryName = model.ComplexRegionCountryName;
        StudentsVM.ComplexNamee = model.ComplexName;
        StudentsVM.CenterName = model.CenterName;
        StudentsVM.ComplexRegionName = model.ComplexRegionName;
        StudentsVM.AddStudentFromCenter = false;
    }

    protected async override void OnAppearing()
    {
        try
        {
            base.OnAppearing();
            await StudentsVM.GetStudentsByCenterId();
        }
        catch (Exception ex)
        {
            string er = ex.Message;
        }
    }
}