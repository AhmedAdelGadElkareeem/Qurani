using System.Collections.ObjectModel;
using WytSky.Mobile.Maui.Skoola.Dtos;

namespace WytSky.Mobile.Maui.Skoola.Views;

public partial class ItemsPage : BaseContentPage
{
    public ItemsPage(ObservableCollection<StItem> items , ObservableCollection<StCatgeory> subSubcategories)
    {
        InitializeComponent();
    }

    private async void Back(object sender, EventArgs e)
    {
        await NavigateToPage.ClosePage();
    }

    private async void OpenCartItems(object sender, EventArgs e)
    {
        await NavigateToPage.OpenPage(new CartPage());
    }
}