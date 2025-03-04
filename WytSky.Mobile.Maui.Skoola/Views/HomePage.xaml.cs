using System.Globalization;
using WytSky.Mobile.Maui.Skoola.ViewModels;

namespace WytSky.Mobile.Maui.Skoola.Views
{
    public partial class HomePage : BaseContentPage
    {
        HomeVM homeVM = new HomeVM();
        public HomePage()
        {
            try
            {
                InitializeComponent();
                BindingContext = homeVM;
                //AddPopupControl.DataSubmitted += OnDataSubmitted;

            }
            catch (Exception ex)
            {
                ExtensionLogMethods.LogExtension(ex, "", "HomePage", "Constructor");
            }
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await homeVM.GetComplexs();
        }

        private async void OnDataSubmitted(object sender, Dictionary<string, string> formData)
        {
            await DisplayAlert("تمت الإضافة", $"تمت إضافة {formData["اسم المجمع"]} بنجاح!", "موافق");
        }

        private void OnFlyoutButtonClicked(object sender, EventArgs e)
        {
            // Example: Toggle visibility of the entry form
            ComplexEntryLayout.IsVisible = !ComplexEntryLayout.IsVisible;
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
}