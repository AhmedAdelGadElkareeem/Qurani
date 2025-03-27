
using CommunityToolkit.Mvvm.ComponentModel;

namespace WytSky.Mobile.Maui.Skoola.Models;

public partial class StudyGroupStudentList : ObservableObject
{
    [ObservableProperty] public long? studyGroupStudentNumber;
    public int? StudentID { get; set; }
    public string? StudentCenterName { get; set; }
    public string? StudentComplexName { get; set; }
    public string? StudentCountryName { get; set; }
    public string? StudentRegionName { get; set; }
    public string? StudentGroupName { get; set; }
    public int? GroupID { get; set; }
    public string? GroupCenterName { get; set; }
    public string? GroupComplexName { get; set; }
    public string? GroupTeacherFirstName { get; set; }
    public string? GroupSubjectName { get; set; }
    public DateTime? JoinDate { get; set; }
    public string? Status { get; set; }
    public int? ID { get; set; }
    public string? StudentFullName { get; set; }
    public string? GroupName { get; set; }



    public double? TajweedScore { get; set; }
    public double? MemorizationScore { get; set; }
    public double? UnderstandingScore { get; set; }
    public double? BehaviorScore { get; set; }
    public double? AttendanceScore { get; set; }
    public string? Note { get; set; }
}
