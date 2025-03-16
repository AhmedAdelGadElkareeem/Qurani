﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WytSky.Mobile.Maui.Skoola.APIs;
using WytSky.Mobile.Maui.Skoola.AppResources;
using WytSky.Mobile.Maui.Skoola.Enums;
using WytSky.Mobile.Maui.Skoola.Helpers;
using WytSky.Mobile.Maui.Skoola.Models;
using WytSky.Mobile.Maui.Skoola.ViewModels.Schedules;
using WytSky.Mobile.Maui.Skoola.ViewModels.Studentattendance;
using WytSky.Mobile.Maui.Skoola.ViewModels.Students;
using WytSky.Mobile.Maui.Skoola.Views.Schedules;
using WytSky.Mobile.Maui.Skoola.Views.StudentEvaluation;

namespace WytSky.Mobile.Maui.Skoola.ViewModels.StudyGroupSession
{
    public partial class StudyGroupSessionsVM : SchedulesVM
    {
        #region Propreties

        [ObservableProperty] private ObservableCollection<SessionModel> sessions;

        [ObservableProperty] private ObservableCollection<StudyGroupStudentList> students 
                                     = new ObservableCollection<StudyGroupStudentList>();
        [ObservableProperty] private ObservableCollection<StudyGroupStudentList> filteredStudents 
                                     = new ObservableCollection<StudyGroupStudentList>();

        [ObservableProperty] private string searchText;
        [ObservableProperty] private ScheduleModel sessionSchedule = new ScheduleModel();
        [ObservableProperty] private int? sessinId;
        [ObservableProperty] private bool isStudentVisible = false;







        #region Attendance
        [ObservableProperty] private ObservableCollection<AttendanceModel> groupAttendance;
        [ObservableProperty] public StudentModel selectedStudent;
        [ObservableProperty] public int all = 0;
        [ObservableProperty] public int availableCount = 0;
        [ObservableProperty] public int absentCount = 0;
        //[ObservableProperty]
        //public ObservableCollection<StudyGroupStudentList> FilteredStudents = new ObservableCollection<StudyGroupStudentList>();
        #endregion

        #endregion


        #region Commands

        #region Session 

        [RelayCommand]
        public async Task StartSesion()
        {
            try
            {
                IsRunning = true;
                if (Sessions.Count > 1)
                {
                    SessinId = Sessions[0].SessionID;
                    Settings.SessionId = SessinId.ToString();
                    Toast.ShowToastError(SharedResources.Msg_SessionExpired);
                }
                else
                {
                    var formData = new Dictionary<string, object>
                    {
                         { "SessionDate", SessionSchedule.CreatedDate?.ToString("yyyy-MM-ddTHH:mm:ss.fff") ?? string.Empty },
                         { "DayOfWeekName" , SessionSchedule.DayOfWeekName ?? string.Empty },
                         { "StartTime" , SessionSchedule.StartTime?.ToString() ?? string.Empty },
                         { "EndTime" , SessionSchedule.EndTime?.ToString() ?? string.Empty },
                         { "GroupID" , Settings.StudyGroupId },
                         { "ScheduleID" , SessionSchedule.ScheduleID }
                    };

                    var result = await APIs.SessionService.AddStudyGroupSession(formData);

                    if (result != null)
                    {
                        Toast.ShowToastSuccess(SharedResources.AddedSuccessfully);
                    }
                    else
                    {
                        Toast.ShowToastError("");
                    }
                }
                IsStudentVisible = true;
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
        public async Task OpenEvaluationPage()
        {
            await OpenPushAsyncPage(new AddStudentEvaluationPage(SelectedSchedule));
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

        [RelayCommand]
        public async Task FetchStudents(Enums.StudentsStatus obj)
        {
            try
            {
                // Clear the current filtered list
                FilteredStudents.Clear();

                #endregion
                // Filter based on the user status using a switch expression
                IEnumerable<StudyGroupStudentList> filteredStudents = obj switch
                {
                StudentsStatus.Available => FilteredStudents.Where(x => x.Status == "true"),
                //StudentsStatus.All => FilteredStudents.Count(),
                StudentsStatus.Absent => FilteredStudents.Where(x => x.Status == "false"),
                StudentsStatus.All => FilteredStudents = Students,
                _ => FilteredStudents, // If no specific filter, just display all users
                };

                // Add filtered  to FilteredStudents collection
                foreach (var student in filteredStudents)
                {
                    FilteredStudents.Add(student);
                }
            }
            catch (Exception ex)
            {
                ExtensionLogMethods.LogExtension(ex, "", "UserStatusVM", "FetchUsers");
            }
            finally
            {
                //IsRefreshing = false;
            }
        }
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
            FilteredStudents = new ObservableCollection<StudyGroupStudentList>(Students);
            if (FilteredStudents != null )
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
                    FilteredStudents =
                        new ObservableCollection<StudyGroupStudentList>(Students.Where(x => x.StudentFullName.ToLower().Contains(value)).ToList());
                }
                else
                {
                    FilteredStudents = Students;
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
