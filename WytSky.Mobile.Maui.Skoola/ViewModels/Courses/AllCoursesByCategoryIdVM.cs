using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using WytSky.Mobile.Maui.Skoola.Dtos;
using WytSky.Mobile.Maui.Skoola.Views.Courses;

namespace WytSky.Mobile.Maui.Skoola.ViewModels.Courses;

public partial class AllCoursesByCategoryIdVM : BaseViewModel
{
    [ObservableProperty]
    string pageTitle;

    [ObservableProperty]
    public CategoryModel category;

    [ObservableProperty]
    public ObservableCollection<CourseModel> courses;

    [ObservableProperty]
    public ObservableCollection<CourseModel> courseContent;

    [ObservableProperty]
    public ObservableCollection<CourseModel> courseMaterial;

    [ObservableProperty]
    public LibVLCSharp.Shared.MediaPlayer mediaPlayer;

    public async Task GetCoursesByCategoryId()
    {
        try
        {
            IsRunning = true;
            Courses = await APIs.ServiceCourses.GetCoursesByCategoryId(Category.Id.ToString());
            if (Courses != null && Courses.Count > 0)
                PageTitle = $"{Courses[0].CategoryMainCategoryName} - {Courses[0].CategoryName}";
            IsRunning = false;
        }
        catch (Exception ex)
        {
            ExtensionLogMethods.LogExtension(ex, "", "", "GetCoursesByCategoryId");
        }
    }

    public async Task GetCourseContentByCourseId(string CourseId)
    {
        try
        {
            IsRunning = true;
            CourseContent = await APIs.ServiceCourses.GetCourseContentByCourseId(CourseId);
            IsRunning = false;
        }
        catch (Exception ex)
        {
            ExtensionLogMethods.LogExtension(ex, "", "", "GetCourseContentByCourseId");
        }
    }

    public async Task GetCourseMaterialsByCourseContentId(string CourseContentId)
    {
        try
        {
            IsRunning = true;
            CourseMaterial = await APIs.ServiceCourses.GetCourseMaterialByCourseContentId(CourseContentId);
            IsRunning = false;
        }
        catch (Exception ex)
        {
            ExtensionLogMethods.LogExtension(ex, "", "", "GetCourseMaterialsByCourseContentId");
        }
    }

    [RelayCommand]
    public async Task SelectCourse(CourseModel courseModel)
    {
        try
        {
            var page = new CourseContentPage();
            page.BindingContext = this;
            await GetCourseContentByCourseId(courseModel.ID.ToString());
            PageTitle = $"{courseModel.Name}";
            await App.Current.MainPage.Navigation.PushModalAsync(page);
        }
        catch (System.Exception ex)
        {
            ExtensionLogMethods.LogExtension(ex.Message, "", "AllCoursesByCategoryIdVM", "SelectCourse");
        }
    }


    [RelayCommand]
    public async Task SelectCourseContent(CourseModel courseContent)
    {
        try
        {
            var page = new CourseMaterialPage();
            page.BindingContext = this;
            await GetCourseMaterialsByCourseContentId(courseContent.ID.ToString());
            PageTitle = $"{courseContent.Name}";
            await App.Current.MainPage.Navigation.PushModalAsync(page);
        }
        catch (System.Exception ex)
        {
            ExtensionLogMethods.LogExtension(ex.Message, "", "AllCoursesByCategoryIdVM", "SelectCourseContent");
        }
    }

    [RelayCommand]
    public async Task SelectCourseMaterial(CourseModel courseMaterial)
    {
        try
        {
            /*string extension = Path.GetExtension(courseMaterial.MaterialLinkContent);
            if (courseMaterial.MaterialLinkContent.Contains("www.youtube.com"))
            {
                await Launcher.OpenAsync(courseMaterial.MaterialLinkContent);
            }
            else if (extension == ".pdf" || extension == ".mp4")
            {
                await Launcher.OpenAsync(courseMaterial.MaterialLinkContent);
            }*/

            await NavigateToPage.OpenPage(new VideoPlayerPage(courseMaterial.MaterialLinkContent));
        }
        catch (System.Exception ex)
        {
            ExtensionLogMethods.LogExtension(ex.Message, "", "AllCoursesByCategoryIdVM", "SelectCourseMaterial");
        }
    }
}