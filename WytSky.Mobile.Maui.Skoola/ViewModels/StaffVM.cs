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
using WytSky.Mobile.Maui.Skoola.Views.Quarni.Staff;
using WytSky.Mobile.Maui.Skoola.Views.Quarni.StudyGroups;
using Settings = WytSky.Mobile.Maui.Skoola.Helpers.Settings;

namespace WytSky.Mobile.Maui.Skoola.ViewModels
{
    public partial class StaffVM : BaseViewModel
    {
        [ObservableProperty]
        public ObservableCollection<StaffModel> staff = new ObservableCollection<StaffModel>();


        [ObservableProperty] public string firstName;
        [ObservableProperty] public string lastName;
        [ObservableProperty] public string staffName;
        [ObservableProperty] private string centerID;


        #region Methods
        public async Task GetStaff()
        {
            try
            {
                IsRunning = true;
                Staff = await APIs.ServiceStaff.GetStaff(CenterID);
                if (Staff != null && Staff.Count > 0)
                {
                    Staff[0].TextColor = StringExtensions.ToColorFromResourceKey("White");
                    Staff[0].BackgroundColor = StringExtensions.ToColorFromResourceKey("PrimaryColor");
                }
            }
            catch (Exception ex)
            {
                ExtensionLogMethods.LogExtension(ex, "", "", "GetCenters");
            }
            finally
            {
                IsRunning = false;
            }
        }

        [RelayCommand]
        public void SelectStaff(StaffModel staff)
        {
            App.Current.MainPage.Navigation.PushAsync(new StudyGroupsPage(staff.StaffID.ToString(),CenterID));
        }
        
        [RelayCommand]
        public void OpenAddStaff()
        {
            var popup = new AddStaff();
            popup.BindingContext = this;
            ShowPopup(popup);
        }
        #endregion

        [RelayCommand]
        public async Task AddStaff()
        {
            try
            {

                IsRunning = true;

                // Create form data dictionary
                var formData = new Dictionary<string, object>
                {
                    { "FirstName", firstName },
                    { "LastNme", lastName },
                    { "CenterID" ,CenterID },
                };

                // Call the AddComplex service method
                var result = await APIs.ServiceCenter.AddCenter(formData);

                if (result != null)
                {
                    HidePopup();
            //        Toast.ShowToastSuccess(SharedResources.AddedSuccessfully);
                    await GetStaff();
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

    }
}
