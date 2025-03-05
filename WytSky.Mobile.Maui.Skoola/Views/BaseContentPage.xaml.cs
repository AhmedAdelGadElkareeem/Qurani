using CommunityToolkit.Mvvm.ComponentModel;
using WytSky.Mobile.Maui.Skoola.Helpers;

namespace WytSky.Mobile.Maui.Skoola.Views;

public partial class BaseContentPage : ContentPage
{
    public BaseContentPage()
    {
        try
        {
            InitializeComponent();
            FlowDirection = App.IsArabic ? FlowDirection.RightToLeft : FlowDirection.LeftToRight;
        }
        catch (Exception ex)
        {
            ExtensionLogMethods.LogExtension(ex, "", "BaseContentPage", "Constructor");
        }
    }

    protected override bool OnBackButtonPressed()
    {
        base.OnBackButtonPressed();
        NavigateToPage.ClosePage();
        return true;
    }
}