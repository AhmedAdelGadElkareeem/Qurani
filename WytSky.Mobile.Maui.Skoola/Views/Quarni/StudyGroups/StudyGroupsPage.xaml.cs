using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WytSky.Mobile.Maui.Skoola.ViewModels.StudyGroups;

namespace WytSky.Mobile.Maui.Skoola.Views.Quarni.StudyGroups;

public partial class StudyGroupsPage : ContentPage
{
    private StudyGroupVM studyGroupVM = new();
    public StudyGroupsPage(string staffId = null, string centerId = null) 
    {
        InitializeComponent();
        BindingContext = studyGroupVM;
        
        studyGroupVM.StaffId = staffId;
        studyGroupVM.CenterId = centerId;
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        await studyGroupVM.GetStudyGroupsByStaffIdOrCenterId();
    }
}