using WytSky.Mobile.Maui.Skoola.Models;
using WytSky.Mobile.Maui.Skoola.ViewModels.Students;

namespace WytSky.Mobile.Maui.Skoola.Views.Students;

public partial class StudentsPage : BaseContentPage
{
    StudentsVM StudentsVM = new();
    public StudentsPage(BaseModel baseModel)
    {
        InitializeComponent();
        Title = App.IsArabic ? baseModel.NameAr : baseModel.NameEn;
        BindingContext = StudentsVM;
    }

    protected async override void OnAppearing()
    {
        try
        {
            base.OnAppearing();
            await StudentsVM.GetStudentsByStudyGroupId();
        }
        catch (Exception ex)
        {
            string er = ex.Message;
        }
    }
}