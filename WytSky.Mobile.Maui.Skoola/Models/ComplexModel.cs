using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WytSky.Mobile.Maui.Skoola.Models
{
    public class ComplexModel
    {
        public string ComplexName { get; set; }
        public int? CountryID { get; set; }
        public int? RegionID { get; set; }
        public int? SupervisorID { get; set; }
        public int? ComplexID { get; set; }
        public string? CountryName { get; set; }
        public string? RegionName { get; set; }
        public string? SupervisorFirstName { get; set; }
        public string? OrganizationCountryName { get; set; }
        public string? SupervisorPhoneNumber { get; set; }
        public string? SupervisorUserName { get; set; }
        public int? SupervisorRegionID { get; set; }
        public int? CenterCount { get; set; }
        public string? SupervisorMobile { get; set; }
        public string? SupervisorEmail { get; set; }
        public string? SupervisorFullName { get; set; }
        public DateTime? SupervisorDateOfBirth { get; set; }
        public string? SupervisorCenterName { get; set; }
        public string? SupervisorStaffTypeName { get; set; }
        public bool? IsActive { get; set; }

    }
}
