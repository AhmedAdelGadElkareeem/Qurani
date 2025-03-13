using WytSky.Mobile.Maui.Skoola.ViewModels.StudentEvaluation;

namespace WytSky.Mobile.Maui.Skoola.Views.StudentEvaluation;

public partial class StudentEvaluationPage : ContentPage
{
	private readonly GetAddStudentEvaluationVM _vm = new();
	public StudentEvaluationPage()
	{
		InitializeComponent();
		BindingContext = _vm;
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();

       await _vm.GetStudentEvaulations();
        
    }
}