using System;
using System.Collections.Generic;
using System.Text;
using WytSky.Mobile.Maui.Skoola.Helpers;

namespace WytSky.Mobile.Maui.Skoola.Dtos
{
    public class StOrderItem : StBase
    {
        public Nullable<long> OrderItemID { get; set; }
        public Nullable<long> ItemID { get; set; }
        public Nullable<long> ItemPicStockID { get; set; }
        public Nullable<double> Price { get; set; } = 0.0;
        public Nullable<double> Discount { get; set; } = 0.0;
        public Nullable<int> Quantity { get; set; } = 0;
        public Nullable<bool> IsCompleted { get; set; } 
        public Nullable<bool> IsCanceled { get; set; } 
        public string Description { get; set; } = "";
        public string ItemCurrencyNameAr { get; set; }
        public string ItemCurrencyNameEn { get; set; }
        public string CurrencyName { get { return Settings.Language == "ar" ? ItemCurrencyNameAr : ItemCurrencyNameEn; } }
        public string ItemNameAr { get; set; }
        public string ItemNameEn { get; set; }
        public string ItemName { get { return Settings.Language == "ar" ? ItemNameAr : ItemNameEn; } }
        public string ItemCatgeoryNameAr { get; set; }
        public string ItemCatgeoryNameEn { get; set; }
        public string CatgeoryName { get { return Settings.Language == "ar" ? ItemCatgeoryNameAr : ItemCatgeoryNameEn; } }
        public string Name { get { return CatgeoryName + " : " + ItemName; } }
        public string ItemPicStockControllername { get; set; }
        public string ItemPicStockPictureFileName { get; set; }
        public string ItemPicurl1 { get { return ItemPicStockControllername + "-" + ItemPicStockID + "-" + ItemPicStockPictureFileName; } }
        public string PriceAfterDiscount { get { return $"{PriceDiscountAfter:N2} {CurrencyName}"; } }
        public double PriceDiscountAfter
        {
            get
            {
                var res = ((Price != null) ? ((double)Price - (Discount != null ? (double)Discount : 0)) : 0);
                if (res > 0)
                    return res;
                else
                    return 0;
            }
        }
        public string TotalPriceDiscount { get { return $"{(PriceDiscountAfter * (Quantity != null ? (int)Quantity : 0)):N2} {CurrencyName}"; } }
        public string TotalPrice { get { return $"{((Price != null ? (double)Price : 0) * (Quantity != null ? (int)Quantity : 0)):N2} {CurrencyName}"; } }
        public bool IsDiscount { get { return (PriceDiscountAfter != Price); } }
    }
}
