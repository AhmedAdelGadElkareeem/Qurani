using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WytSky.Mobile.Maui.Skoola.APIs;
using WytSky.Mobile.Maui.Skoola.AppResources;
using WytSky.Mobile.Maui.Skoola.Helpers;
using WytSky.Mobile.Maui.Skoola.Models;
using WytSky.Mobile.Maui.Skoola.Views.Students;
using WytSky.Mobile.Maui.Skoola.Views.StudyGroups;

namespace WytSky.Mobile.Maui.Skoola.ViewModels.StudyGroups;

public partial class StudyGroupVM : BaseViewModel
{
    [ObservableProperty]
    public ObservableCollection<StudyGroupModel> studyGroups;
    [ObservableProperty] public bool addVisibility;

    // add study group popup
    [ObservableProperty] public string studyGroupName;
    [ObservableProperty] public string studyGroupNameEn;

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

    [RelayCommand]
    private void OpenAddStudyGroup()
    {
        var popup = new AddStudyGroup();
        popup.BindingContext = this;
        ShowPopup(popup);
    }

    [RelayCommand]
    private async Task AddStudyGroup()
    {
        try
        {
            var formData = new Dictionary<string, object>()
            {
                { "GroupName", StudyGroupName },
                { "GroupNameEn", StudyGroupNameEn },
                { "TeacherID", Settings.StaffId },
                { "CenterID", Settings.CenterId },
                { "ComplexID", Settings.ComplexId },
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
        Settings.StudyGroupId = studyGroup.GroupID.ToString();
        var baseModel = new BaseModel()
        {
            ID = studyGroup.GroupID.ToString(),
            NameAr = studyGroup.GroupName,
            NameEn = studyGroup.GroupNameEn
        };
        await OpenPushAsyncPage(new StudentsPage(baseModel));
    }
}