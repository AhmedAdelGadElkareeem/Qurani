using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using WytSky.Mobile.Maui.Skoola.AppResources;
using WytSky.Mobile.Maui.Skoola.Helpers;
using WytSky.Mobile.Maui.Skoola.Models;
using WytSky.Mobile.Maui.Skoola.Views.Staff;
using WytSky.Mobile.Maui.Skoola.Views.StudyGroups;

namespace WytSky.Mobile.Maui.Skoola.ViewModels
{
    public partial class StaffVM : BaseViewModel
    {
        [ObservableProperty] public ObservableCollection<StaffModel> staff = new ObservableCollection<StaffModel>();
        [ObservableProperty] public string firstName;
        [ObservableProperty] public string lastName;
        [ObservableProperty] public string staffName;

        #region Methods
        public async Task GetStaff()
        {
            try
            {
                IsRunning = true;
                Staff = await APIs.ServiceStaff.GetStaff();
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
        #endregion

        [RelayCommand]
        public async Task SelectStaff(StaffModel staff)
        {
            Settings.StaffId = staff.StaffID.ToString();
            var baseModel = new BaseModel()
            {
                NameAr = staff.FullName,
                NameEn = staff.FullName,
            };
            await OpenPushAsyncPage(new StudyGroupsPage(baseModel));
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
                    { "CenterID" , Settings.CenterId },
                };

                var result = await APIs.ServiceStaff.AddStaff(formData);
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