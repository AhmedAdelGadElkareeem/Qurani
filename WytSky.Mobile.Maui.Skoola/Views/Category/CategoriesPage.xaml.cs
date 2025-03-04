using WytSky.Mobile.Maui.Skoola.Dtos;
using WytSky.Mobile.Maui.Skoola.ViewModels.Category;

namespace WytSky.Mobile.Maui.Skoola.Views.Category;

public partial class CategoriesPage : BaseContentPage
{
    CategoryVM categoryVM = new CategoryVM();

    public CategoriesPage(CategoryModel category)
    {
        try
        {
            InitializeComponent();
            categoryVM.Category = category;
            BindingContext = categoryVM;
        }
        catch (Exception ex)
        {
            ExtensionLogMethods.LogExtension(ex, "", "CategoriesPage", "Contructor");
        }
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        await categoryVM.GetCategories();
    }

    private async void GoBack(object sender, TappedEventArgs e)
    {
        try
        {
            await NavigateToPage.ClosePage();
        }
        catch (Exception ex)
        {
            ExtensionLogMethods.LogExtension(ex, "", "CategoriesPage", "GoBack");
        }
    }
}