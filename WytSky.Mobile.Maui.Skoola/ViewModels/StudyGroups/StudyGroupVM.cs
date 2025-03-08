using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WytSky.Mobile.Maui.Skoola.APIs;
using WytSky.Mobile.Maui.Skoola.AppResources;
using WytSky.Mobile.Maui.Skoola.Helpers;
using WytSky.Mobile.Maui.Skoola.Models;
using WytSky.Mobile.Maui.Skoola.Views.Students;
using WytSky.Mobile.Maui.Skoola.Views.StudyGroups;

namespace WytSky.Mobile.Maui.Skoola.ViewModels.StudyGroups;

public partial class StudyGroupVM : CenterVM
{
    [ObservableProperty]
    public ObservableCollection<StudyGroupModel> studyGroups;
    [ObservableProperty] public bool addVisibility;

    // add study group popup
    [ObservableProperty] public string studyGroupName;
    [ObservableProperty] public string studyGroupNameEn;

    [ObservableProperty] public ComplexModel selectedComplex;
    [ObservableProperty] public CentersModel selectedCenter;
    [ObservableProperty] public StaffModel selectedTeacher;

    [ObservableProperty] public int? centerID;
    [ObservableProperty] public int? teacherID;
    //[ObservableProperty] public int? subjectID;
    [ObservableProperty] public string? subjectName;

    [ObservableProperty] public DateTime? startDate = DateTime.Now;
    [ObservableProperty] public DateTime? endDate = DateTime.Now;
    [ObservableProperty] public object? notes;
    [ObservableProperty] public int? studentCount;
    [ObservableProperty] public string? location;

    //[ObservableProperty] public string schedule;
    //[ObservableProperty] public bool? isActive;
    //[ObservableProperty] public object? studyGroupStudentList;
    //[ObservableProperty] public object? schedule1;
    //[ObservableProperty] public object? studyGroupSessions;

    //[ObservableProperty] public int? groupID;
    [ObservableProperty] public string? centerName;
    [ObservableProperty] public string? complexName;


    public async Task GetStudyGroupsByStaffIdOrCenterId()
    {
        try
        {
            IsRunning = true;
            StudyGroups = await StudyGroupService.GetStudyGroups();

            var roles = await AspUserRoleService.GetUserRoles();
            if (roles != null)
                AddVisibility = roles.Any(u =>
                    string.Equals(u.AspNetRolesName, "Administrators", StringComparison.OrdinalIgnoreCase));
        }
        catch (Exception e)
        {
            string er = e.Message;
        }
        finally
        {
            IsRunning = false;
        }
    }
    private async void LoadCenterDetails()
    {
        if (int.TryParse(Settings.CenterId, out int centerId))
        {
            var center = await ServiceCenter.GetCenterById(centerId);
            if (center != null)
            {
                CenterName = center.CenterName;
                ComplexName = center.ComplexName;
            }
            else
            {
                CenterName = "Unknown Center";
                ComplexName = "Unknown Complex";
            }
        }
        else
        {
            CenterName = "Invalid Center ID";
            ComplexName = "Invalid Complex ID";
        }
    }

    [RelayCommand]
    private async Task OpenAddStudyGroup()
    {
        await GetTeachers();
        await GetComplexes();
        await GetCenters();
        var popup = new AddStudyGroup();
        popup.BindingContext = this;
        ShowPopup(popup);
    }

    [RelayCommand]
    private async Task AddStudyGroup()
    {
        try
        {
            LoadCenterDetails();
            //if (SelectedComplex.ComplexID == null)
            //{
            //    Toast.ShowToastError("Error", "Select Complex");
            //}
            //if (SelectedCenter.CenterID == null)
            //{
            //    Toast.ShowToastError("Error", "Select Center");
            //}
            //if (SelectedTeacher.StaffID == null)
            //{
            //    Toast.ShowToastError("Error", "Select Teacher");
            //}
            var formData = new Dictionary<string, object>()
            {
                { "GroupName", StudyGroupName },
                { "GroupNameEn", StudyGroupNameEn },
                { "ComplexID", Settings.ComplexId},
                { "CenterID",Settings.CenterId},
                { "CenterName",CenterName},
                { "ComplexName",ComplexName},
                { "TeacherID", SelectedTeacher.StaffID},
                { "TeacherFullName", SelectedTeacher.FullName},
                { "SubjectName", SubjectName},
                { "Notes", Notes},
                { "StudentCount", StudentCount},
                { "Location", Location},
            };

            var addedStudyGroup = await StudyGroupService.AddStudyGroup(formData);
            if (addedStudyGroup != null && addedStudyGroup.rowsAffected > 0)
            {
                await GetStudyGroupsByStaffIdOrCenterId();
                Toast.ShowToastError(SharedResources.AddedSuccessfully);
            }
        }
        catch (Exception e)
        {
            string er = e.Message;
        }
        finally
        {
            HidePopup();
        }
    }

    [RelayCommand]
    private async Task SelectStudyGroup(StudyGroupModel studyGroup)
    {
        string name = App.IsArabic ? studyGroup.GroupName : studyGroup.GroupNameEn;
        Settings.StudyGroupId = studyGroup.GroupID.ToString();
        await OpenPushAsyncPage(new StudentsPage(name));
    }
}