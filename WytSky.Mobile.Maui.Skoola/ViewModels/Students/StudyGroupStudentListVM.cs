
using CommunityToolkit.Maui.Core.Extensions;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Diagnostics;
using WytSky.Mobile.Maui.Skoola.APIs;
using WytSky.Mobile.Maui.Skoola.AppResources;
using WytSky.Mobile.Maui.Skoola.Enums;
using WytSky.Mobile.Maui.Skoola.Helpers;
using WytSky.Mobile.Maui.Skoola.Models;
using WytSky.Mobile.Maui.Skoola.ViewModels.StudyGroups;
using WytSky.Mobile.Maui.Skoola.Views.Schedules;
using WytSky.Mobile.Maui.Skoola.Views.StudentEvaluation;
using WytSky.Mobile.Maui.Skoola.Views.Students;
using WytSky.Mobile.Maui.Skoola.Views.StudyGroupSessions;
using WytSky.Mobile.Maui.Skoola.Views.StudyGroupStudentList;


namespace WytSky.Mobile.Maui.Skoola.ViewModels.Students;

public partial class StudyGroupStudentListVM : StudyGroupVM
{

    #region Student Evaluatioins Propreties
    [ObservableProperty] public ObservableCollection<StudyGroupStudentList> studentGroup;
    [ObservableProperty] private ObservableCollection<StudentEvaluationModel> studentEvaluationListt;

    [ObservableProperty] public string studentFullName;
    [ObservableProperty] public double tajweedScore;
    [ObservableProperty] public double memorizationScore;
    [ObservableProperty] public double understandingScore;
    [ObservableProperty] public double behaviorScore;
    [ObservableProperty] public double attendanceScore;
    [ObservableProperty] public string note;

    #endregion

    [ObservableProperty] private string searchText;
    [ObservableProperty] public string pageTitle;
    [ObservableProperty] private string teacherFullName;
    [ObservableProperty] private bool isStudentList   = false;
    [ObservableProperty] private bool isSessionsList  = true;
    [ObservableProperty] private bool isSchedulesList = false;
    [ObservableProperty] private bool isGroupSessionList   = false;

    #region Students Properties
    [ObservableProperty] private ObservableCollection<StudyGroupStudentList> studyGroupStudentList;
    [ObservableProperty] private ObservableCollection<StudyGroupStudentList> filteredStudyGroupStudentList = new ObservableCollection<StudyGroupStudentList>();
    [ObservableProperty] private ObservableCollection<StudentModel> studentList;
    #endregion

    #region Sessions Properties
    [ObservableProperty] private bool isAttendnaceVisible = false;
    [ObservableProperty] private bool isEvulationVisible = false;
    [ObservableProperty]
    private ObservableCollection<SessionModel> sessions = new ObservableCollection<SessionModel>();
    [ObservableProperty]
    private ObservableCollection<SessionModel> filteredsessions = new ObservableCollection<SessionModel>();

    [ObservableProperty]
    private ObservableCollection<AttendanceModel> attendance = new ObservableCollection<AttendanceModel>();
    [ObservableProperty]
    private ObservableCollection<AttendanceModel> filteredAttendance = new ObservableCollection<AttendanceModel>();

    [ObservableProperty]
    private ObservableCollection<StudentEvaluationModel> evuluations = new ObservableCollection<StudentEvaluationModel>();
    [ObservableProperty]
    private ObservableCollection<StudentEvaluationModel> filteredEvuluation = new ObservableCollection<StudentEvaluationModel>();

    [ObservableProperty] private ObservableCollection<AttendanceModel> groupAttendance;
    [ObservableProperty]
    private ObservableCollection<AttendanceModel> filteredGroupAttendance = new ObservableCollection<AttendanceModel>();
    [ObservableProperty] public StudentModel selectedStudent;
    [ObservableProperty] public int all = 0;
    [ObservableProperty] public int availableCount = 0;
    [ObservableProperty] public int absentCount = 0;

