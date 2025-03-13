    using WytSky.Mobile.Maui.Skoola.Helpers;
    using WytSky.Mobile.Maui.Skoola.Models;
    using WytSky.Mobile.Maui.Skoola.ViewModels.StudentEvaluation;

    namespace WytSky.Mobile.Maui.Skoola.Views.StudentEvaluation;

    public partial class AddStudentEvaluationPage : ContentPage
    {
        private readonly StudentEvaluationVM _studentEvaluationsVM;

        public AddStudentEvaluationPage(ScheduleModel schedule, Dictionary<string, object> formData)
        {
            InitializeComponent();
            _studentEvaluationsVM = new StudentEvaluationVM(schedule, formData);
            BindingContext = _studentEvaluationsVM;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await _studentEvaluationsVM.GetStudents();
        }
    }
