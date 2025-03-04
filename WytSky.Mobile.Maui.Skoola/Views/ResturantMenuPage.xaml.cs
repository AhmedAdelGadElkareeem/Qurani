using System.Collections.ObjectModel;
using WytSky.Mobile.Maui.Skoola.Dtos;

namespace WytSky.Mobile.Maui.Skoola.Views;

public partial class ResturantMenuPage : BaseContentPage
{
    public List<CategoryModel> ItemsList { get; set; }

    public ResturantMenuPage(StCatgeory selectedCategory, ObservableCollection<StItem> popularItems)
    {
        InitializeComponent();

        image.Source = selectedCategory.CatgeoryImageUrl;
        name.Text = selectedCategory.Name;

        ItemsList = new List<CategoryModel>()
        {
                new CategoryModel(){Name = "All menu"},
                new CategoryModel(){Name = "Sea food"},
                new CategoryModel(){Name = "Burger"},
                new CategoryModel(){Name = "Chinese"},
                new CategoryModel(){Name = "Drinks"},
        };
        items.ItemsSource = ItemsList;
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