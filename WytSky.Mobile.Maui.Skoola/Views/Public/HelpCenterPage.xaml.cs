using WytSky.Mobile.Maui.Skoola.ViewModels.Public;

namespace WytSky.Mobile.Maui.Skoola.Views.Public;

public partial class HelpCenterPage : BaseContentPage
{
    Color PrimaryColor, Gray100, Black100;
    public HelpCenterPage()
    {
        InitializeComponent();
        BindingContext = new FaqVM();

        PrimaryColor = StringExtensions.ToColorFromResourceKey("PrimaryColor");
        Gray100 = StringExtensions.ToColorFromResourceKey("Gray100");
        Black100 = StringExtensions.ToColorFromResourceKey("Black100");
    }

    private void FaqClicked(object sender, TappedEventArgs e)
    {
        try
        {
            faqStack.IsVisible = true;
            contactUsStack.IsVisible = false;
            faqBoxView.Color = PrimaryColor;
            faqLabel.TextColor = PrimaryColor;
            contactUsBoxView.Color = Gray100;
            contactUsLabel.TextColor = Black100;
        }
        catch (Exception ex)
        {
            ExtensionLogMethods.LogExtension(ex, "", "HelpCenterPage", "FaqClicked");
        }
    }

    private void ContactUsClicked(object sender, TappedEventArgs e)
    {
        try
        {
            faqStack.IsVisible = false;
            contactUsStack.IsVisible = true;
            contactUsBoxView.Color = PrimaryColor;
            contactUsLabel.TextColor = PrimaryColor;
            faqBoxView.Color = Gray100;
            faqLabel.TextColor = Black100;
        }
        catch (Exception ex)
        {
            ExtensionLogMethods.LogExtension(ex, "", "HelpCenterPage", "ContactUsClicked");
        }
    }
}