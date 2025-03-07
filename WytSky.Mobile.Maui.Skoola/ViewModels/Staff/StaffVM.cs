using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using WytSky.Mobile.Maui.Skoola.AppResources;
using WytSky.Mobile.Maui.Skoola.Helpers;
using WytSky.Mobile.Maui.Skoola.Models;
using WytSky.Mobile.Maui.Skoola.Views.Staff;
using WytSky.Mobile.Maui.Skoola.Views.StudyGroups;
using static Microsoft.Maui.ApplicationModel.Permissions;

namespace WytSky.Mobile.Maui.Skoola.ViewModels
{
    public partial class StaffVM : BaseViewModel
    {
        [ObservableProperty] public ObservableCollection<StaffModel> staff = new ObservableCollection<StaffModel>();
        [ObservableProperty] public ObservableCollection<StaffTypeModel> staffTypes = new ObservableCollection<StaffTypeModel>();
        [ObservableProperty] public string firstName;
        [ObservableProperty] public string lastName;
        [ObservableProperty] public string staffName;
        [ObservableProperty] public string userName;
        [ObservableProperty] public string password;
        [ObservableProperty] public string mobile;
        [ObservableProperty] public string email;
        [ObservableProperty] public StaffTypeModel selectedStaffType;

        #region Methods
        public async Task GetStaff()
        {
            try
            {
                IsRunning = true;
                Staff = await APIs.ServiceStaff.GetCenterStaff();
            }
            catch (Exception ex)
            {
                ExtensionLogMethods.LogExtension(ex, "", "StaffVM", "GetStaff");
            }
            finally
            {
                IsRunning = false;
            }
        }

        partial void OnSelectedStaffTypeChanged(StaffTypeModel value)
        {
            SelectedStaffType = value;
        }
        #endregion

        [RelayCommand]
        public async Task SelectStaff(StaffModel staff)
        {
            Settings.StaffId = staff.StaffID.ToString();
            await OpenPushAsyncPage(new StudyGroupsPage(staff.FullName));
        }

        [RelayCommand]
        public void OpenAddStaff()
        {
            var popup = new AddStaff();
            popup.BindingContext = this;
            ShowPopup(popup);
        }

        [RelayCommand]
        public async Task AddStaff()
        {
            try
            {
                IsRunning = true;

                var formData = new Dictionary<string, object>
                {
                    { "FirstName", FirstName },
                    { "LastNme", LastName },
                    { "FullName", $"{FirstName} {LastName}"},
                    { "CenterID" , Settings.CenterId },
                    { "StaffTypeName" , SelectedStaffType},
                    { "UserName" , UserName },
                    { "Password", Password},
                    { "Mobile" , Mobile}, 
                    { "Email" , Email}, 
                    { "IsActive" , true}, 

                };
                var result = await APIs.ServiceStaff.AddStaff(formData);

                var exsistStudyGroups = await APIs.StudyGroupService.GetStudyGroups();

                if (result != null)
                {
                    Toast.ShowToastSuccess(SharedResources.AddedSuccessfully);
                    await GetStaff();
                }
                else
                {
                    Toast.ShowToastError("Error");
                }
            }
            catch (Exception ex)
            {
                Toast.ShowToastError("Error", ex.Message);
            }
            finally
            {
                IsRunning = false;
                HidePopup();
            }
        }
      
    }
}