
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WytSky.Mobile.Maui.Skoola.AppResources;
using WytSky.Mobile.Maui.Skoola.Dtos;
using WytSky.Mobile.Maui.Skoola.Helpers;
using WytSky.Mobile.Maui.Skoola.Models;
using WytSky.Mobile.Maui.Skoola.Views.Courses;
using WytSky.Mobile.Maui.Skoola.Views.Quarni;
using WytSky.Mobile.Maui.Skoola.Views.Quarni.Complexes;
using Settings = WytSky.Mobile.Maui.Skoola.Helpers.Settings;

namespace WytSky.Mobile.Maui.Skoola.ViewModels;

public partial class HomeVM : BaseViewModel
{
    #region Properties
    [ObservableProperty]
    public ObservableCollection<ComplexModel> complexes = new ObservableCollection<ComplexModel>();

    [ObservableProperty]
    string userName;
    #endregion

    [ObservableProperty]
    public string complexName ;
    
    [ObservableProperty]
    public string complexId ;
    

    #region Constructor
    public HomeVM()
    {
        UserName = Settings.UserName;
    }
    #endregion

    #region Methods
    public async Task GetComplexs()
    {
        try
        {
            IsRunning = true;
            Complexes = await APIs.ServiceCatgeory.GetComplexs();
            if (Complexes != null && Complexes.Count > 0)
            {
                Complexes[0].TextColor = StringExtensions.ToColorFromResourceKey("White");
                Complexes[0].BackgroundColor = StringExtensions.ToColorFromResourceKey("PrimaryColor");
            }
            IsRunning = false;
        }
        catch (Exception ex)
        {
            ExtensionLogMethods.LogExtension(ex, "", "", "GetParentCategories");
        }
    }
    #endregion

    #region Commands
    
    [RelayCommand]
    public async Task AddComplex()
    {
        try
        {
            if (string.IsNullOrWhiteSpace(ComplexName))
            {
               Toast.ShowToastError("Error", "Complex name cannot be empty");
                return;
            }

            IsRunning = true;

            // Create form data dictionary
            var formData = new Dictionary<string, object>
            {
                { "ComplexName", ComplexName }
            };

            // Call the AddComplex service method
            var result = await APIs.ServiceCatgeory.AddComplex(formData);

            if (result != null)
            {
                HidePopup();
                Toast.ShowToastSuccess(SharedResources.AddedSuccessfully);
                await GetComplexs();
            }
            else
            {
                Toast.ShowToastError("Error", "Failed to add complex");
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
    private void OpenAddComplex()
    {
        var popup = new AddComplex();
        popup.BindingContext = this;
        ShowPopup(popup);
    }

    [RelayCommand]
    public async Task SelectParentCategory(ComplexModel complexModel)
    {
        try
        {
            /*foreach (var item in Complexes)
            {
                item.IsSelected = false;
                item.TextColor = Colors.DimGray;
                item.BackgroundColor = Colors.White;
            }

            complexModel.IsSelected = true;
            complexModel.TextColor = StringExtensions.ToColorFromResourceKey("White");
            complexModel.BackgroundColor = StringExtensions.ToColorFromResourceKey("PrimaryColor");*/
            ComplexId = complexModel.ComplexID.ToString();
            await App.Current.MainPage.Navigation.PushAsync(new CenterPage(ComplexId));
        }

        catch (Exception ex)
        {
            ExtensionLogMethods.LogExtension(ex.Message, "", "HomeVM", "SelectCategory");
        }
    }
    #endregion
}