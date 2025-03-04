using System;
using System.Collections.Generic;
using System.Text;

namespace WytSky.Mobile.Maui.Skoola.Models
{
    public class ItemSampleSelect
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string NameAr { get; set; } = "";
        public string NameEn { get; set; } = "";
        public string Name { get { return Helpers.Settings.Language == "ar" ? NameAr : NameEn; } }
        public System.Collections.ObjectModel.ObservableCollection<Models.SampleSelect> Items { get; set; } = new System.Collections.ObjectModel.ObservableCollection<Models.SampleSelect>();
    }
}
