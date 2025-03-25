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
    public partial class StaffVM : CenterVM
    {
        [ObservableProperty] public ObservableCollection<StaffModel> staff = new ObservableCollection<StaffModel>();
        [ObservableProperty] private ObservableCollection<StaffModel> filteredStaff = new ObservableCollection<StaffModel>();
        [ObservableProperty] private ObservableCollection<CentersModel> centers;
        [ObservableProperty] private string searchText;
        [ObservableProperty] public string firstName;
        [ObservableProperty] public string lastName;
        [ObservableProperty] public string staffName;
        [ObservableProperty] public string userName;
        [ObservableProperty] public string password;
        [ObservableProperty] public string mobile;
        [ObservableProperty] public string email;
        [ObservableProperty] public StaffTypeModel selectedStaffType = new();
        [ObservableProperty] public CentersModel selectedCenter= new();


        #region Methods
        public async Task GetCenters()
        {
            try
            {
                IsRunning = true;
                Centers = await APIs.ServiceCenter.GetCenter();
                ComplexNamee = Centers.Select(_ => _.ComplexName).FirstOrDefault();
                ComplexRegionName = Centers.Select(_ => _.ComplexRegionName).FirstOrDefault();
                CenterName = Centers.Select(_ => _.CenterName).FirstOrDefault();
                IsRunning = false;
            }
            catch (Exception ex)
            {
                ExtensionLogMethods.LogExtension(ex, "", "CenterVM", "GetCenters");
            }
        }
        public async Task GetStaff()
        {
            try
            {
                IsRunning = true;
                Staff = await APIs.ServiceStaff.GetStaffByCenterId();
                FilteredStaff= new ObservableCollection<StaffModel>(Staff);

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
        partial void OnSearchTextChanging(string value)
        {
            try
            {
                if (!string.IsNullOrEmpty(value))
                {
                    FilteredStaff=
                        new ObservableCollection<StaffModel>(Staff.Where(x => x.FullName.ToLower().Contains(value)).ToList());
                }
                else
                {
                    FilteredStaff = Staff;
                }
            }
            catch (Exception ex)
            {
                ExtensionLogMethods.LogExtension(ex, "", "StaffVM", "OnSearchTextChanging");
            }
        }
        #endregion

        //[RelayCommand]
        //public async Task SelectStaff(StaffModel staff)
        //{
        //    Settings.StaffId = staff.StaffID.ToString();
        //    await OpenPushAsyncPage(new StudyGroupsPage(staff.StaffID.ToString()));
        //}

        [RelayCommand]
        public void OpenAddStaff()
        {
           
            var popup = new AddStaff();
            popup.BindingContext = this;
            ShowPopup(popup);
        }
         
        [RelayCommand]
        public void OpenEditStaff(StaffModel model)
        {
            if (model == null)
                return; 
            Settings.StaffId = model.StaffID.ToString();

            FirstName = model.FirstName;
            LastName = model.LastName;
            UserName = model.UserName;
            Password = model.Password;
            Mobile = model.Mobile;
            Email = model.Email;
            SelectedCenter = Centers.FirstOrDefault(x => x.CenterID == model.CenterID);
            SelectedStaffType = StaffTypes.FirstOrDefault(x => x.StaffTypeID == model.StaffTypeID);

            var popup = new EditStaff();
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
                    { "LastName", LastName },
                    { "FullName", $"{FirstName} {LastName}"},
                    { "CenterID" , SelectedCenter.CenterID },
                    { "CenterName" , SelectedCenter.CenterName },
                    { "StaffTypeID" , SelectedStaffType.StaffTypeID },
                    //{ "StaffTypeName" , SelectedStaffType.TypeName },
                    { "UserName" , UserName },
                    { "Password", Password},
                    { "Mobile" , Mobile}, 
                    { "Email" , Email}, 
                    { "IsActive" , true}, 

                };
                var result = await APIs.ServiceStaff.AddStaff(formData);

                var exsistStudyGroups = await APIs.StudyGroupService.GetStudyGroupsByCenterId();

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

        [RelayCommand]
        public async Task EditStaff()
        {
            try
            {
                IsRunning = true;

                var formData = new Dictionary<string, object>
                {
                    { "FirstName", FirstName },
                    { "LastName", LastName },
                    { "FullName", $"{FirstName} {LastName}"},
                    { "CenterID" , SelectedCenter.CenterID },
                    { "StaffTypeID" , SelectedStaffType.StaffTypeID },
                    { "UserName" , UserName },
                    { "Password", Password},
                    { "Mobile" , Mobile}, 
                    { "Email" , Email} 
                  

                };
                var result = await APIs.ServiceStaff.UpdateStaff(formData);

                var exsistStudyGroups = await APIs.StudyGroupService.GetStudyGroupsByCenterId();

                if (result != null)
                {
                    Toast.ShowToastSuccess(SharedResources.UpdatedSuccessfully);
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