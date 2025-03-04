using WytSky.Mobile.Maui.Skoola.ViewModels;

namespace WytSky.Mobile.Maui.Skoola.Views.Quarni;

public partial class CenterPage : ContentPage
{
    private CenterVM CenterVM;
    private string ComplexId;

    public CenterPage(string complexId)
    {
        InitializeComponent();
        ComplexId = complexId;

        // Pass the ComplexId to ViewModel
        CenterVM = new CenterVM(ComplexId);
        BindingContext = CenterVM;

    }

    public CenterPage()
    {
        InitializeComponent();
        CenterVM = new CenterVM();
        BindingContext = CenterVM;
    }

    private async void OnBackButtonClicked(object sender, EventArgs e)
    {
        if (Navigation.NavigationStack.Count > 1)
        {
            await Navigation.PopAsync(); // ✅ Correct way to go back
        }
        else
        {
            Application.Current.MainPage = new NavigationPage(new HomePage()); // Fallback
        }
    }
    private void OnFlyoutButtonClicked(object sender, EventArgs e)
    {
        // Example: Toggle visibility of the entry form
        ComplexEntryLayout.IsVisible = !ComplexEntryLayout.IsVisible;
    }
    protected async override void OnAppearing()
    {
        base.OnAppearing();
        if (!string.IsNullOrEmpty(ComplexId))
        {
            await CenterVM.GetCenters(ComplexId); // Load centers on page load
        }
    }
}
