
namespace WytSky.Mobile.Maui.Skoola.Models
{
    public class CentersModel 
    {
        public int? CenterID { get; set; }
        public int? ComplexID { get; set; }
        public string? CenterName { get; set; }
        public string? CenterNameEn { get; set; }
        public string? Name { get{ return App.IsArabic ? CenterName : CenterNameEn; } }
        public string? Address { get; set; }
        public bool? IsActive { get; set; }
        public string? City { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public int? SupervisorID { get; set; }
        public string? Notes { get; set; }
        public int? StudyGroupCount { get; set; }
        public string? ComplexName { get; set; }
        public string? ComplexRegionName { get; set; }
        public string? ComplexRegionCountryName { get; set; }
    }
}
