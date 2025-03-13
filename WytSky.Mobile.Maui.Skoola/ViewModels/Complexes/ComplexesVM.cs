
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
    private ObservableCollection<ComplexModel> filteredComplexes = new ObservableCollection<ComplexModel>();

    [ObservableProperty]
    public string complexName;

    [ObservableProperty]
    public string complexId;

    [ObservableProperty]
    public CountryModel selectedCountry;

    [ObservableProperty]
    public RegionModel selectedRegion;

    [ObservableProperty]
    private string searchText;

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
            FilteredComplexes = new ObservableCollection<ComplexModel>(Complexes);
            IsRunning = false;
        }
        catch (Exception ex)
        {
            ExtensionLogMethods.LogExtension(ex, "", "ComplexesVM", "GetParentCategories");
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
    partial void OnSearchTextChanging(string value)
    {
        try
        {
            if (!string.IsNullOrEmpty(value) || value.Length > 0)
            {
                FilteredComplexes =
                    new ObservableCollection<ComplexModel>(Complexes.Where(x => x.ComplexName.ToLower().Contains(value)).ToList());
            }
            else
            {
                FilteredComplexes = Complexes;
            }

        }
        catch (Exception ex)
        {
            ExtensionLogMethods.LogExtension(ex, "", "AddVisitVM", "OnSearchTextChanging");
        }
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

    [RelayCommand]
    private void ClearText()
    {
        SearchText = string.Empty;
    }

    [RelayCommand(CanExecute = nameof(CanExecute))]
    private async Task Search()
    {
        try
        {
            IsRunning = true;
            if (SearchText == null)
                return;
            // Filter the complexes based on SearchText
            if (string.IsNullOrWhiteSpace(SearchText))
            {
                // If SearchText is empty, show all complexes
                FilteredComplexes = new ObservableCollection<ComplexModel>(Complexes);
            }
            else
            {
                // Filter complexes that contain the SearchText (case-insensitive)
                var filtered = Complexes
                    .Where(c => c.ComplexName.Contains(SearchText, StringComparison.OrdinalIgnoreCase))
                    .ToList();

                FilteredComplexes = new ObservableCollection<ComplexModel>(filtered);
            }
        }
        catch (Exception ex)
        {
            ExtensionLogMethods.LogExtension(ex, "", "AllVisitVM", "Search");
        }
        finally
        {
            IsRunning = false;
        }
    }

    #endregion
}