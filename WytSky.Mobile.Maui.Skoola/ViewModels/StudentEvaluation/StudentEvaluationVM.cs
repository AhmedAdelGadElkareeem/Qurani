using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WytSky.Mobile.Maui.Skoola.AppResources;
using WytSky.Mobile.Maui.Skoola.Helpers;
using WytSky.Mobile.Maui.Skoola.Models;
using WytSky.Mobile.Maui.Skoola.ViewModels.StudyGroupSession;

namespace WytSky.Mobile.Maui.Skoola.ViewModels.StudentEvaluation
{
    public partial class StudentEvaluationVM : StudyGroupSessionsVM
    {


        #region Propreties

        [ObservableProperty] private double? tajweedScore;
        [ObservableProperty] private double? memorizationScore;
        [ObservableProperty] private double? understandingScore;
        [ObservableProperty] private double? behaviorScore;
        [ObservableProperty] private double? attendanceScore;
        [ObservableProperty] private string? note;

        public StudentEvaluationVM(ScheduleModel schedule, Dictionary<string, object> formData) : base(schedule, formData)
        {
        }
        #endregion

        #region Commands

        [RelayCommand]
        public async Task AddStudentEvualation(StudyGroupStudentList studentModel)
        {
            try
            {
                IsRunning = true;

                var formData = new Dictionary<string, object>
            {
                { "GroupID", Settings.StudyGroupId },
                { "CenterID", Settings.CenterId },
                { "StudentID", studentModel.StudentID},
                { "ComplexID" , Settings.ComplexId},
                { "SessionDayOfWeekName" , SelectedSchedule.DayOfWeekName },
                { "EvaluationDate" , DateTime.Now.ToString("HH:mm:ss") },
                { "SessionID" , Settings.SessionId},
                { "AttendanceScore" , AttendanceScore},
                { "BehaviorScore" , BehaviorScore},
                { "UnderstandingScore" , UnderstandingScore},
                { "TajweedScore" , TajweedScore},
                { "MemorizationScore" , MemorizationScore},
                { "Notes" , Note},

            };
                var result = await APIs.ServiceStudentEvaluation.AddSrudentEvulation(formData);

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

    }
}
