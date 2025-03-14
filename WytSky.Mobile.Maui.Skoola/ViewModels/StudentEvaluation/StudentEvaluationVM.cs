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
using WytSky.Mobile.Maui.Skoola.ViewModels.StudyGroupSession;
using WytSky.Mobile.Maui.Skoola.Views.StudentEvaluation;

namespace WytSky.Mobile.Maui.Skoola.ViewModels.StudentEvaluation
{
    public partial class StudentEvaluationVM : StudyGroupSessionsVM
    {


        #region Propreties


        [ObservableProperty] private ObservableCollection<StudyGroupStudentList> studentGroup;



        [ObservableProperty] private double? tajweedScore;
        [ObservableProperty] private double? memorizationScore;
        [ObservableProperty] private double? understandingScore;
        [ObservableProperty] private double? behaviorScore;
        [ObservableProperty] private double? attendanceScore;
        [ObservableProperty] private string? note;

        public StudentEvaluationVM(ScheduleModel schedule) : base(schedule)
        {
        }
        #endregion

        #region Commands

        [RelayCommand]
        public async Task AddStudentEvualation(StudyGroupStudentList student)
        {
            try
            {
                if (student == null)
                {
                    Toast.ShowToastError("No student selected.");
                    return;
                }

                IsRunning = true;

                var formData = new Dictionary<string, object>
                {
                    { "GroupID", Settings.StudyGroupId },
                    { "CenterID", Settings.CenterId },
                    { "StudentID", student.StudentID },  // Use student from parameter
                    { "ComplexID", Settings.ComplexId },
                    { "SessionDayOfWeekName", SelectedSchedule.DayOfWeekName },
                    { "EvaluationDate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") },
                    { "SessionID", Settings.SessionId },
                    { "AttendanceScore", AttendanceScore },
                    { "BehaviorScore", BehaviorScore },
                    { "UnderstandingScore", UnderstandingScore },
                    { "TajweedScore", TajweedScore },
                    { "MemorizationScore", MemorizationScore },
                    { "EvaluationType", "1" },
                    { "Notes", Note },
                };

                var result = await APIs.ServiceStudentEvaluation.AddStudentEvulation(formData);

                if (result != null)
                {
                    Toast.ShowToastSuccess(SharedResources.AddedSuccessfully);
                }
                else
                {
                    Toast.ShowToastError("Failed to submit evaluation.");
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
        public async Task OpenStudyEvuluationPage()
        {
            await OpenPushAsyncPage(new StudentEvaluationPage());

        }
        #endregion

        public async Task GetStudents()
        {
            IsRunning = true;
            StudentGroup = await StudentService.GetStudyGroupStudentList();
            IsRunning = false;
        }

       

    }
}
