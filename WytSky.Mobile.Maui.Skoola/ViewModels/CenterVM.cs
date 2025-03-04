using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using WytSky.Mobile.Maui.Skoola.AppResources;
using WytSky.Mobile.Maui.Skoola.Dtos;
using WytSky.Mobile.Maui.Skoola.Helpers;
using WytSky.Mobile.Maui.Skoola.Models;
using WytSky.Mobile.Maui.Skoola.Views.Courses;
using WytSky.Mobile.Maui.Skoola.Views.Quarni;
using WytSky.Mobile.Maui.Skoola.Views.Quarni.Centers;
using Settings = WytSky.Mobile.Maui.Skoola.Helpers.Settings;

namespace WytSky.Mobile.Maui.Skoola.ViewModels
{
    public partial class CenterVM : BaseViewModel
    {
        [ObservableProperty] private ObservableCollection<CentersModel> centers;

        [ObservableProperty] private ObservableCollection<StaffModel> staff;
    
        [ObservableProperty] private string complexId;
        [ObservableProperty] private string centerName;
        [ObservableProperty] private string centerNameEn;
        [ObservableProperty] private string address;
        
        #region Commands
        [RelayCommand]
        public async Task SelectParentCategory(CentersModel StaffModel)
        {
            try
            {
                /*foreach (var item in Staff)
                {
                    item.IsSelected = false;
                    item.TextColor = Colors.DimGray;
                    item.BackgroundColor = Colors.White;
                }
                StaffModel.IsSelected = true;
                StaffModel.TextColor = StringExtensions.ToColorFromResourceKey("White");
                StaffModel.BackgroundColor = StringExtensions.ToColorFromResourceKey("PrimaryColor");*/
                
                App.Current.MainPage.Navigation.PushAsync(new StaffPage(StaffModel.CenterID.ToString()));
            }
            catch (Exception ex)
            {
                ExtensionLogMethods.LogExtension(ex.Message, "", "HomeVM", "SelectCategory");
            }
        }
        public async Task GetCenters()
           {
               try
               {
                   IsRunning = true;
                   Centers = await APIs.ServiceCenter.GetCenter(ComplexId);
                   if (Centers != null && Centers.Count > 0)
                   {
                       Centers[0].TextColor = StringExtensions.ToColorFromResourceKey("White");
                       Centers[0].BackgroundColor = StringExtensions.ToColorFromResourceKey("PrimaryColor");
                       //await GetMainCategoriesByParentCategoryId(Complexes[0].Id.ToString()); Navigate to Masajid page
                   }
                   IsRunning = false;
               }
               catch (Exception ex)
               {
                   ExtensionLogMethods.LogExtension(ex, "", "", "GetCenters");
               }
        }
        
        [RelayCommand]
        public async Task AddCenter()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(CenterName))
                {
                   Toast.ShowToastError("Error", "يجب إدخال إسم المسجد");
                    return;
                }

                IsRunning = true;

                // Create form data dictionary
                var formData = new Dictionary<string, object>
                {
                    { "CenterName", CenterName },
                    { "CenterNameEn", CenterNameEn },
                    { "ComplexID" ,ComplexId },
                    { "Address", Address}
                };

                // Call the AddComplex service method
                var result = await APIs.ServiceCenter.AddCenter(formData);

                if (result != null)
                {
                    HidePopup();
                    Toast.ShowToastSuccess(SharedResources.AddedSuccessfully);
                    await GetCenters();
                }
                else
                {
                    Toast.ShowToastError("");
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
        public async Task OpenAddCenter()
        {
            var popup = new AddCenter();
            popup.BindingContext = this;
            ShowPopup(popup);
        }
        #endregion
    }
}
