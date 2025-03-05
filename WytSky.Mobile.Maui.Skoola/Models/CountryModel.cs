
namespace WytSky.Mobile.Maui.Skoola.Models
{
    public class CountryModel
    {
        public string CountryName { get; set; }
        public string CountryNameEn { get; set; }
        public string Name { get { return App.IsArabic ? CountryName : CountryNameEn; } }
        public string PhoneCode { get; set; }
        public string CountryCode { get; set; }
        public int? CountryID { get; set; }
        public bool? IsActive { get; set; }
        public override string ToString() => Name;
    }
}
