using WytSky.Mobile.Maui.Skoola.ViewModels.Schedules;

namespace WytSky.Mobile.Maui.Skoola.Views.Schedules;

public partial class SchedulesPage : ContentPage
{
    SchedulesVM SchedulesVM = new SchedulesVM();
    public SchedulesPage()
	{
		InitializeComponent();
        BindingContext = SchedulesVM;

    }

    protected override async void OnAppearing()
    {
        await SchedulesVM.GetSchedules();
        base.OnAppearing();
    }
}