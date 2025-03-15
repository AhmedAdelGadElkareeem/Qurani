    using WytSky.Mobile.Maui.Skoola.Helpers;
    using WytSky.Mobile.Maui.Skoola.Models;
    using WytSky.Mobile.Maui.Skoola.ViewModels.StudentEvaluation;

    namespace WytSky.Mobile.Maui.Skoola.Views.StudentEvaluation;

    public partial class AddStudentEvaluationPage : ContentPage
    {
        public StudentEvaluationVM _studentEvaluationsVM = new StudentEvaluationVM();

        public AddStudentEvaluationPage(ScheduleModel schedule)
        {
            InitializeComponent();
            BindingContext = _studentEvaluationsVM;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await _studentEvaluationsVM.GetStudents();
        }
    }
