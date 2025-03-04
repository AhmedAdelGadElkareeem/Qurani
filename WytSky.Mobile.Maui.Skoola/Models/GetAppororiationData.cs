using System;
using System.Collections.Generic;
using System.Text;

namespace WytSky.Mobile.Maui.Skoola.Models
{
    public class GetAppororiationData
    {
        public long itemId { get; set; }
        public System.Collections.ObjectModel.ObservableCollection<Dtos.StWorkshopRegion> StWorkshopRegionViewModel { get; set; }
        public DateTime dateFrom { get; set; }
        public DateTime dateTo { get; set; }
    }
}
