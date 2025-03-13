using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WytSky.Mobile.Maui.Skoola.APIs;
using WytSky.Mobile.Maui.Skoola.AppResources;
using WytSky.Mobile.Maui.Skoola.Helpers;
using WytSky.Mobile.Maui.Skoola.Models;
using WytSky.Mobile.Maui.Skoola.ViewModels.Studentattendance;
using WytSky.Mobile.Maui.Skoola.ViewModels.Students;
using WytSky.Mobile.Maui.Skoola.Views.Schedules;
using WytSky.Mobile.Maui.Skoola.Views.StudentEvaluation;

namespace WytSky.Mobile.Maui.Skoola.ViewModels.StudyGroupSession
{
    public partial class StudyGroupSessionsVM : BaseViewModel
    {
        #region Propreties

        #region Session 
        [ObservableProperty] private ObservableCollection<SessionModel> sessions;

        [ObservableProperty] private ObservableCollection<StudyGroupStudentList> students;


        [ObservableProperty] private int? sessinId;


        [ObservableProperty] private bool isStudentVisible = false ;

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

        #region Attendance

        [ObservableProperty] private ObservableCollection<AttendanceModel> groupAttendance;
        [ObservableProperty] public StudentModel selectedStudent;


        #endregion


        #endregion


        #region Commands

        #region Session 

        [RelayCommand]
        public async Task AddSesion(SessionModel session)
        {
            try
            {

                IsRunning = true;


                if (session != null) 
                {
                    SessinId = session.SessionID; 
                    Settings.SessionId = SessinId.ToString();
                }

                var result = await APIs.SessionService.AddStudyGroupSession(FormData);
                if (result != null)
                {
                    HidePopup();
                    Toast.ShowToastSuccess(SharedResources.AddedSuccessfully);
                    await GetSessions();
                    IsStudentVisible = true;
                }
                else
                {
                    Toast.ShowToastError("");
                }
            }
            catch (Exception ex)
            {
                ExtensionLogMethods.LogExtension(ex, "", "StudyGroupSessionsVM", "AddSesion");
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

        [RelayCommand]
        public async Task OpenEvaluationPage() 
        {
            await OpenPushAsyncPage(new AddStudentEvaluationPage(SelectedSchedule , FormData));

        }
        #endregion

        #region Attendance
        [RelayCommand]
        public async Task AddStudentAttendance(StudyGroupStudentList StudyGroupStudentModel) 
        {
            try
            {
                IsRunning = true;

                var formData = new Dictionary<string, object>
                {
                    { "GroupID", Settings.StudyGroupId },
                    { "CenterID", Settings.CenterId },
                    { "StudentID", StudyGroupStudentModel.StudentID},
                    { "ComplexID" , Settings.ComplexId},
                    { "SessionDayOfWeekName" , SelectedSchedule.DayOfWeekName },
                    { "TimeIn" , DateTime.Now.ToString("HH:mm:ss") },
                    { "TimeOut" , SelectedSchedule.EndTime },
                    { "SessionID" , SessinId},

                  

                };
                var result = await APIs.ServiceAttendance.AddGroupAttendance(formData);

                if (result != null)
                {
                    Toast.ShowToastSuccess(SharedResources.AddedSuccessfully);
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
            }
        }

        #endregion

        #endregion

        #region Methods
        public async Task GetSessions()
        {
            IsRunning = true;
            Sessions = await APIs.SessionService.GetStudyGroupSessionByScheduleId();
            IsRunning = false;

        }
        public async Task GetAllStudents()
        {
            IsRunning = true;
            Students = await StudentService.GetStudyGroupStudentList();
            IsRunning = false;
        }

        #endregion



    }
}
