using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WytSky.Mobile.Maui.Skoola.APIs;
using WytSky.Mobile.Maui.Skoola.AppResources;
using WytSky.Mobile.Maui.Skoola.Helpers;
using WytSky.Mobile.Maui.Skoola.Models;
using WytSky.Mobile.Maui.Skoola.ViewModels.Students;
using WytSky.Mobile.Maui.Skoola.ViewModels.StudyGroupSession;
using WytSky.Mobile.Maui.Skoola.Views.Schedules;
using WytSky.Mobile.Maui.Skoola.Views.StudyGroupSessions;

namespace WytSky.Mobile.Maui.Skoola.ViewModels.Schedules
{
    public partial class SchedulesVM : StudyGroupStudentListVM
    {
        #region Properties
        [ObservableProperty] private ObservableCollection<ScheduleModel> schedules;
        [ObservableProperty] private ScheduleModel schedule = new ScheduleModel();
        [ObservableProperty] private ObservableCollection<ScheduleModel> filteredSchedules = new ObservableCollection<ScheduleModel>();

        [ObservableProperty] private ObservableCollection<string> daysOfWeek;
        [ObservableProperty] private string searchText;

        [ObservableProperty] public ScheduleModel selectedSchedule = new ScheduleModel();

        [ObservableProperty] private string selectedDay; // Selected day from Picker

        [ObservableProperty] private TimeSpan startTime;

        [ObservableProperty] private TimeSpan endTime;
        #endregion

        // Store StartTime as string in "HH:mm:ss" format

        #region Contractor
        public SchedulesVM()
        {
            if (App.IsArabic)
            {
                DaysOfWeek = new ObservableCollection<string>
                {
                    "الأحد", "الإثنين", "الثلاثاء", "الأربعاء", "الخميس", "الجمعة", "السبت"
                };
            }
            else
            {
                DaysOfWeek = new ObservableCollection<string>
                {
                    "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"
                };
                SelectedDay = DaysOfWeek[0];
                StartTime = new TimeSpan(9, 0, 0);  // 9:00 AM
                EndTime = new TimeSpan(17, 0, 0);   // 5:00 PM
            }
        }
        #endregion

