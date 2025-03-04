
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WytSky.Mobile.Maui.Skoola.Dtos;
using WytSky.Mobile.Maui.Skoola.Models;
using WytSky.Mobile.Maui.Skoola.Views.Courses;
using WytSky.Mobile.Maui.Skoola.Views.Quarni;
using Settings = WytSky.Mobile.Maui.Skoola.Helpers.Settings;

namespace WytSky.Mobile.Maui.Skoola.ViewModels;

public partial class HomeVM : BaseViewModel
{
    #region Properties
    [ObservableProperty]
    public ObservableCollection<ComplexModel> complexes = new ObservableCollection<ComplexModel>();


    [ObservableProperty]
    public ObservableCollection<CentersModel> centers = new ObservableCollection<CentersModel>();


    [ObservableProperty]
    public ObservableCollection<CategoryModel> mainCategories = new ObservableCollection<CategoryModel>();

    [ObservableProperty]
    public ObservableCollection<CategoryModel> categories = new ObservableCollection<CategoryModel>();

    [ObservableProperty]
    public bool categoriesVisiblity;

    [ObservableProperty]
    string userName;

    /*[ObservableProperty]
    public ObservableCollection<StMentor> mentors;

    [ObservableProperty]
    public ObservableCollection<StCourse> topRatedCourses;

    [ObservableProperty]
    public ObservableCollection<StCatgeory> categories;

    [ObservableProperty]
    public ObservableCollection<StCourse> mostPopularCourses;*/
    #endregion

    [ObservableProperty]
    public string complexxName ;



    #region Constructor
    public HomeVM()
    {
        UserName = Settings.UserName;
        /* Mentors = new ObservableCollection<StMentor>()
         {
             new StMentor(){Name = "Anaya Singh",Image="avatar"},
             new StMentor(){Name = "Deep Lumari",Image="avatar"},
             new StMentor(){Name = "Rishita Lal",Image="avatar"},
             new StMentor(){Name = "Anaya Bai",Image="avatar"},
             new StMentor(){Name = "Mark Brown",Image="avatar"},
             new StMentor(){Name = "Anaya Singh",Image="avatar"},
             new StMentor(){Name = "Deep Lumari",Image="avatar"},
             new StMentor(){Name = "Rishita Lal",Image="avatar"},
             new StMentor(){Name = "Anaya Bai",Image="avatar"},
             new StMentor(){Name = "Mark Brown",Image="avatar"},
         };
         TopRatedCourses = new ObservableCollection<StCourse>()
         {
              new StCourse(),
              new StCourse(),
              new StCourse(),
              new StCourse(),
              new StCourse(),
              new StCourse(),
              new StCourse(),
         };
         Categories = new ObservableCollection<StCatgeory>()
         {
             new StCatgeory(){IsSelected = true,  NameEn = "All"},
             new StCatgeory(){IsSelected = false, NameEn = "Graphic Designer"},
             new StCatgeory(){IsSelected = false, NameEn = "Software Development"},
         };
         MostPopularCourses = new ObservableCollection<StCourse>()
         {
             new StCourse(),
             new StCourse(),
             new StCourse(),
             new StCourse(),
             new StCourse(),
             new StCourse(),
             new StCourse(),
             new StCourse(),
             new StCourse(),
         };*/
    }
    #endregion

    #region Methods
    public async Task GetComplexs()
    {
        try
        {
            IsRunning = true;
            CategoriesVisiblity = false;

            Complexes = await APIs.ServiceCatgeory.GetComplexs();
            if (Complexes != null && Complexes.Count > 0)
            {
                Complexes[0].TextColor = StringExtensions.ToColorFromResourceKey("White");
                Complexes[0].BackgroundColor = StringExtensions.ToColorFromResourceKey("PrimaryColor");


                //App.Current.MainPage = new CenterPage(Complexes[0].ComplexID.ToString());
                 //Navigate to Masajid page
            }
            IsRunning = false;
        }
        catch (Exception ex)
        {
            ExtensionLogMethods.LogExtension(ex, "", "", "GetParentCategories");
        }
    }

    public async Task GetMainCategoriesByParentCategoryId(string ParentId)
    {
        IsRunning = true;
        Centers = await APIs.ServiceCatgeory.GetCenters(ParentId);
        IsRunning = false;
    }

    public async Task GetCategoriesByMainCategoryId(string mainCategoryId)
    {
        try
        {
            IsRunning = true;
            Categories = await APIs.ServiceCatgeory.GetCategoriesByMainCategoryId(mainCategoryId);
            if (Categories != null && Categories.Count > 0)
            {
                CategoriesVisiblity = true;
            }
            IsRunning = false;
        }
        catch (Exception ex)
        {
            ExtensionLogMethods.LogExtension(ex, "", "CategoryVM", "GetCategories");
        }
    }
    #endregion

    #region Commands

