
namespace WytSky.Mobile.Maui.Skoola.Models
{
    public class RegionModel
    {
        public string RegionName { get; set; }
        public string RegionNameEn { get; set; }
        public string Name { get { return App.IsArabic ? RegionName : RegionNameEn; } }
        public string CountryName { get; set; }
        public string PhoneCode { get; set; }
        public string CountryCode { get; set; }
        public int? CountryID { get; set; }
        public int? RegionID { get; set; }
        public bool? IsActive { get; set; }
        public override string ToString() => RegionName;
    }
}
