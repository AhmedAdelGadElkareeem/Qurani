using WytSky.Mobile.Maui.Skoola.ViewModels;

namespace WytSky.Mobile.Maui.Skoola.Views.Quarni;

public partial class CenterPage : ContentPage
{
    private CenterVM CenterVM;
    private string ComplexId;

    public CenterPage(string complexId)
    {
        InitializeComponent();
        CenterVM = new CenterVM();
        CenterVM.ComplexId = complexId;
        BindingContext = CenterVM;
    }

    /*private async void OnBackButtonClicked(object sender, EventArgs e)
    {
        if (Navigation.NavigationStack.Count > 1)
        {
            await Navigation.PopAsync(); // ✅ Correct way to go back
        }
        else
        {
            Application.Current.MainPage = new NavigationPage(new HomePage()); // Fallback
        }
    }*/
    
    protected async override void OnAppearing()
    {
        base.OnAppearing();
        if (!string.IsNullOrEmpty(CenterVM.ComplexId))
        {
            await CenterVM.GetCenters(); // Load centers on page load
        }
    }
}
