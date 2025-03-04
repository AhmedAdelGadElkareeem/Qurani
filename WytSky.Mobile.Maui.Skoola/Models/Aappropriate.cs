
namespace WytSky.Mobile.Maui.Skoola.Models
{
    public class Aappropriate
    {
        public DateTime date { get; set; }
        public System.Collections.ObjectModel.ObservableCollection<AappropriatePeriod> periodVm { get; set; }
        //public string DayDate { get { return date.ToString("dddd, dd MMMM yyyy"); } }
        //public System.Collections.ObjectModel.ObservableCollection<Dtos.StPeriod> AvailablePeriod { get; set; } = new System.Collections.ObjectModel.ObservableCollection<Dtos.StPeriod>();
    }
    public class PeriodTechnicalsVm
    {
        public long periodTechnicalId { get; set; }
        public long? WorkshopRegionId { get; set; }
        public long? PeriodId { get; set; }
        public int? maxNumberOfOrders { get; set; }
        public decimal Distance { get; set; }
    }
}
