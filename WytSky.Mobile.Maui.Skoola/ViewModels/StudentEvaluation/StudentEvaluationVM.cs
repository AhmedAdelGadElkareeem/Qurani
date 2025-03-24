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
        [ObservableProperty] public ObservableCollection<StudyGroupStudentList> studentGroup;
        [ObservableProperty] private ObservableCollection<StudentEvaluationModel> studentEvaluationListt;

        [ObservableProperty] public double tajweedScore;
        [ObservableProperty] public double memorizationScore;
        [ObservableProperty] public double understandingScore;
        [ObservableProperty] public double behaviorScore;
        [ObservableProperty] public double attendanceScore;
        [ObservableProperty] public string note;

        #endregion

        #region Methods
        public async Task GetStudentEvaulations()
        {
            IsRunning = true;
            StudentEvaluationList = await ServiceStudentEvaluation.GetStudentEvulationBySessionId();
            IsRunning = false;
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
                    { "StudentID", student.StudentID },  // Use student from parameter
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

        [RelayCommand]
        public void OpenEditStudentEvuluation(StudentEvaluationModel studentEvaluation)
        {
            var popup = new EditStudentEvulation();
            Settings.EvulationId = studentEvaluation.EvaluationID.ToString();
            AttendanceScore = studentEvaluation.AttendanceScore.Value;
            BehaviorScore = studentEvaluation.BehaviorScore.Value;
            UnderstandingScore = studentEvaluation.UnderstandingScore.Value;
            TajweedScore = studentEvaluation.TajweedScore.Value;
            MemorizationScore = studentEvaluation.MemorizationScore.Value;
            Note = studentEvaluation.Notes;
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

        public async Task GetStudents()
        {
            IsRunning = true;
            StudentGroup = await StudentService.GetStudyGroupStudentList();
            IsRunning = false;
        }

       

    }
}
