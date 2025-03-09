using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WytSky.Mobile.Maui.Skoola.Models
{
    public class ScheduleModel
    {
        public int? GroupID { get; set; }
        public string? GroupCenterName { get; set; }
        public string? GroupCenterComplexName { get; set; }
        public string? StartTime { get; set; }
        public string? EndTime { get; set; }
        public string? RoomNumber { get; set; }
        public object? Notes { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public object? LastModifiedDate { get; set; }
        public string? DayOfWeekName { get; set; }
        public int? ScheduleID { get; set; }
        public string? GroupName { get; set; }
        public string? WeekDayNameListDayOfWeekName { get; set; }
    }
}
