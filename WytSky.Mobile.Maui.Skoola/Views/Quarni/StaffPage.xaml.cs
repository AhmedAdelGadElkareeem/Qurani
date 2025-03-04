using WytSky.Mobile.Maui.Skoola.ViewModels;

namespace WytSky.Mobile.Maui.Skoola.Views.Quarni;

public partial class StaffPage : ContentPage
{

    StaffVM StaffVM = new StaffVM();
    private string CenterID;
    public StaffPage(string v)
    {
        InitializeComponent();
        OnAppearing();
        BindingContext = StaffVM;
        this.CenterID = v;
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        await StaffVM.GetStaff(CenterID);
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

  

}