    [ObservableProperty] public bool allStudents = false;
    [ObservableProperty] public bool availableStudents = false;
    [ObservableProperty] public bool absentStudents = false;
    [ObservableProperty] public bool isSessionStarted = false;

    [ObservableProperty]
    private ObservableCollection<StudyGroupStudentList> groupStudents = new ObservableCollection<StudyGroupStudentList>();
    [ObservableProperty]
    public ObservableCollection<StudyGroupStudentList> filteredGroupStudents = new ObservableCollection<StudyGroupStudentList>();
    #endregion

    #region Schedules Properties
    [ObservableProperty] private ObservableCollection<ScheduleModel> schedules;
    [ObservableProperty] private ScheduleModel schedule = new ScheduleModel();
    [ObservableProperty] private ObservableCollection<ScheduleModel> filteredSchedules = new ObservableCollection<ScheduleModel>();

    [ObservableProperty] private ObservableCollection<string> daysOfWeek;

    [ObservableProperty] public ScheduleModel selectedSchedule = new ScheduleModel();

    [ObservableProperty] private string selectedDay; // Selected day from Picker

    [ObservableProperty] private TimeSpan startTime;

    [ObservableProperty] private TimeSpan endTime;
    #endregion

    #region Constractor
    public StudyGroupStudentListVM()
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


    #region Students Methods
    public async Task GetStudyGroupStudentList()
    {
        try
        {
            IsRunning = true;
            StudyGroupStudentList = await StudentService.GetStudyGroupStudentList();
            FilteredStudyGroupStudentList = new ObservableCollection<StudyGroupStudentList>(StudyGroupStudentList);
            foreach (var item in FilteredStudyGroupStudentList)
            {
                item.StudyGroupStudentNumber = FilteredStudyGroupStudentList.IndexOf(item) + 1;
            }
        }
        catch (Exception ex)
        {
            ExtensionLogMethods.LogExtension(ex, "", "StudyGroupStudentListVM", "GetStudyGroupStudentList");
        }
        finally { IsRunning = false; }
    }
    public async Task GetAllStudents()
    {
        try
        {
            IsRunning = true;
            StudentList = await StudentService.GetAllStudents();
            //FilteredStudyGroupStudentList = new ObservableCollection<StudyGroupStudentList>(StudyGroupStudentList);

        }
        catch (Exception ex)
        {

            ExtensionLogMethods.LogExtension(ex, "", "StudyGroupStudentListVM", "GetAllStudents");
        }
        finally { IsRunning = false; }
    }
    public new async Task GetGroupStudents()
    {
        Debug.WriteLine("Start GetGroupStudents");

        IsRunning = true;
        GroupStudents = await StudentService.GetStudyGroupStudentList();
        FilteredGroupStudents = new ObservableCollection<StudyGroupStudentList>(GroupStudents);
        if (FilteredGroupStudents != null)
        {
            FilteredGroupStudents = new ObservableCollection<StudyGroupStudentList>(GroupStudents); // Initialize with all data
            All = FilteredGroupStudents.Count();
            //AvailableCount = FilteredStudents.Where(x => x.Status == "true").Count();
            //AbsentCount = FilteredStudents.Where(x => x.Status == "false").Count();
        }
        else
        {
            FilteredGroupStudents = new ObservableCollection<StudyGroupStudentList>();
        }
        IsRunning = false;
    }
    #endregion

