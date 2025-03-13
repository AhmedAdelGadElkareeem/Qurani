using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WytSky.Mobile.Maui.Skoola.APIs;
using WytSky.Mobile.Maui.Skoola.Models;

namespace WytSky.Mobile.Maui.Skoola.ViewModels.StudentEvaluation
{
    public partial class GetAddStudentEvaluationVM : BaseViewModel
    {

        [ObservableProperty] private ObservableCollection<StudentEvaluationModel> studentEvaluationList;

        public async Task GetStudentEvaulations()
        {
            IsRunning = true;
            StudentEvaluationList = await ServiceStudentEvaluation.GetStudentEvulationBySessionId();
            IsRunning = false;
        }

    }
}
