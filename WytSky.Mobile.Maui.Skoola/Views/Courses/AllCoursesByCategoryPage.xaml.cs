using WytSky.Mobile.Maui.Skoola.Dtos;
using WytSky.Mobile.Maui.Skoola.ViewModels.Courses;

namespace WytSky.Mobile.Maui.Skoola.Views.Courses;

public partial class AllCoursesByCategoryPage : BaseContentPage
{
    AllCoursesByCategoryIdVM allCoursesByCategoryIdVM = new AllCoursesByCategoryIdVM();
    public AllCoursesByCategoryPage(CategoryModel category)
    {
        InitializeComponent();
        allCoursesByCategoryIdVM.Category = category;
        BindingContext = allCoursesByCategoryIdVM;
    }


    protected async override void OnAppearing()
    {
        base.OnAppearing();
        await allCoursesByCategoryIdVM.GetCoursesByCategoryId();
    }
}