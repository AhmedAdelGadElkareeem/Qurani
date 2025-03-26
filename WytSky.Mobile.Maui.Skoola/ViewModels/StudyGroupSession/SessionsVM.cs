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
using WytSky.Mobile.Maui.Skoola.ViewModels.Schedules;
using WytSky.Mobile.Maui.Skoola.Views.StudentEvaluation;

namespace WytSky.Mobile.Maui.Skoola.ViewModels.StudyGroupSession
{
    partial class SessionsVM : SchedulesVM
    {
        #region Propreties

        [ObservableProperty] private ObservableCollection<SessionModel> sessions 
                                     = new ObservableCollection<SessionModel>();

        [ObservableProperty]
        private ObservableCollection<StudyGroupStudentList> students
                                     = new ObservableCollection<StudyGroupStudentList>();
        [ObservableProperty]
        private ObservableCollection<SessionModel> filteredsessions
                                     = new ObservableCollection<SessionModel>();

        [ObservableProperty]
        private ObservableCollection<AttendanceModel> attendance
                                     = new ObservableCollection<AttendanceModel>();
        [ObservableProperty]
        private ObservableCollection<AttendanceModel> filteredAttendance
                                     = new ObservableCollection<AttendanceModel>();

        [ObservableProperty]
        private ObservableCollection<StudentEvaluationModel> evuluations
                                     = new ObservableCollection<StudentEvaluationModel>();
        [ObservableProperty]
        private ObservableCollection<StudentEvaluationModel> filteredEvuluation
                                     = new ObservableCollection<StudentEvaluationModel>();

        [ObservableProperty] private string searchText;
        [ObservableProperty] private ScheduleModel sessionSchedule = new ScheduleModel();
        [ObservableProperty] private int? sessinId;
        [ObservableProperty] private bool isStudentVisible = false;
        [ObservableProperty] private bool isEvulationVisible = false;







        #region Attendance
        [ObservableProperty] private ObservableCollection<AttendanceModel> groupAttendance;
        [ObservableProperty] public StudentModel selectedStudent;
        [ObservableProperty] public int all = 0;
        [ObservableProperty] public int availableCount = 0;
        [ObservableProperty] public int absentCount = 0;
        [ObservableProperty]
       public ObservableCollection<StudyGroupStudentList> filteredStudents = new ObservableCollection<StudyGroupStudentList>();
        #endregion

        #endregion


        #region Commands

        #region Session 

        [RelayCommand]
        public async Task SelectSessions(SessionModel model)
        {
            try
            {
                IsRunning = true;
               
                Settings.SessionId = model.SessionID.ToString();
                
                IsStudentVisible = true;
                await GetStudentAttendance();
                await GetStudentEvulation();
            }
            catch (Exception ex)
            {
                ExtensionLogMethods.LogExtension(ex, "", "SessionsVM", "SelectSession");
                Toast.ShowToastError("Error", "An unexpected error occurred");
            }
            finally
            {
                IsRunning = false;
            }
        }

        private async Task GetStudentEvulation()
        {
            try
            {
                IsRunning = true;
                Evuluations = await APIs.ServiceStudentEvaluation.GetStudentEvulationBySessionId();
                FilteredEvuluation = new ObservableCollection<StudentEvaluationModel>(Evuluations);
                IsRunning = false;
            }
            catch (Exception ex)
            {

                ExtensionLogMethods.LogExtension(ex, "", "SessionVM", "GetStudentEvulation");
            }
            finally
            {
                IsRunning = false;
            }
        }

        private async Task GetStudentAttendance()
        {
            try
            {

                IsRunning = true;
                Attendance = await APIs.ServiceAttendance.GetGroupAttendance();
                FilteredAttendance = new ObservableCollection<AttendanceModel>(Attendance);
                IsRunning = false;
            }
            catch (Exception ex)
            {

                ExtensionLogMethods.LogExtension(ex, "", "SessionVM", "GetStudentAttendance");

            }
            finally
            {
                IsRunning = false;
            }
        }

        [RelayCommand]
        public new async Task OpenEvuluations(SessionModel model)
        {

            try
            {
                IsRunning = true;
                Settings.SessionId = model.SessionID.ToString();
                await GetStudentEvulation();
                IsStudentVisible = false;
                IsEvulationVisible = true;
            }
            catch (Exception ex)
            {

                ExtensionLogMethods.LogExtension(ex, "", "SessionVM", "OpenEvuluation");

            }
            finally
            {
                IsRunning = false;
            }

        }
        
        [RelayCommand]
        public new async Task OpenAttendances(SessionModel model)
        {

            try
            {
                IsRunning = true;
                Settings.SessionId = model.SessionID.ToString();
                await GetStudentAttendance();
                IsStudentVisible = true;
                IsEvulationVisible = false;
            }
            catch (Exception ex)
            {
                ExtensionLogMethods.LogExtension(ex, "", "SessionVM", "OpenAttendance");
            }
            finally
            {
                IsRunning = false;
            }
        }
        #endregion

        #region Attendance
        [RelayCommand]
        public async Task AddStudentAttendances(StudyGroupStudentList StudyGroupStudentModel)
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
                    { "Status" , false},
                    { "SessionDayOfWeekName" , SessionSchedule.DayOfWeekName },
                    { "TimeIn" , DateTime.Now.ToString("HH:mm:ss") },
                    { "TimeOut" , SessionSchedule.EndTime },
                    { "SessionID" , SessinId},
                };
                var result = await APIs.ServiceAttendance.AddGroupAttendance(formData);

                if (result != null)
                {
                    Toast.ShowToastSuccess(SharedResources.AddedSuccessfully);
                    await GetAllStudents();
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
            Sessions = await APIs.SessionService.GetStudyGroupSessionsByGroupId();
            Filteredsessions = new ObservableCollection<SessionModel>(Sessions);
            IsRunning = false;

        }
        public async Task GetAllStudents()
        {
            IsRunning = true;
            Students = await StudentService.GetStudyGroupStudentList();
            FilteredStudents = new ObservableCollection<StudyGroupStudentList>(Students);
            if (FilteredStudents != null)
            {
                FilteredStudents = new ObservableCollection<StudyGroupStudentList>(Students); // Initialize with all data
                All = FilteredStudents.Count();
                AvailableCount = FilteredStudents.Where(x => x.Status == "true").Count();
                AbsentCount = FilteredStudents.Where(x => x.Status == "false").Count();
            }
            else
            {
                FilteredStudents = new ObservableCollection<StudyGroupStudentList>();
            }
            IsRunning = false;
        }
        partial void OnSearchTextChanging(string value)
        {
            try
            {
                if (!string.IsNullOrEmpty(value) || value.Length > 0)
                {
                    Filteredsessions =
                        new ObservableCollection<SessionModel>(Sessions.Where(x => x.GroupSubjectName.ToLower().Contains(value)).ToList());
                }
                else
                {
                    Filteredsessions = Sessions;
                }
            }
            catch (Exception ex)
            {
                ExtensionLogMethods.LogExtension(ex, "", "CenterVM", "OnSearchTextChanging");
            }
        }
        #endregion


    }
}