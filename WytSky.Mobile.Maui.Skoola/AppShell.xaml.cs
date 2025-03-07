using WytSky.Mobile.Maui.Skoola.ViewModels;

namespace WytSky.Mobile.Maui.Skoola;
public partial class AppShell : Shell
{
    readonly CancellationTokenSource cancellationTokenSource = new();

    public AppShell()
    {
        try
        {
            InitializeComponent();
            BindingContext = new BaseViewModel();
        }
        catch (Exception ex)
        {
            ExtensionLogMethods.LogExtension(ex, null, "", "");
        }
    }

    public void SetFlyoutState(bool isPresented)
    {
        this.FlyoutIsPresented = isPresented;
    }
    protected override bool OnBackButtonPressed()
    {
        base.OnBackButtonPressed();
        return false;
    }
}