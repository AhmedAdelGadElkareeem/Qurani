using System;
using System.Collections.Generic;
using System.Text;
using WytSky.Mobile.Maui.Skoola.Helpers;

namespace WytSky.Mobile.Maui.Skoola.Dtos
{
    public class StOrderStage : StBase
    {
        public Nullable<long> OrderID { get; set; }
        public Nullable<long> OrderStageID { get; set; }
        public string DescriptionEn { get; set; }
        public string DescriptionAr { get; set; }
        public string Description { get { return Settings.Language == "ar" ? DescriptionAr : DescriptionEn; } }
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

        public string LastEditDate 
        {
            get
            {
                if(ModifiedOn == null)
                {
                    if(CreatedOn != null)
                    {
                        return CreatedOn?.ToString("dd-MM-yyyy");
                    }
                }
                else
                {
                    return ModifiedOn?.ToString("dd-MM-yyyy");
                }
                return "";
            }
        }
        public string LastEditTime
        {
            get
            {
                if (ModifiedOn == null)
                {
                    if (CreatedOn != null)
                    {
                        return CreatedOn?.ToString("hh:mm tt");
                    }
                }
                else
                {
                    return ModifiedOn?.ToString("hh:mm tt");
                }
                return "";
            }
        }
    }
}
