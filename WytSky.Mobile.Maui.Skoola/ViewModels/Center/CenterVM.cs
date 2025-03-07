using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using WytSky.Mobile.Maui.Skoola.AppResources;
using WytSky.Mobile.Maui.Skoola.Helpers;
using WytSky.Mobile.Maui.Skoola.Models;
using WytSky.Mobile.Maui.Skoola.Views.Centers;
using WytSky.Mobile.Maui.Skoola.Views.Staff;
using WytSky.Mobile.Maui.Skoola.Views.Students;
using WytSky.Mobile.Maui.Skoola.Views.StudyGroups;

namespace WytSky.Mobile.Maui.Skoola.ViewModels
{
    public partial class CenterVM : BaseViewModel
    {
        [ObservableProperty] private ObservableCollection<CentersModel> centers;
        [ObservableProperty] private string centerName;
        [ObservableProperty] private string centerNameEn;
        [ObservableProperty] private string address;
        [ObservableProperty] private string ditrictName;
        [ObservableProperty] private string cityName;
        [ObservableProperty] private string phone;
        [ObservableProperty] private string email;
        [ObservableProperty] private string notes;
        public async Task GetCenters()
        {
            try
            {
                IsRunning = true;
                Centers = await APIs.ServiceCenter.GetCenter();
                IsRunning = false;
            }
            catch (Exception ex)
            {
                ExtensionLogMethods.LogExtension(ex, "", "CenterVM", "GetCenters");
            }
        }

        #region Commands
        [RelayCommand]
        public async Task SelectCenter(CentersModel centerModel)
        {
            try
            {
                Settings.CenterId = centerModel.CenterID.ToString();
                await OpenPushAsyncPage(new StaffPage(centerModel));
            }
            catch (Exception ex)
            {
                ExtensionLogMethods.LogExtension(ex.Message, "", "CenterVM", "SelectCenter");
            }
        }

        [RelayCommand]
        public void OpenAddCenter()
        {
            var popup = new AddCenter();
            popup.BindingContext = this;
            ShowPopup(popup);
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

                var formData = new Dictionary<string, object>
                {
                    { "CenterName", CenterName },
                    { "CenterNameEn", CenterNameEn },
                    { "ComplexID" , Settings.ComplexId },
                    { "SupervisorID" ,Settings.UserId },
                    { "isActive" ,true },
                    { "Address", Address},
                    { "ComplexRegionName" ,DitrictName },
                    { "City" ,CityName },
                    { "Phone" ,Phone },
                    { "Email" ,Email },
                    { "Notes" ,Notes },
                };

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
                ExtensionLogMethods.LogExtension(ex, "", "CenterVM", "AddComplex");
                Toast.ShowToastError("Error", "An unexpected error occurred");
            }
            finally
            {
                IsRunning = false;
            }
        }

        [RelayCommand]
        public async Task OpenStudyGroups(CentersModel centerModel)
        {
            Settings.CenterId = centerModel.CenterID.ToString();
            string name = App.IsArabic ? centerModel.CenterName : centerModel.CenterNameEn;
            await OpenPushAsyncPage(new StudyGroupsPage(name));
        }

        [RelayCommand]
        public async Task OpenStaffs(CentersModel centerModel)
        {
            Settings.CenterId = centerModel.CenterID.ToString();
            await OpenPushAsyncPage(new StaffPage(centerModel));
        }

        [RelayCommand]
        public async Task OpenStudents(CentersModel centerModel)
        {
            Settings.CenterId = centerModel.CenterID.ToString();
            string name = App.IsArabic ? centerModel.CenterName : centerModel.CenterNameEn;
            await OpenPushAsyncPage(new StudentsPage(name));
        }
        #endregion
    }
}
