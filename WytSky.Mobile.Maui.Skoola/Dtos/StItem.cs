using System;
using System.Collections.Generic;
using System.Text;
using WytSky.Mobile.Maui.Skoola.Helpers;

namespace WytSky.Mobile.Maui.Skoola.Dtos
{
    public class StItem : StBase
    {
        #region PrivateField
        private bool _IsInCart = false;
        private bool _IsFavoret = false;
        private long _Quantity = 0;
        private double _TotalPrice = 0;
        private double _TotalPriceDiscount = 0;
        private string _STotalPrice = "";
        private bool isSelected = false;
        private double _ItemTotalPrice = 0;
        #endregion

        #region Properties
        public bool IsFavoret
        {
            get => _IsFavoret;
            set => SetProperty(ref _IsFavoret, value);
        }
        public bool IsInCart
        {
            get => _IsInCart;
            set => SetProperty(ref _IsInCart, value);
        }
        public long Quantity
        {
            get => _Quantity;
            set 
            { 
                SetProperty(ref _Quantity, value);
                TotalPriceDiscount = value * PriceDiscountAfter;
                ItemTotalPrice = value * PriceDiscountAfter;
                TotalPrice = value * (Price != null ? (double)Price : 0);
                STotalPrice = $"{(value * (Price != null ? (double)Price : 0)):N2} {CurrencyName}";
            }
        }
        public double ItemTotalPrice
        {
            get => _ItemTotalPrice;
            set => SetProperty(ref _ItemTotalPrice, value);
        }
        public bool IsSelected
        {
            get => isSelected;
            set => SetProperty(ref isSelected, value);
        }
        public double TotalPrice
        {
            get => _TotalPrice;
            set => SetProperty(ref _TotalPrice, value);
        }
        public string STotalPrice
        {
            get => _STotalPrice;
            set => SetProperty(ref _STotalPrice, value);
        }
        public double TotalPriceDiscount
        {
            get => _TotalPriceDiscount;
            set => SetProperty(ref _TotalPriceDiscount, value);
        }
        #endregion

        public Nullable<long> ItemID { get; set; }
        public Nullable<long> CatgeoryID { get; set; }
        public string CatgeoryNameAr { get; set; }
        public string CatgeoryNameEn { get; set; }
        public Nullable<long> PicStockID { get; set; }
        public Nullable<long> CatgeoryPicStockID { get; set; }
        public Nullable<int> CatgeoryShowOrder { get; set; }
        public Nullable<bool> CatgeoryIsActive { get; set; }
        public Nullable<bool> CatgeoryIsDelete { get; set; }
        public string CatgeoryPicStockControllername { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string CurrencyNameAr { get; set; }
        public string CurrencyNameEn { get; set; }
        public string CurrencyName { get { return Settings.Language == "ar" ? CurrencyNameAr : CurrencyNameEn; } }
        public string UniteNameAr { get; set; }
        public string UniteNameEn { get; set; }
        public string UniteName { get { return Settings.Language == "ar" ? UniteNameAr : UniteNameEn; } }
        public string DescriptionEn { get; set; }
        public string DescriptionAr { get; set; }
        public string Description { get { return Settings.Language == "ar" ? DescriptionAr : DescriptionEn; } }
        public string Picurl1 { get { return PicStockControllername + "-" + PicStockID + "-" + PicStockPictureFileName; } }
        public string ImageUrl { get { return string.IsNullOrEmpty(Picurl1) || Picurl1 == "--" ? "default_image.png" : Services.ApiServices.BaseImage + Picurl1; } }
        public string CatgeoryPicurl1 { get { return CatgeoryPicStockControllername + "-" + CatgeoryPicStockID + "-" + CatgeoryPicStockPictureFileName; } }
        public string CatgeoryImageUrl { get { return string.IsNullOrEmpty(CatgeoryPicurl1) || Picurl1 == "--" ? "default_image.png" : Services.ApiServices.BaseImage + Picurl1; } }
        public int? UniteIsquantable { get; set; }
        public Nullable<bool> IsGenralTrend { get; set; }
        public Nullable<long> ShowOrder { get; set; }
        public Nullable<long> CatgeoryTrendID { get; set; }
        public string TrendCatgeoryNameEn { get; set; }
        public Nullable<double> RateValue { get; set; } = 0.0;
        public Nullable<double> CatgeoryDiscountAmount { get; set; } = 0.0;
        public Nullable<double> CatgeoryDiscountPercentage { get; set; } = 0.0;
        public double CatgeoryDiscount { get { return CatgeoryDiscountAmount != null ? (double)CatgeoryDiscountAmount : 0.0 + ((double)(Price != null ? Price : 0) * (CatgeoryDiscountPercentage != null ? (double)CatgeoryDiscountPercentage : 0.0)); } }
        public Nullable<double> DiscountAmount { get; set; } = 0.0;
        public Nullable<double> DiscountPercentage { get; set; } = 0.0;
        public double Discount { get { return DiscountAmount != null ? (double)DiscountAmount : 0.0 + ((double)(Price != null ? Price : 0) * (DiscountPercentage != null ? (double)DiscountPercentage : 0.0)); } }
        public Nullable<double> Price { get; set; } = 20.0;
        public string PicStockControllername { get; set; }
        public string PicStockPictureFileName { get; set; }
        public string CatgeoryPicStockPictureFileName { get; set; }
        public string Name { get { return Settings.Language == "ar" ? NameAr : NameEn; } }
        public string CatgeoryName { get { return Settings.Language == "ar" ? CatgeoryNameAr : CatgeoryNameEn; } }
        public string PriceAfterDiscount { get { return $"{PriceDiscountAfter:N2} {CurrencyName} " + (string.IsNullOrEmpty(UniteName) ? "" : $" /  {UniteName}"); } } 
        public double PriceDiscountAfter 
        { 
            get 
            {
                var res = ((Price != null) ? ((double)Price - Discount - CatgeoryDiscount) : 0);
                if (res > 0)
                    return res;
                else
                    return 0;
            } 
        } 
        public bool IsDiscount { get { return (PriceDiscountAfter != Price); } }

        // offer properties
        public string Image { get; set; }
        public string ResturantImage { get; set; }
        public double PriceBefore { get; set; }
        public double PriceAfter { get; set; }
    }
}
