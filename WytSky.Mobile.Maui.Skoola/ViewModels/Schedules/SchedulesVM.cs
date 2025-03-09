using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WytSky.Mobile.Maui.Skoola.AppResources;
using WytSky.Mobile.Maui.Skoola.Helpers;
using WytSky.Mobile.Maui.Skoola.Models;
using WytSky.Mobile.Maui.Skoola.ViewModels.StudyGroupSession;
using WytSky.Mobile.Maui.Skoola.Views.Schedules;
using WytSky.Mobile.Maui.Skoola.Views.StudyGroupSessions;

namespace WytSky.Mobile.Maui.Skoola.ViewModels.Schedules
{
    public partial class SchedulesVM : BaseViewModel
    {

        [ObservableProperty] private ObservableCollection<ScheduleModel> schedules;

        [ObservableProperty]
        private ObservableCollection<string> daysOfWeek;

        [ObservableProperty]
        private string selectedDay; // Selected day from Picker

        [ObservableProperty]
        private DateTime startTime;  // Store as DateTime

        [ObservableProperty]
        private DateTime endTime;

        // Store StartTime as string in "HH:mm:ss" format
        public string StartTimeString
        {
            get => StartTime.ToString("HH:mm:ss");
            set
            {
                if (DateTime.TryParse(value, out DateTime parsedTime))
                {
                    StartTime = parsedTime;
                    OnPropertyChanged(nameof(StartTimeString));
                }
            }
        }

        // Store EndTime as string in "HH:mm:ss" format
        public string EndTimeString
        {
            get => EndTime.ToString("HH:mm:ss");
            set
            {
                if (DateTime.TryParse(value, out DateTime parsedTime))
                {
                    EndTime = parsedTime;
                    OnPropertyChanged(nameof(EndTimeString));
                }
            }
        }

        public SchedulesVM()
        {
            DaysOfWeek = new ObservableCollection<string>
        {
            "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"
        };

            // Default values
            SelectedDay = DaysOfWeek[0]; // Default to first day
            StartTime = DateTime.Today.AddHours(9); // Default Start Time (9 AM)
            EndTime = DateTime.Today.AddHours(17); // Default End Time (5 PM)
        }

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
                    { "StartTime", StartTimeString },
                    { "EndTime", EndTimeString },
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
                ExtensionLogMethods.LogExtension(ex, "", "CenterVM", "AddComplex");
                Toast.ShowToastError("Error", "An unexpected error occurred");
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

        public async Task GetSchedules()
        {
            try
            {
                IsRunning = true;
                var fetchedSchedules = await APIs.ServiceSchedule.GetScheduleGroup();
                Schedules = fetchedSchedules ?? new ObservableCollection<ScheduleModel>();
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

        [RelayCommand]
        private async Task SelectSchedule(ScheduleModel schedule)
        {
            if (schedule == null)
            {
                Toast.ShowToastError("Error: Schedule is null");
                return;
            }

            var formData = new Dictionary<string, object>
    {
        { "StartTime", StartTimeString },
        { "EndTime", EndTimeString },
        { "GroupID", Settings.StudyGroupId },
        { "IsActive", true },
        { "WeekDayNameListDayOfWeekName", SelectedDay },
        { "DayOfWeekName", SelectedDay }
    };

            var viewModel = new StudyGroupSessionsVM(schedule, formData);
            var nextPage = new StudyGroupSessionsPage(viewModel);

            await OpenPushAsyncPage(nextPage);
        }



    }
}
