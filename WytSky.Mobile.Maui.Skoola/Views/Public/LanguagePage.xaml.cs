using System.Globalization;
using WytSky.Mobile.Maui.Skoola.ViewModels.Public;

namespace WytSky.Mobile.Maui.Skoola.Views.Public;

public partial class LanguagePage : BaseContentPage
{
    public LanguagePage()
    {
        InitializeComponent();
        BindingContext = new LangaugeVM();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        //if (Helpers.Settings.Language == "en")
        //{
        //    english.IsChecked = true;
        //    //arabic.IsChecked = false;
        //}
        //else
        //{
        //    arabic.IsChecked = true;
        //    //english.IsChecked = false;
        //}
    }

    private async void EnRadioButton_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        await SelectLanguage("en");
    }

    private async void ArCheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        await SelectLanguage("ar");
    }

    public async Task SelectLanguage(string selectedLang)
    {
        try
        {
            CultureInfo culture;
            if (selectedLang == "en")
            {
                Helpers.Settings.Language = "en";
                culture = new CultureInfo("en-US");
            }
            else
            {
                Helpers.Settings.Language = "ar";
                culture = new CultureInfo("ar-AE");
            }
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
            AppResources.SharedResources.Culture = culture;
            Thread.CurrentThread.CurrentUICulture.NumberFormat = new CultureInfo("en").NumberFormat;
            Thread.CurrentThread.CurrentUICulture.DateTimeFormat = new CultureInfo("en").DateTimeFormat;

            try
            {
                await NavigateToPage.ClosePage();
            }
            catch (Exception)
            {
            }

            App.Current.MainPage = new MainPage();
        }
        catch (Exception ex)
        {
            ExtensionLogMethods.LogExtension(ex, "", "NotificationSettingsCard", "RadioButton_CheckedChanged");
        }
    }
}