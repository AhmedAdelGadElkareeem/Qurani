using WytSky.Mobile.Maui.Skoola.ViewModels.Category;

namespace WytSky.Mobile.Maui.Skoola.Views.Category;

public partial class CategoriesResultsPage : ContentPage
{
	public CategoriesResultsPage()
	{
		try
		{
            InitializeComponent();
            BindingContext = new CategoriesResultsVM();
        }
		catch (Exception ex)
		{
			ExtensionLogMethods.LogExtension(ex,"", "CategoriesResultsPage", "Contructor");
		}
    }
}