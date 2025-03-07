namespace WytSky.Mobile.Maui.Skoola.Models;

public class StudyGroupModel
{
    public string? GroupName { get; set; }
    public string? GroupNameEn { get; set; }
    public string? Name { get { return App.IsArabic ? GroupName : GroupNameEn; } }
    public int? ComplexID { get; set; }
    public int? CenterID { get; set; }
    public int? TeacherID { get; set; }
    public int? SubjectID { get; set; }
    public DateTime? StartDate { get; set; }
    public string Schedule { get; set; }
    public string? Location { get; set; }
    public object? Notes { get; set; }
    public bool? IsActive { get; set; }
    public DateTime? EndDate { get; set; }
    public int? StudentCount { get; set; }
    public object? StudyGroupStudentList { get; set; }
    public object? Schedule1 { get; set; }
    public object? studyGroupSessions { get; set; }
    public int? GroupID { get; set; }
    public string? ComplexName { get; set; }
    public string? CenterName { get; set; }
    public string? TeacherFullName { get; set; }
    public string? SubjectName { get; set; }
    public string? ComplexOrganizationName { get; set; }
    public string? ComplexCountryName { get; set; }
    public string? ComplexRegionName { get; set; }
    public string? ComplexSupervisorFirstName { get; set; }
    public string? CenterComplexName { get; set; }
    public string? TeacherFirstName { get; set; }
    public string? TeacherCenterName { get; set; }
    public string? TeacherComplexName { get; set; }
    public string? TeacherRegionName { get; set; }
    public string? TeacherStaffTypeName { get; set; }
}