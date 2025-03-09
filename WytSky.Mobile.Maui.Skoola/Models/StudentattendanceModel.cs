

namespace WytSky.Mobile.Maui.Skoola.Models
{
    public class StudentattendanceModel
    {
        public int SessionID { get; set; }
        public string SessionGroupName { get; set; }
        public int StudentID { get; set; }
        public string StudentCenterName { get; set; }
        public string StudentComplexName { get; set; }
        public string StudentCountryName { get; set; }
        public string StudentRegionName { get; set; }
        public string StudentGroupName { get; set; }
        public int GroupID { get; set; }
        public string GroupCenterName { get; set; }
        public string GroupComplexName { get; set; }
        public string GroupTeacherFirstName { get; set; }
        public string GroupSubjectName { get; set; }
        public DateTime AttendanceDate { get; set; }
        public object Status { get; set; }
        public string TimeIn { get; set; }
        public string TimeOut { get; set; }
        public string Notes { get; set; }
        public int AttendanceID { get; set; }
        public string SessionDayOfWeekName { get; set; }
        public string StudentFullName { get; set; }
        public string GroupName { get; set; }
    }
}
