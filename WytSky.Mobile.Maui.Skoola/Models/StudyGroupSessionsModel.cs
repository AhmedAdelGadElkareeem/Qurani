

namespace WytSky.Mobile.Maui.Skoola.Models
{
    public class StudyGroupSessionsModel
    {
        public int GroupID { get; set; }
        public string GroupCenterName { get; set; }
        public string GroupComplexName { get; set; }
        public int GroupComplexSupervisorId { get; set; }
        public string GroupTeacherFirstName { get; set; }
        public string GroupTeacherFullName { get; set; }
        public string GroupTeacherUserName { get; set; }
        public string GroupSubjectName { get; set; }
        public int ScheduleID { get; set; }
        public object ScheduleNotes { get; set; }
        public DateTime ScheduleCreatedDate { get; set; }
        public DateTime SessionDate { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string RoomNumber { get; set; }
        public object VirtualLink { get; set; }
        public object Notes { get; set; }
        public int SessionStatus { get; set; }
        public DateTime CreatedDate { get; set; }
        public string DayOfWeekName { get; set; }
        public object StudentAttendance { get; set; }
        public int SessionID { get; set; }
        public string GroupName { get; set; }
        public string ScheduleRoomNumber { get; set; }
        public string WeekDayNameListDayOfWeekName { get; set; }
    }
}