    #region Sessions Methods
    public async Task GetSessions()
    {
        try
        {
            IsRunning = true;
            Sessions = await APIs.SessionService.GetStudyGroupSessionsByGroupId();
            Filteredsessions = new ObservableCollection<SessionModel>(Sessions);
            foreach (var item in Filteredsessions)
            {
                item.SessionNumber = Filteredsessions.IndexOf(item) + 1;
            }
        }
        catch (Exception ex)
        {

            ExtensionLogMethods.LogExtension(ex, "", "StudyGroupStudentListVM", "GetSessions");
        }
        finally { IsRunning = false; }
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
    public async Task GetStudentAttendance()
    {
        try
        {
            IsRunning = true;
            IsAttendnaceVisible = true;
            IsEvulationVisible = false;
            Attendance = await APIs.ServiceAttendance.GetGroupAttendance();
            FilteredAttendance = new ObservableCollection<AttendanceModel>(Attendance);
            // Process attendance status
            foreach (var attendance in FilteredAttendance)
            {
                if (attendance.Status == null)
                {
                    attendance.StudentStatus = SharedResources.Absent;
                }
                else
                {
                    if (attendance.Status == 1)
                    {
                        attendance.StudentStatus = SharedResources.Present ;
                    }
                    else
                    {
                        attendance.StudentStatus = SharedResources.NotPresent;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            ExtensionLogMethods.LogExtension(ex, "", "StudyGroupStudentListVM", "GetStudentAttendance");
        }
        finally {IsRunning = false;}
    }
    public async Task GetSessionsByGroupId()
    {
        try
        {
            IsRunning = true;
            Sessions = await APIs.SessionService.GetStudyGroupSessionsByGroupId();
            Filteredsessions = new ObservableCollection<SessionModel>(Sessions);
            foreach (var item in Filteredsessions)
            {
                item.SessionNumber = Filteredsessions.IndexOf(item) + 1;
            }
        }
        catch (Exception ex)
        {
            ExtensionLogMethods.LogExtension(ex, "", "StudyGroupStudentListVM", "GetSessionsByGroupId");
        }

       finally{IsRunning = false;}

    }
    public async Task GetGroupAttendance()
    {
        try
        {
            Debug.WriteLine("Start GetGroupAttendance");

            GroupAttendance = await ServiceAttendance.GetGroupAttendance();
            FilteredGroupAttendance = new ObservableCollection<AttendanceModel>(GroupAttendance);
            if (GroupAttendance != null)
            {
                //All = GroupAttendance.Count();
                AvailableCount = GroupAttendance.Where(x => x.Status > 0).Count();
                AbsentCount = GroupAttendance.Where(x => x.Status < 1).Count();
            }
        }
        catch (Exception ex)
        {

            ExtensionLogMethods.LogExtension(ex, "", "StudyGroupSessionsVM", "GetGroupAttendance");
        }
    }
    #endregion

    #region Schedules Methods
    public async Task GetSchedules()
    {
        try
        {
            IsRunning = true;
            Schedules = await APIs.ServiceSchedule.GetScheduleGroup();
            GroupName = Schedules.Where(_ => _.GroupID == int.Parse(Settings.StudyGroupId)).Select(_ => _.GroupName).FirstOrDefault().ToString();
            ComplexNamee = Schedules.Select(_ => _.GroupCenterComplexName).FirstOrDefault().ToString();
            CenterName = Schedules.Select(_ => _.GroupCenterName).FirstOrDefault().ToString();
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
    #endregion

    #region Students Commands
    [RelayCommand]
    private async Task GetStudentList()
    {
        try
        {
            IsRunning = true;
            IsStudentList = true;
            IsSchedulesList = false;
            IsSessionsList = false;
            IsGroupSessionList = false;
            PageTitle = SharedResources.Students;

            await GetStudyGroupStudentList();
        }
        catch (Exception ex)
        {
            ExtensionLogMethods.LogExtension(ex, "", "StudyGroupStudentListVM", "GetStudyGroupStudentList");
        }
    }

    [RelayCommand]
    private async Task OpenAddStudyGroupStudentList()
    {
        var popup = new AddStudyGroupStudentList();
        await GetAllStudents();
        popup.BindingContext = this;
        ShowPopup(popup);
    }

    [RelayCommand]
    public async Task AddExsistingStudent()
    {
        try
        {
            var formData = new Dictionary<string, object>()
            {
                { "StudentID", SelectedStudent.StudentID },
                { "GroupID", Settings.StudyGroupId },
            };
            var result = await StudentStudyGroupList.AddStudyGroupStudentList(formData);
            if (result != null && result.rowsAffected > 0)
            {
                await GetStudyGroupStudentList();
                Toast.ShowToastError(SharedResources.AddedSuccessfully);
            }

        }
        catch (Exception e)
        {
            ExtensionLogMethods.LogExtension(e, "", "StudyGroupStudentListVM", "AddExsistingStudent");
        }
        finally
        {
            HidePopup();
        }
    }

    [RelayCommand]
    public async Task StudyGroupStudentSelected(StudyGroupStudentList studyGroupStudentModel)
    {
        StudentID = studyGroupStudentModel.StudentID.ToString();
        GroupId = studyGroupStudentModel.GroupID.ToString();
        await OpenPushAsyncPage(new StudentDetailsPage(studyGroupStudentModel));
    }

    #endregion

    #region Sessions Commands
    [RelayCommand]
    private async Task OpenSessions()
    {
        await OpenPushAsyncPage(new SessionsPage(StudentList.FirstOrDefault()));
    }

    [RelayCommand]
    private async Task GetSessionsList()
    {
        try
        {
            IsRunning = true;
            IsStudentList = false;
            IsSchedulesList = false;
            IsSessionsList = true;
            IsGroupSessionList = false;
            PageTitle = SharedResources.Txt_Sessions;
            await GetSessions();
        }
        catch (Exception ex)
        {
            ExtensionLogMethods.LogExtension(ex, "", "StudyGroupStudentListVM", "GetSessionsCollection");
        }
        finally { IsRunning = false; }
    }

    [RelayCommand]
    public async Task SelectSession(SessionModel model)
    {
        try
        {
            IsRunning = true;
            Settings.SessionId = model.SessionID.ToString();
            //await GetStudentAttendance();
            //await GetStudentEvulation();
            await OpenPushAsyncPage(new StudyGroupSessionDetailsPage(model));
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

    [RelayCommand]
    public new async Task OpenEvuluation()
    {
        try
        {
            IsRunning = true;
            //Settings.SessionId = model.SessionID.ToString();
            await GetStudentEvulation();
            IsAttendnaceVisible = false;
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
    public new async Task OpenAttendance()
    {

        try
        {
            IsRunning = true;
            //Settings.SessionId = model.SessionID.ToString();
            await GetStudentAttendance();
            IsAttendnaceVisible = true;
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

    [RelayCommand]
    public async Task FetchStudentsFilter(Enums.StudentsStatus obj)
    {
        try
        {
            // Clear the current filtered list
            IsRunning = true;
            FilteredGroupStudents.Clear();
            FilteredGroupAttendance.Clear();
            if (obj == StudentsStatus.All)
            {
                FilteredGroupStudents = await StudentService.GetStudyGroupStudentList(); ;
                AllStudents = true;
                AvailableStudents = false;
                AbsentStudents = false;
            }
            else if (obj == StudentsStatus.Available)
            {
                FilteredGroupAttendance = GroupAttendance.Where(_ => _.Status == 1).ToObservableCollection();
                AllStudents = false;
                AvailableStudents = true;
                AbsentStudents = false;
            }
            else if (obj == StudentsStatus.Absent)
            {
                FilteredGroupAttendance = GroupAttendance.Where(_ => _.Status != 1).ToObservableCollection();
                AllStudents = false;
                AvailableStudents = false;
                AbsentStudents = true;
            }
        }
        catch (Exception ex)
        {
            ExtensionLogMethods.LogExtension(ex, "", "UserStatusVM", "FetchUsers");
        }
        finally
        {
            IsRunning = false;
            //IsRefreshing = false;
        }
    }

    [RelayCommand]
    public void OpenUpdateStudent(AttendanceModel model)
    {
        if (model == null)
            return;
        Settings.StudentId = model.StudentID.ToString();

        StudentName = model.StudentFullName;
        //PhoneNumber = model.PhoneNumber;
        //StudentEmail = model.Email;
        //ComplexId = model.ComplexID.ToString();
        //GroupId = model.GroupID.ToString();
        //CenterId = model.CenterID.ToString();

        var popup = new UpdateStudentPopup();
        popup.BindingContext = this;
        ShowPopup(popup);
    }

    [RelayCommand]
    public async Task UpdateStudent()
    {
        try
        {
            IsRunning = true;

            var formData = new Dictionary<string, object>
            {
                { "FullName", StudentName},
                //{ "PhoneNumber" , PhoneNumber},
                //{ "Email" , StudentEmail},
                //{ "ComplexID" , ComplexId},
                //{ "GroupID" , GroupId},
                //{ "CenterID" , CenterId},
            };

            var result = await APIs.StudentService.UpdateStudent(formData);
            if (result != null)
            {
                Toast.ShowToastSuccess(SharedResources.UpdatedSuccessfully);
                //await GetStudentsByCenterId();
                await GetStudentAttendance();
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
    public void OpenUpdateStudentEvuluation(StudentEvaluationModel studentEvaluation)
    {
        StudentFullName = studentEvaluation.StudentFullName;
        Settings.EvulationId = studentEvaluation.EvaluationID.ToString();
        AttendanceScore = studentEvaluation.AttendanceScore.Value;
        BehaviorScore = studentEvaluation.BehaviorScore.Value;
        UnderstandingScore = studentEvaluation.UnderstandingScore.Value;
        TajweedScore = studentEvaluation.TajweedScore.Value;
        MemorizationScore = studentEvaluation.MemorizationScore.Value;
        Note = studentEvaluation.Notes;
        var popup = new UpdateStudentEvulation();
        popup.BindingContext = this;
        ShowPopup(popup);
    }

    [RelayCommand]
    public async Task UpdateStudentEvulation()
    {
        try
        {
            IsRunning = true;
            var formData = new Dictionary<string, object>
                {
                    { "AttendanceScore", AttendanceScore },
                    { "BehaviorScore", BehaviorScore },
                    { "UnderstandingScore", UnderstandingScore },
                    { "TajweedScore", TajweedScore },
                    { "MemorizationScore", MemorizationScore },
                    { "EvaluationType", "1" },
                    { "Notes", Note },
                };
            var result = await APIs.ServiceStudentEvaluation.UpdateStudentEvulation(formData);
            Settings.EvulationId = result.Select(_ => _.EvaluationID).ToString();
            StudentEvaluationListt = await ServiceStudentEvaluation.GetStudentEvulationByEvaluationID();
            await GetStudentEvulation();
            if (result != null)
            {
                Toast.ShowToastSuccess(SharedResources.UpdatedSuccessfully);
            }
            else
            {
                Toast.ShowToastError("Failed to update evaluation.");
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

    #region Schedules Commands
    [RelayCommand]
    private async Task OpenSchedules()
    {
        await OpenPushAsyncPage(new SchedulesPage());
    }

    [RelayCommand]
    private async Task GetSchedulesList()
    {
        try
        {
            IsRunning = true;
            IsStudentList = false;
            IsSchedulesList = true;
            IsSessionsList = false;
            PageTitle = SharedResources.SchedulesPage;
            await GetSessions();
        }
        catch (Exception ex)
        {
            ExtensionLogMethods.LogExtension(ex, "", "StudyGroupStudentListVM", "GetSchedulesList");
        }
        finally { IsRunning = false; }
    }
    [RelayCommand]
    public void OpenAddSchedule()
    {
        var popup = new AddSchedules();
        popup.BindingContext = this;
        ShowPopup(popup);
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
        finally {IsRunning = false;}
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

            Schedules = await ServiceSchedule.GetSchedules();
            //Schedule = await ServiceSchedule.GetScheduleById(schedule.ScheduleID.ToString());
            SelectedSchedule = Schedules.Where(_ => _.ScheduleID == schedule.ScheduleID).FirstOrDefault();
            Settings.ScheduleId = SelectedSchedule.ScheduleID.ToString();

            await StartSesion(SelectedSchedule);
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

    [RelayCommand]
    public async Task StartSesion(ScheduleModel scheduleModel)
    {
        try
        {
            IsRunning = true;
            if (Sessions == null || Sessions.Count > 1)
            {
                Toast.ShowToastError(SharedResources.Msg_SessionExpired);
            }
            else
            {
                var formData = new Dictionary<string, object>
                    {
                         { "SessionDate", scheduleModel.CreatedDate?.ToString("yyyy-MM-ddTHH:mm:ss.fff") ?? string.Empty },
                         { "DayOfWeekName" , scheduleModel.DayOfWeekName ?? string.Empty },
                         { "StartTime" , scheduleModel.StartTime?.ToString() ?? string.Empty },
                         { "EndTime" , scheduleModel.EndTime?.ToString() ?? string.Empty },
                         { "GroupID" , Settings.StudyGroupId },
                         { "ScheduleID" , scheduleModel.ScheduleID },
                    };
                //Settings.SessionId = sessionModel.SessionID.ToString();

                var result = await APIs.SessionService.AddStudyGroupSession(formData);
                await GetGroupStudents();
                await GetGroupAttendance();

                if (result != null)
                {
                    Toast.ShowToastSuccess(SharedResources.AddedSuccessfully);
                }
                else
                {
                    Toast.ShowToastError("");
                }
            }
            //--------------------------------//
            AllStudents = true;
            AvailableStudents = false;
            AbsentStudents = false;
            IsSessionStarted = true;
            //-------------------------------//
            IsStudentList = false;
            IsSessionsList = false;
            IsSchedulesList = false;
            IsGroupSessionList = true;
            PageTitle = SharedResources.SessionDetails;

            await GetSessions();
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
    public async Task AddStudentAttendance(StudyGroupStudentList StudyGroupStudentModel)
    {
        try
        {
            IsRunning = true;
            //bool hasAttendance = GroupAttendance
            //            .Where(a => a.Status > 1 && GroupAttendance.Any(s => s.StudentID == a.StudentID)).Any();

            // Check if the student already has attendance with a status greater than 0
            bool hasAttendance = GroupAttendance
                .Any(a => a.StudentID == StudyGroupStudentModel.StudentID && a.Status > 0);
            if (hasAttendance)
            {
                Toast.ShowToastError("Student already attended");
                return;
            }
            else
            {
                var formData = new Dictionary<string, object>
                    {
                        { "GroupID", Settings.StudyGroupId },
                        { "CenterID", Settings.CenterId },
                        { "StudentID", StudyGroupStudentModel.StudentID},
                        { "ComplexID" , Settings.ComplexId},
                        { "Status" , 1},
                        { "SessionDayOfWeekName" , SelectedSchedule.DayOfWeekName },
                        { "TimeIn" , DateTime.Now.ToString("HH:mm:ss") },
                        { "TimeOut" , SelectedSchedule.EndTime },
                        { "SessionID" , Settings.SessionId},
                    };
                var result = await APIs.ServiceAttendance.AddGroupAttendance(formData);

                if (result != null)
                {
                    Toast.ShowToastSuccess(SharedResources.AddedSuccessfully);
                    //await GetAllStudents();
                    await GetGroupAttendance();
                }
                else
                {
                    Toast.ShowToastError(SharedResources.Msg_Error, SharedResources.Msg_ConnectionError);
                }
            }
        }
        catch (Exception ex)
        {
            Toast.ShowToastError(SharedResources.Text_Error, ex.Message);
        }
        finally
        {
            IsRunning = false;
        }
    }

    [RelayCommand]
    public async Task OpenEvaluationPage()
    {
        await OpenPushAsyncPage(new AddStudentEvaluationPage(SelectedSchedule));
    }
    #endregion


    partial void OnSearchTextChanging(string value)
    {
        try
        {
            if (!string.IsNullOrEmpty(value))
            {
                FilteredStudyGroupStudentList =
                    new ObservableCollection<StudyGroupStudentList>(StudyGroupStudentList.Where(x => x.StudentFullName.ToLower().Contains(value)).ToList());
            }
            else
            {
                FilteredStudyGroupStudentList = StudyGroupStudentList;
            }
        }
        catch (Exception ex)
        {
            ExtensionLogMethods.LogExtension(ex, "", "StaffVM", "OnSearchTextChanging");
        }
    }

}
