using System;
using System.Collections.Generic;
using System.Text;

namespace WytSky.Mobile.Maui.Skoola.Models
{
    public class AappropriatePeriod
    {
        public int PeriodId { get; set; }
        public string nameAr { get; set; }
        public string nameEn { get; set; }
        public DateTime date { get; set; }
        public List<PeriodTechnicalsVm> periodTechnicalsVm { get; set; }
        public override string ToString()
        {
            return Helpers.Settings.Language == "ar" ? nameAr : nameEn; ;
        }
    }
}