        #region Methods
        public async Task GetSchedules()
        {
            try
            {
                IsRunning = true;
                Schedules = await APIs.ServiceSchedule.GetScheduleGroup();
                GroupName = Schedules.Where(_ => _.GroupID == int.Parse(Settings.StudyGroupId)).Select(_ => _.GroupName).FirstOrDefault().ToString();
                ComplexNamee = Schedules.Select(_ => _.GroupCenterComplexName).FirstOrDefault().ToString();
                CenterName = Schedules.Select(_ => _.GroupCenterName).FirstOrDefault().ToString();
                //Schedules = fetchedSchedules ?? new ObservableCollection<ScheduleModel>();
                FilteredSchedules = new ObservableCollection<ScheduleModel>(Schedules);

            }
            catch (Exception ex)
            {
                ExtensionLogMethods.LogExtension(ex, "", "SchedulesVM", "GetSchedules");
                Toast.ShowToastError("Error fetching schedules.");
            }
            finally
            {
                IsRunning = false;
            }
        }
        partial void OnSearchTextChanging(string value)
        {
            try
            {
                if (!string.IsNullOrEmpty(value) || value.Length > 0)
                {
                    FilteredSchedules =
                        new ObservableCollection<ScheduleModel>(Schedules.Where(x => x.DayOfWeekName.ToLower().Contains(value)).ToList());
                }
                else
                {
                    FilteredSchedules = Schedules;
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
        public async Task AddSchedule()
        {
            try
            {
               if (string.IsNullOrWhiteSpace(SelectedDay.ToString()))
               {
                   Toast.ShowToastError("Error", "يرجي إختيار وقت  للحلقة");
                   return;
               }

                IsRunning = true;

                var formData = new Dictionary<string, object>
                {               
                    { "StartTime", StartTime.ToString(@"hh\:mm\:ss") },
                    { "EndTime", EndTime.ToString(@"hh\:mm\:ss") },
                    { "GroupID", Settings.StudyGroupId },
                    { "IsActive", true },
                    { "WeekDayNameListDayOfWeekName", SelectedDay },
                    { "DayOfWeekName", SelectedDay },


                
                };

                var result = await APIs.ServiceSchedule.AddScheduleGroup(formData);
                if (result != null)
                {
                    HidePopup();
                    Toast.ShowToastSuccess(SharedResources.AddedSuccessfully);
                    await GetSchedules();
                }
                else
                {
                    Toast.ShowToastError("");
                }
            }
            catch (Exception ex)
            {
                ExtensionLogMethods.LogExtension(ex, "", "SchedulesVM", "AddSchedule");
                Toast.ShowToastError("Error", "Missed Data");
            }
            finally
            {
                IsRunning = false;
            }
        }

        [RelayCommand]
        public void OpenEditSchedule(ScheduleModel scheduleModel)
        {
            var popup = new EditSchedule();
            Settings.ScheduleId = scheduleModel.ScheduleID.ToString();
            StartTime = TimeSpan.Parse(scheduleModel.StartTime);
            EndTime = TimeSpan.Parse(scheduleModel.EndTime);
            SelectedDay = scheduleModel.DayOfWeekName;
            popup.BindingContext = this;
            ShowPopup(popup);
        }

        [RelayCommand]
        public async Task EditSchedule()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(SelectedDay.ToString()))
                {
                    Toast.ShowToastError("Error", "يرجي إختيار وقت  للحلقة");
                    return;
                }
                IsRunning = true;
                var formData = new Dictionary<string, object>
                {
                    { "StartTime", StartTime.ToString(@"hh\:mm\:ss") },
                    { "EndTime", EndTime.ToString(@"hh\:mm\:ss") },
                    //{ "WeekDayNameListDayOfWeekName", SelectedDay },
                    { "DayOfWeekName", SelectedDay },
                };
                var result = await APIs.ServiceSchedule.UpdateSchedule(formData);
                if (result != null)
                {
                    HidePopup();
                    Toast.ShowToastSuccess(SharedResources.UpdatedSuccessfully);
                    await GetSchedules();
                }
                else
                {
                    Toast.ShowToastError("");
                }
            }
            catch (Exception ex)
            {
                ExtensionLogMethods.LogExtension(ex, "", "SchedulesVM", "EditSchedule");
                Toast.ShowToastError("Error", "Missed Data");
            }
            finally
            {
                IsRunning = false;
            }
        }

        [RelayCommand]
        public void OpenAddSchedules()
        {
            var popup = new AddSchedules();
            popup.BindingContext = this;
            ShowPopup(popup);
        }

        [RelayCommand]
        private async Task SelectSchedule(ScheduleModel schedule)
        {
            try
            {
                Debug.WriteLine("Start SelectSchedule OpenPageCommand");

                IsRunning = true;
                if (schedule == null)
                {
                    Toast.ShowToastError("Error: Schedule is null");
                    return;
                }
                
                Schedules = await ServiceSchedule.GetScheduleById();
                SelectedSchedule = Schedules.Where(_ => _.ScheduleID == schedule.ScheduleID).FirstOrDefault();
                Settings.ScheduleId = SelectedSchedule.ScheduleID.ToString();
                await OpenPushAsyncPage(new StudyGroupSessionsPage(SelectedSchedule));
                Debug.WriteLine("End SelectSchedule OpenPageCommand");

            }
            catch (Exception ex)
            {

                ExtensionLogMethods.LogExtension(ex, "", "SchedulesVM", "SelectSchedule");
            }
            finally
            {
                IsRunning = false;
            }
            
        }
        #endregion

    }
}
