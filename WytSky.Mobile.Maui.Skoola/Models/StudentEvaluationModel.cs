using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WytSky.Mobile.Maui.Skoola.Models
{
    public class StudentEvaluationModel
    {
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
        public DateTime? EvaluationDate { get; set; }
        public int? EvaluationType { get; set; }
        public double? MemorizationScore { get; set; }
        public double? TajweedScore { get; set; }
        public double? UnderstandingScore { get; set; }
        public double? AttendanceScore { get; set; }
        public double? BehaviorScore { get; set; }
        public object? OverallScore { get; set; }
        public string? Notes { get; set; }
        public DateTime? CreatedDate { get; set; }
        public object? LastModifiedDate { get; set; }
        public int? SessionID { get; set; }
        public string? SessionGroupName { get; set; }
        public int? EvaluationID { get; set; }
        public string? StudentFullName { get; set; }
        public string? GroupName { get; set; }
        public string? SessionDayOfWeekName { get; set; }
    }
}
