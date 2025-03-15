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
    public partial class CenterVM : ComplexesVM
    {
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



        #region Methods
        public async Task GetCenters()
        {
            try
            {
                IsRunning = true;
                Centers = await APIs.ServiceCenter.GetCenter();
                FilteredCenters = new ObservableCollection<CentersModel>(Centers);
                //ComplexNamee = Centers.Select(_ => _.ComplexName).FirstOrDefault();
                //ComplexRegionName = Centers.Select(_ => _.ComplexRegionName).FirstOrDefault();
                //ComplexRegionCountryName = Centers.Select(_ => _.ComplexRegionCountryName).FirstOrDefault();
                //CountryName = Centers.Select(_ => _.ComplexRegionCountryName).FirstOrDefault();
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
            Settings.CenterId = centerModel.CenterID.ToString();
            //string name = App.IsArabic ? centerModel.CenterName : centerModel.CenterNameEn;
            await OpenPushAsyncPage(new StudyGroupsPage(centerModel));
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
            await OpenPushAsyncPage(new StudentsPage(centerModel));
        }
        #endregion
    }
}
