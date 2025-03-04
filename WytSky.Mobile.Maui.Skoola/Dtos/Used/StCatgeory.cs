using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Text;
using WytSky.Mobile.Maui.Skoola.Helpers;

namespace WytSky.Mobile.Maui.Skoola.Dtos
{
    public partial class StCatgeory : StBase
    {
        public Nullable<decimal> DiscountAmount { get; set; }
        public Nullable<decimal> DiscountPercentage { get; set; }
        public string ParentPicStockControllername { get; set; }
        public string PicStockControllername { get; set; }
        public string PicStockPictureFileName { get; set; }
        public string ParentNameAr { get; set; }
        public Nullable<long> CatgeoryID { get; set; }
        public Nullable<long> PicStockID { get; set; }
        public Nullable<long> ParentID { get; set; }
        public Nullable<bool> HasSubCatgeory { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string DescriptionEn { get; set; }
        public string DescriptionAr { get; set; }
        public string Picurl1 { get; set; }
        public Nullable<int> ShowOrder { get; set; }
        public Nullable<double> Discount { get; set; }
        public System.Collections.ObjectModel.ObservableCollection<StItem> Items { get; set; }
        public string Name { get { return Settings.Language == "ar" ? NameAr : NameEn; } }
        public string Description { get { return Settings.Language == "ar" ? DescriptionAr : DescriptionEn; } }
        public string CatgeoryPicurl1 { get { return PicStockControllername + "-" + PicStockID + "-" + PicStockPictureFileName; } }
        public string CatgeoryImageUrl { get { return string.IsNullOrEmpty(CatgeoryPicurl1) || CatgeoryPicurl1 == "--" ? "default_image.png" : Services.ApiServices.BaseImage + CatgeoryPicurl1; } }
        public string ImageUrl { get { return string.IsNullOrEmpty(Picurl1) || Picurl1 == "--" ? "default_image.png" : Services.ApiServices.BaseImage + Picurl1; } }

        [ObservableProperty]
        public bool isSelected;
    }
}
