using WytSky.Mobile.Maui.Skoola.ViewModels.Students;

namespace WytSky.Mobile.Maui.Skoola.Views.Quarni.Students;

public partial class StudentsPage : ContentPage
{
    StudentsVM StudentsVM = new();
    public StudentsPage(string groupId)
    {
        InitializeComponent();
        BindingContext = StudentsVM;
        StudentsVM.GroupId = groupId;
    }

    protected async override void OnAppearing()
    {
        try
        {
            base.OnAppearing();
            await StudentsVM.GetStudentsByGroupId();
        }
        catch (Exception ex)
        {
            string er = ex.Message;
        }
    }
}