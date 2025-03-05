using System.Globalization;
using WytSky.Mobile.Maui.Skoola.ViewModels;

namespace WytSky.Mobile.Maui.Skoola.Views.Complexes
{
    public partial class ComplexesPage : BaseContentPage
    {
        ComplexesVM complexVM = new ComplexesVM();

        public ComplexesPage()
        {
            try
            {
                InitializeComponent();
                BindingContext = complexVM;
            }
            catch (Exception ex)
            {
                ExtensionLogMethods.LogExtension(ex, "", "ComplexesPage", "Constructor");
            }
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await complexVM.GetComplexs();
        }
    }
}