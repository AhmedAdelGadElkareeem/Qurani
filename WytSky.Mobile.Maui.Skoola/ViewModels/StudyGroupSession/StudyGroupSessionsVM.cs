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
using WytSky.Mobile.Maui.Skoola.Views.Schedules;

namespace WytSky.Mobile.Maui.Skoola.ViewModels.StudyGroupSession
{
    public partial class StudyGroupSessionsVM : BaseViewModel
    {
        #region Propreties
        [ObservableProperty] private ObservableCollection<SessionModel> sessions;

        public ScheduleModel SelectedSchedule { get; }
        public Dictionary<string, object> FormData { get; }

        public StudyGroupSessionsVM(ScheduleModel schedule, Dictionary<string, object> formData)
        {
            if (schedule == null)
                throw new ArgumentNullException(nameof(schedule), "ScheduleModel cannot be null");

            if (formData == null)
                throw new ArgumentNullException(nameof(formData), "FormData cannot be null");

            SelectedSchedule = schedule;
            FormData = formData;
        }


        #endregion


        #region Commands

        [RelayCommand]
        public async Task AddSesion()
        {
            try
            {

                IsRunning = true;

               

                var result = await APIs.SessionService.AddStudyGroupSession(FormData);
                if (result != null)
                {
                    HidePopup();
                    Toast.ShowToastSuccess(SharedResources.AddedSuccessfully);
                    await GetSessions();
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

        #endregion

        #region Methods
        public async Task GetSessions()
        {
            IsRunning = true;
            Sessions = await APIs.SessionService.GetStudyGroupSessionByScheduleId();
            IsRunning = false;

        }
        #endregion

     

    }
}
