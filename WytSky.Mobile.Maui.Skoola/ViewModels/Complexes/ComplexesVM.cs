
using System.Collections.ObjectModel;
using System.Globalization;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WytSky.Mobile.Maui.Skoola.AppResources;
using WytSky.Mobile.Maui.Skoola.Helpers;
using WytSky.Mobile.Maui.Skoola.Models;
using WytSky.Mobile.Maui.Skoola.Views.Centers;
using WytSky.Mobile.Maui.Skoola.Views.Complexes;
using Settings = WytSky.Mobile.Maui.Skoola.Helpers.Settings;

namespace WytSky.Mobile.Maui.Skoola.ViewModels;

public partial class ComplexesVM : BaseViewModel
{
    #region Properties
    [ObservableProperty]
    public ObservableCollection<ComplexModel> complexes = new ObservableCollection<ComplexModel>();

    [ObservableProperty]
    public string complexName;

    [ObservableProperty]
    public string complexId;

    [ObservableProperty]
    public CountryModel selectedCountry;

    [ObservableProperty]
    public RegionModel selectedRegion;

    [ObservableProperty]
    private bool isCountryPopupVisible;

    [ObservableProperty]
    private bool isRegionPopupVisible;
    #endregion

    #region Methods
    public async Task GetComplexs()
    {
        try
        {
            IsRunning = true;
            Complexes = await APIs.ServiceCatgeory.GetComplexs();
            IsRunning = false;
        }
        catch (Exception ex)
        {
            ExtensionLogMethods.LogExtension(ex, "", "ComplexesVM", "GetParentCategories");
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

            if (string.IsNullOrEmpty(SelectedCountry.CountryName))
            {
                Toast.ShowToastError("Error", "Select Country");
                return;
            }

            if (string.IsNullOrEmpty(SelectedRegion.RegionName))
            {
                Toast.ShowToastError("Error", "Selecte Region");
                return;
            }

            IsRunning = true;

            var formData = new Dictionary<string, object>
            {
                { "ComplexName", ComplexName },
                { "CountryID", SelectedCountry.CountryID },
                { "RegionID", SelectedRegion.RegionID},
                { "IsActive", true},

                //{ "SupervisorID", Settings.UserId }
            };

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
            ExtensionLogMethods.LogExtension(ex, "", "ComplexesVM", "AddComplex");
            Toast.ShowToastError("Error", "An unexpected error occurred");
        }
        finally
        {
            IsRunning = false;
        }
    }

    [RelayCommand]
    private async Task OpenAddComplex()
    {
        try
        {
            var popup = new AddComplex();
            await GetCountries();
            //if (Countries.Count > 0)
            //await GetRegions(Countries[0].CountryID.ToString());
            popup.BindingContext = this;
            ShowPopup(popup);
        }
        catch (Exception ex)
        {
            string er = ex.Message;
        }
    }

    [RelayCommand]
    public async Task SelectComplex(ComplexModel complexModel)
    {
        try
        {
            Settings.ComplexId = complexModel.ComplexID.ToString();
            await OpenPushAsyncPage(new CenterPage(complexModel));
        }
        catch (Exception ex)
        {
            ExtensionLogMethods.LogExtension(ex.Message, "", "ComplexesVM", "SelectComplex");
        }
    }
    private async Task LoadRegions(string countryId)
    {
        if (_cachedRegions.ContainsKey(countryId))
        {
            //Regions.Clear();
            //foreach (var region in _cachedRegions[countryId])
            //{
            //    Regions.Add(region);
            //}
            return;
        }
        var regions = await APIs.ServiceCountriesRegions.GetRegions(countryId);
        _cachedRegions[countryId] = regions.ToList();

        Regions.Clear();
        foreach (var region in regions)
        {
            Regions.Add(region);
        }
    }
    public void ClearRegionCache()
    {
        _cachedRegions.Clear();
        Regions.Clear();
    }

    partial void OnSelectedCountryChanged(CountryModel value)
    {
        //await GetRegions(SelectedCountry.CountryID.ToString());
        //SelectedCountry = value;
        if (value != null)
        {
            // Load regions for the selected country
            LoadRegions(value.CountryID.ToString());
        }
    }
    partial void OnSelectedRegionChanged(RegionModel value)
    {
        SelectedRegion = value;
    }
    #endregion
}