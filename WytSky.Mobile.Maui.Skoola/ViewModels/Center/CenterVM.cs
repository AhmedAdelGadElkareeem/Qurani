using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Diagnostics;
using WytSky.Mobile.Maui.Skoola.APIs;
using WytSky.Mobile.Maui.Skoola.AppResources;
using WytSky.Mobile.Maui.Skoola.Helpers;
using WytSky.Mobile.Maui.Skoola.Models;
using WytSky.Mobile.Maui.Skoola.Views.Centers;
using WytSky.Mobile.Maui.Skoola.Views.Staff;
using WytSky.Mobile.Maui.Skoola.Views.Students;
using WytSky.Mobile.Maui.Skoola.Views.StudyGroups;

namespace WytSky.Mobile.Maui.Skoola.ViewModels
{
    public partial class CenterVM : ComplexesVM
    {
        //[ObservableProperty] private ObservableCollection<StudentModel> students;

        [ObservableProperty] private ObservableCollection<CentersModel> centers;
        [ObservableProperty] private ObservableCollection<CentersModel> filteredCenters= new ObservableCollection<CentersModel>();
        [ObservableProperty] private string searchText;
        [ObservableProperty] private string centerNameEn;
        [ObservableProperty] private string address;
        [ObservableProperty] private string ditrictName;
        [ObservableProperty] private string cityName;
        [ObservableProperty] private string phone;
        [ObservableProperty] private string email;
        [ObservableProperty] private string notes;

        [ObservableProperty] private string countryName;
        [ObservableProperty] public string complexNamee;
        [ObservableProperty] public string complexRegionName;
        [ObservableProperty] public string complexRegionCountryName;
        [ObservableProperty] public string centerName;
        [ObservableProperty] public string studentCenterName;
        [ObservableProperty] public string groupName;
        [ObservableProperty] public string teacherFullName;
        [ObservableProperty] public bool fromMainPage = false;



        #region Methods
        public async Task GetCenters()
        {
            try
            {
                IsRunning = true;
                if (FromMainPage)
                {
                    Centers = await APIs.ServiceCenter.GetCenters();
                    FilteredCenters = new ObservableCollection<CentersModel>(Centers);
                }
                else
                {
                    Centers = await APIs.ServiceCenter.GetCenter();
                    FilteredCenters = new ObservableCollection<CentersModel>(Centers);
                }
                IsRunning = false;
            }
            catch (Exception ex)
            {
                ExtensionLogMethods.LogExtension(ex, "", "CenterVM", "GetCenters");
            }
        }
        partial void OnSearchTextChanging(string value)
        {
            try
            {
                if (!string.IsNullOrEmpty(value) || value.Length > 0)
                {
                    FilteredCenters =
                        new ObservableCollection<CentersModel>(Centers.Where(x => x.CenterName.ToLower().Contains(value)).ToList());
                }
                else
                {
                    FilteredCenters =   Centers;
                }
            }
            catch (Exception ex)
            {
                ExtensionLogMethods.LogExtension(ex, "", "CenterVM", "OnSearchTextChanging");
            }
        }
        #endregion

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
            try
            {
                var popup = new AddCenter();
                popup.BindingContext = this;
                ShowPopup(popup);
            }
            catch (Exception ex)
            {
                ExtensionLogMethods.LogExtension(ex, "", "CenterVM", "OpenAddCenter");
            }
        }

         [RelayCommand]
        public void OpenEditCenter(CentersModel model)
        {
            try
            {
               Settings.CenterId = model.CenterID.ToString();
                CenterName = model.CenterName;
                CenterNameEn =model.CenterNameEn;
                Address = model.Address;
                CityName = model.City;
                Phone = model.Phone;
                Email = model.Email;
                Notes = model.Notes;
                ComplexId = model.ComplexID.ToString();

                var popup = new EditCenter();
                popup.BindingContext = this;
                ShowPopup(popup);
            }
            catch (Exception ex)
            {
                ExtensionLogMethods.LogExtension(ex, "", "CenterVM", "OpenEditCenter");
            }
        }

        [RelayCommand]
        public async Task EditCenter()
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
                    { "Address", Address},
                    { "City" ,CityName },
                    { "Phone" ,Phone },
                    { "Email" ,Email },
                    { "Notes" ,Notes },
                };

                var result = await APIs.ServiceCenter.UpdateCenter(formData);
                if (result != null)
                {
                    HidePopup();
                    Toast.ShowToastSuccess(SharedResources.UpdatedSuccessfully);
                    await GetCenters();
                }
                else
                {
                    Toast.ShowToastError("Error", "Failed to update complex");
                }
            }
            catch (Exception ex)
            {
                ExtensionLogMethods.LogExtension(ex, "", "CenterVM", "EditCenter");
                Toast.ShowToastError("Error", "An unexpected error occurred");
            }
            finally
            {
                IsRunning = false;
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

                var formData = new Dictionary<string, object>
                {
                    { "CenterName", CenterName },
                    { "CenterNameEn", CenterNameEn },
                    { "ComplexID" , Settings.ComplexId },
                    { "isActive" ,true },
                    { "Address", Address},
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
            try
            {
                Settings.CenterId = centerModel.CenterID.ToString();
                //string name = App.IsArabic ? centerModel.CenterName : centerModel.CenterNameEn;
                await OpenPushAsyncPage(new StudyGroupsPage(centerModel));
            }
            catch (Exception ex)
            {
                ExtensionLogMethods.LogExtension(ex, "", "CenterVM", "OpenStudyGroups");
            }
        }

        [RelayCommand]
        public async Task OpenStaffs(CentersModel centerModel)
        {
            try
            {
                Settings.CenterId = centerModel.CenterID.ToString();
                await OpenPushAsyncPage(new StaffPage(centerModel));
            }
            catch (Exception ex)
            {
                ExtensionLogMethods.LogExtension(ex, "", "CenterVM", "OpenStaffs");
            }
        }

        [RelayCommand]
        public async Task OpenStudents(CentersModel centerModel)
        {
            try
            {
                Settings.CenterId = centerModel.CenterID.ToString();
                await OpenPushAsyncPage(new StudentsPage(centerModel));
            }
            catch (Exception ex)
            {
                ExtensionLogMethods.LogExtension(ex, "", "CenterVM", "OpenStudents");
            }
        }
        #endregion
    }
}
