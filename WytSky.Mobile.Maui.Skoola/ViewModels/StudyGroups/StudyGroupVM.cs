using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WytSky.Mobile.Maui.Skoola.APIs;
using WytSky.Mobile.Maui.Skoola.AppResources;
using WytSky.Mobile.Maui.Skoola.Helpers;
using WytSky.Mobile.Maui.Skoola.Models;
using WytSky.Mobile.Maui.Skoola.ViewModels.Students;
using WytSky.Mobile.Maui.Skoola.Views.Students;
using WytSky.Mobile.Maui.Skoola.Views.StudyGroups;
using WytSky.Mobile.Maui.Skoola.Views.StudyGroupStudentList;

namespace WytSky.Mobile.Maui.Skoola.ViewModels.StudyGroups;

public partial class StudyGroupVM : StudentsVM
{
    [ObservableProperty]
    public ObservableCollection<StudyGroupModel> studyGroups;
    [ObservableProperty] private ObservableCollection<StudyGroupModel> filteredStudyGroups 
                            = new ObservableCollection<StudyGroupModel>();
    [ObservableProperty]
    private ObservableCollection<StudyGroupModel> filteredTeacherStudyGroups
                        = new ObservableCollection<StudyGroupModel>();

    [ObservableProperty] private string searchText;
    [ObservableProperty] public bool addVisibility;

    [ObservableProperty] public bool fromCenter;

    // add study group popup
    [ObservableProperty] public string studyGroupName;
    [ObservableProperty] public string studyGroupNameEn;

    [ObservableProperty] public ComplexModel selectedComplex = new();
    [ObservableProperty] public CentersModel selectedCenter = new();
    [ObservableProperty] public StaffModel selectedTeacher = new();

    [ObservableProperty] private string centerID;
    [ObservableProperty] public string teacherID;
    //[ObservableProperty] public int? subjectID;
    [ObservableProperty] public string? subjectName;

    [ObservableProperty] public DateTime startDate = DateTime.Now;
    [ObservableProperty] public DateTime endDate = DateTime.Now;
    [ObservableProperty] public string notes;
    [ObservableProperty] public int studentCount;
    [ObservableProperty] public string location;

    [ObservableProperty] public new string centerName;
    [ObservableProperty] public new string complexName;

