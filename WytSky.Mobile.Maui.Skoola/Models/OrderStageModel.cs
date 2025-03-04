using System;
using System.Collections.Generic;
using System.Text;

namespace WytSky.Mobile.Maui.Skoola.Models
{
    public class OrderStageModel
    {
        public Nullable<long> OrderStageBaseID { get; set; }
        public string DescriptionEn { get; set; }
        public string DescriptionAr { get; set; }
        public string Description { get { return Helpers.Settings.Language == "ar" ? DescriptionAr : DescriptionEn; } }
        public Nullable<long> ShowOrder { get; set; }
        public Nullable<long> ProgressValue { get; set; } = 0;
        public Nullable<decimal> AdditionalCost { get; set; }
        public Nullable<bool> MustClientApprove { get; set; } = false;
        public Nullable<bool> MustProviderApprove { get; set; } = false;
        public Nullable<bool> ClientApprove { get; set; }
        public Nullable<bool> ProviderApprove { get; set; }
        public string ClientNotes { get; set; }
        public string ProviderNotes { get; set; }
        public string OrderDescription { get; set; }
        public string OrderID { get; set; }
    }
}