    [RelayCommand]
    public async Task AddComplex()
    {
        try
        {
            if (string.IsNullOrWhiteSpace(ComplexxName))
            {
                await App.Current.MainPage.DisplayAlert("Error", "Complex name cannot be empty", "OK");
                return;
            }

            IsRunning = true;

            // Create form data dictionary
            var formData = new Dictionary<string, object>
        {
            { "ComplexName", ComplexxName }
        };

            // Call the AddComplex service method
            var result = await APIs.ServiceCatgeory.AddComplex(formData);

            if (result != null)
            {
                // Successfully added, update the list
                Complexes.Add(result);
                await App.Current.MainPage.DisplayAlert("Success", "Complex added successfully!", "OK");
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Error", "Failed to add complex", "OK");
            }
        }
        catch (Exception ex)
        {
            ExtensionLogMethods.LogExtension(ex, "", "HomeVM", "AddComplex");
            await App.Current.MainPage.DisplayAlert("Error", "An unexpected error occurred", "OK");
        }
        finally
        {
            IsRunning = false;
        }
    }



















    [RelayCommand]
    public async Task SelectParentCategory(ComplexModel complexModel)
    {
        try
        {
            //CategoriesVisiblity = false;

            foreach (var item in Complexes)
            {
                item.IsSelected = false;
                item.TextColor = Colors.DimGray;
                item.BackgroundColor = Colors.White;
            }

            complexModel.IsSelected = true;
            complexModel.TextColor = StringExtensions.ToColorFromResourceKey("White");
            complexModel.BackgroundColor = StringExtensions.ToColorFromResourceKey("PrimaryColor");
            await GetMainCategoriesByParentCategoryId(complexModel.ComplexID.ToString());

            if (Application.Current.MainPage is NavigationPage navPage)
            {
                await navPage.PushAsync(new CenterPage(complexModel.ComplexID.ToString()));
            }
            else
            {
                // Fallback: Wrap in NavigationPage
                Application.Current.MainPage = new NavigationPage(new CenterPage(complexModel.ComplexID.ToString()));
            }
        }

        catch (Exception ex)
        {
            ExtensionLogMethods.LogExtension(ex.Message, "", "HomeVM", "SelectCategory");
        }
    }

    [RelayCommand]
    public async Task SelectMainCategory(CategoryModel categoryModel)
    {
        try
        {
            await GetCategoriesByMainCategoryId(categoryModel.Id.ToString());
            //await NavigateToPage.OpenPage(new CategoriesPage(categoryModel));
        }
        catch (Exception ex)
        {
            ExtensionLogMethods.LogExtension(ex.Message, "", "HomeVM", "SelectMainCategory");
        }
    }

    [RelayCommand]
    public async Task SelectCategory(CategoryModel categoryModel)
    {
        try
        {
            await App.Current.MainPage.Navigation.PushModalAsync(new AllCoursesByCategoryPage(categoryModel));
        }
        catch (Exception ex)
        {
            ExtensionLogMethods.LogExtension(ex.Message, "", "HomeVM", "SelectCategory");
        }
    }


    /*[RelayCommand]
    public void SelectCategory(StCatgeory stCatgeory)
    {
        try
        {
            foreach (var item in Categories)
            {
                item.IsSelected = false;
            }
            stCatgeory.IsSelected = true;
        }
        catch (Exception ex)
        {
            ExtensionLogMethods.LogExtension(ex.Message, "", "HomeVM", "SelectCategory");
        }
    }

    [RelayCommand]
    public async Task SelectCourse(StCourse stCourse)
    {
        try
        {
            IsRunning = true;
            await NavigateToPage.OpenPage(new CourseDetailsPage());
        }
        catch (Exception ex)
        {
            ExtensionLogMethods.LogExtension(ex.Message, "", "HomeVM", "SelectCourse");
        }
        finally
        {
            IsRunning = false;
        }
    }

    [RelayCommand]
    public async Task EnrolCourse()
    {
        try
        {
            IsRunning = true;
            await NavigateToPage.OpenPage(new EnrollCoursePage());
        }
        catch (Exception ex)
        {
            ExtensionLogMethods.LogExtension(ex.Message, "", "HomeVM", "EnrolCourse");
        }
        finally
        {
            IsRunning = false;
        }
    }

    [RelayCommand]
    public async Task SelectedMentor()
    {
        try
        {
            IsRunning = true;
            await NavigateToPage.OpenPage(new MentorDetailsPage());
        }
        catch (Exception ex)
        {
            ExtensionLogMethods.LogExtension(ex.Message, "", "HomeVM", "SelectedMentor");
        }
        finally
        {
            IsRunning = false;
        }
    }

    [RelayCommand]
    public async Task TopMentors()
    {
        try
        {
            IsRunning = true;
            await NavigateToPage.OpenPage(new AllMentorsPage());
        }
        catch (Exception ex)
        {
            ExtensionLogMethods.LogExtension(ex.Message, "", "HomeVM", "TopMentors");
        }
        finally
        {
            IsRunning = false;
        }
    }

    [RelayCommand]
    public async Task OpenMostPopularCourses()
    {
        try
        {
            IsRunning = true;
            await NavigateToPage.OpenPage(new MostPopularCoursesPage());
        }
        catch (Exception ex)
        {
            ExtensionLogMethods.LogExtension(ex.Message, "", "HomeVM", "OpenMostPopularCourses");
        }
        finally
        {
            IsRunning = false;
        }
    }*/
    #endregion



}