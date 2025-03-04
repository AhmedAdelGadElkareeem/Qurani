namespace WytSky.Mobile.Maui.Skoola.Views.Public;

public partial class SuccessPage : BaseContentPage
{
    public SuccessPage(string message)
    {
        try
        {
            InitializeComponent();
            labelMessage.Text = message;
        }
        catch (Exception ex)
        {
            ExtensionLogMethods.LogExtension(ex, "", "SuccessPage", "Constructor");
        }
    }

    private void HomeClicked(object sender, EventArgs e)
    {
        App.Current.MainPage = new MainPage();
    }
}