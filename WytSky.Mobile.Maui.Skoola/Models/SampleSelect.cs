using System;
using System.Collections.Generic;
using System.Text;

namespace WytSky.Mobile.Maui.Skoola.Models
{
    public class SampleSelect
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string NameAr { get; set; } = "";
        public string NameEn { get; set; } = "";
        public string Name { get { return Helpers.Settings.Language == "ar" ? NameAr : NameEn; } }
        public decimal Price { get; set; } = 0.0m;
        public override string ToString()
        {
            return Price > 0 ? Name + " (" + Price + ") " : Name;
        }
    }
}
