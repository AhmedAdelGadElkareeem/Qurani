using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WytSky.Mobile.Maui.Skoola.Dtos;
using System.Collections.ObjectModel;
using WytSky.Mobile.Maui.Skoola.Views.Courses;

namespace WytSky.Mobile.Maui.Skoola.ViewModels.Category;

public partial class CategoryVM : BaseViewModel
{
    /*[ObservableProperty]
    public ObservableCollection<StCatgeory> categories;

    [ObservableProperty]
    public List<StReview> reviewsCount;*/

    [ObservableProperty]
    public CategoryModel category;

    [ObservableProperty]
    public string pageTitle;

    [ObservableProperty]
    public ObservableCollection<CategoryModel> categories;

    public CategoryVM()
    {
        //Categories = new ObservableCollection<StCatgeory>()
        //{
        //    new StCatgeory(){IsSelected = true,NameEn="All"},
        //    new StCatgeory(){IsSelected = false,NameEn="Graphic Designer"},
        //    new StCatgeory(){IsSelected = false,NameEn="Software Development"},
        //};
        //ReviewsCount = new List<StReview>()
        //{
        //    new StReview(){Number = SharedResources.Text_All,IsSelected = true},
        //    new StReview(){Number = "1",IsSelected = false},
        //    new StReview(){Number = "2",IsSelected = false},
        //    new StReview(){Number = "3",IsSelected = false},
        //    new StReview(){Number = "4",IsSelected = false},
        //    new StReview(){Number = "5",IsSelected = false},
        //};
    }

    [RelayCommand]
    public async Task SelectCategory(CategoryModel stCatgeory)
    {
        try
        {
            await App.Current.MainPage.Navigation.PushModalAsync(new AllCoursesByCategoryPage(stCatgeory));
        }
        catch (Exception ex)
        {
            ExtensionLogMethods.LogExtension(ex.Message, "", "HomeVM", "SelectCategory");
        }
    }

    public async Task GetCategories()
    {
        try
        {
            IsRunning = true;
            Categories = await APIs.ServiceCatgeory.GetCategoriesByMainCategoryId(Category.Id.ToString());
            if (Categories != null)
                PageTitle = $"{Categories[0].MainCategoryParentCategoryName} - {Categories[0].MainCategoryName}";
            IsRunning = false;
        }
        catch (Exception ex)
        {
            ExtensionLogMethods.LogExtension(ex, "", "CategoryVM", "GetCategories");
        }
    }

    /*[RelayCommand]
    public async Task OpenResultsPage()
    {
        await NavigateToPage.OpenPage(new CategoriesResultsPage());
    }*/
}