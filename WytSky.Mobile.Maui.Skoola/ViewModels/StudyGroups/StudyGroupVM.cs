using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WytSky.Mobile.Maui.Skoola.APIs.AspUserRoles;
using WytSky.Mobile.Maui.Skoola.APIs.Students;
using WytSky.Mobile.Maui.Skoola.APIs.StudyGroups;
using WytSky.Mobile.Maui.Skoola.AppResources;
using WytSky.Mobile.Maui.Skoola.Helpers;
using WytSky.Mobile.Maui.Skoola.Models.Qurani.Students;
using WytSky.Mobile.Maui.Skoola.Models.Qurani.StudyGroup;
using WytSky.Mobile.Maui.Skoola.Views.Quarni.Students;
using WytSky.Mobile.Maui.Skoola.Views.Quarni.StudyGroups;

namespace WytSky.Mobile.Maui.Skoola.ViewModels.StudyGroups;

public partial class StudyGroupVM : BaseViewModel
{
    [ObservableProperty]
    public ObservableCollection<StudyGroupModel> studyGroups;
    
    [ObservableProperty] public bool addVisibility;
    
    [ObservableProperty] public string staffId; 
    [ObservableProperty] public string centerId;

    // add study group popup
    [ObservableProperty] public string  studyGroupName;
        
    public async Task GetStudyGroupsByStaffIdOrCenterId()
    {
        try
        {
            IsRunning = true;
            StudyGroups = await StudyGroupService.GetStudyGroups(StaffId, CenterId);
            var roles = await AspUserRoleService.GetUserRoles();
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
            };
            
            if(StaffId != null)
               formData.Add("TeacherID", StaffId);
            else
               formData.Add("CenterID", CenterId);

            var addedStudyGroup = await StudyGroupService.AddStudyGroup(formData);

            if (addedStudyGroup != null && addedStudyGroup.rowsAffected > 0)
                Toast.ShowToastError(SharedResources.AddedSuccessfully);
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
}