    #region Methods
    public async Task GetStudyGroupsByStaffIdOrCenterId()
    {
        try
        {
            IsRunning = true;
            
            if (TeacherID != null)
            {
                Settings.CenterId = CenterID;
                StudyGroups = await StudyGroupService.GetStudyGroupsByTeacherIdandCenterId(TeacherID.ToString());
                FilteredStudyGroups = new ObservableCollection<StudyGroupModel>(StudyGroups);
                foreach (var item in FilteredStudyGroups)
                {
                    item.StudyGroupNumber = FilteredStudyGroups.IndexOf(item) + 1;
                }
                //if(FilteredStudyGroups.Count > 0)
                //{
                //    ComplexNamee = StudyGroups.Select(_ => _.ComplexName).FirstOrDefault();
                //    ComplexRegionName = StudyGroups.Select(_ => _.ComplexRegionName).FirstOrDefault();
                //    CenterName = StudyGroups.Select(_ => _.CenterName).FirstOrDefault();
                //}

            }
            else
            {
                StudyGroups = await StudyGroupService.GetStudyGroupsByCenterId();
                FilteredStudyGroups = new ObservableCollection<StudyGroupModel>(StudyGroups);
                foreach (var item in FilteredStudyGroups)
                {
                    item.StudyGroupNumber = FilteredStudyGroups.IndexOf(item) + 1;
                }
                //ComplexNamee = StudyGroups.Select(_ => _.ComplexName).FirstOrDefault();
                ////== null ? ComplexName = TeacherStudyGroups.Select(_ => _.ComplexName).FirstOrDefault() : "";
                //ComplexRegionName = StudyGroups.Select(_ => _.ComplexRegionName).FirstOrDefault();
                //CenterName = StudyGroups.Select(_ => _.CenterName).FirstOrDefault();
            }
            

            var roles = await AspUserRoleService.GetUserRoles();
            if (roles != null)
                AddVisibility = roles.Any(u =>
                    string.Equals(u.AspNetRolesName, "Administrators", StringComparison.OrdinalIgnoreCase));
        }
        catch (Exception e)
        {
            ExtensionLogMethods.LogExtension(e, "", "StudyGroupVM", "GetStudyGroupsByStaffIdOrCenterId");
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
    partial void OnSearchTextChanging(string value)
    {
        try
        {
            if (!string.IsNullOrEmpty(value) || value.Length > 0)
            {   
                FilteredStudyGroups =
                    new ObservableCollection<StudyGroupModel>(StudyGroups.Where(x => x.Name.ToLower().Contains(value)).ToList());
                FilteredTeacherStudyGroups =
                    new ObservableCollection<StudyGroupModel>(StudyGroups.Where(x => x.Name.ToLower().Contains(value)).ToList());
            }
            else
            {
                FilteredTeacherStudyGroups = StudyGroups;
                FilteredStudyGroups = StudyGroups;
            }
        }
        catch (Exception ex)
        {
            ExtensionLogMethods.LogExtension(ex, "", "CenterVM", "OnSearchTextChanging");
        }
    }
    #endregion

    #region Commands
    [RelayCommand]
    private async Task OpenAddStudyGroup()
    {
        try
        {
            await GetTeachers();
            await GetComplexes();
            await GetCenters();
            var popup = new AddStudyGroup();
            popup.BindingContext = this;
            ShowPopup(popup);
        }
        catch (Exception ex)
        {

            ExtensionLogMethods.LogExtension(ex, "", "StudyGroupVM", "OpenAddStudyGroup");
        }
        
    }
    
    [RelayCommand]
    private async Task OpenEditStudyGroup(StudyGroupModel model)
    {
        try
        {
            Settings.StudyGroupId = model.GroupID.ToString();

            StudyGroupName = model.GroupName;
            StudyGroupNameEn = model.GroupNameEn;
            //SelectedComplex = Complexes.FirstOrDefault(c => c.ComplexID == model.ComplexID);
            //SelectedCenter = Centers.FirstOrDefault(c => c.CenterID == model.CenterID);
            //SelectedTeacher = Teachers.FirstOrDefault(t => t.StaffID == model.TeacherID);
            SubjectName = model.SubjectName;
            Notes = model.Notes.ToString();
            Location = model.Location;


            await GetTeachers();
            await GetComplexes();
            await GetCenters();
            var popup = new EditStudyGroup();
            popup.BindingContext = this;
            ShowPopup(popup);
        }
        catch (Exception ex)
        {

            ExtensionLogMethods.LogExtension(ex, "", "StudyGroupVM", "OpenAddStudyGroup");
        }
        
    }

    [RelayCommand]
    private async Task AddStudyGroup()
    {
        try
        {
            LoadCenterDetails();
            
            var formData = new Dictionary<string, object>()
            {
                { "GroupName", StudyGroupName },
                { "GroupNameEn", StudyGroupNameEn },
                { "ComplexID", Settings.ComplexId},
                { "CenterID",Settings.CenterId},
                { "TeacherID", SelectedTeacher.StaffID},
                { "TeacherFullName", SelectedTeacher.FullName},
                { "SubjectName", SubjectName},
                { "Notes", Notes},
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
    private async Task EditStudyGroup()
    {
        try
        {
            LoadCenterDetails();
            
            var formData = new Dictionary<string, object>()
            {
                { "GroupName", StudyGroupName },
                { "GroupNameEn", StudyGroupNameEn },
                { "ComplexID", Settings.ComplexId},
                { "CenterID",Settings.CenterId},
                { "TeacherID", SelectedTeacher.StaffID},
                //{ "SubjectName", SubjectName},
                { "Notes", Notes},
                { "Location", Location},
            };

            var addedStudyGroup = await StudyGroupService.UpdateStaff(formData);
            if (addedStudyGroup != null)
            {
                await GetStudyGroupsByStaffIdOrCenterId();
                Toast.ShowToastError(SharedResources.UpdatedSuccessfully);
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
        await OpenPushAsyncPage(new StudyGroupStudentListPage(studyGroup));
    }
    #endregion
}