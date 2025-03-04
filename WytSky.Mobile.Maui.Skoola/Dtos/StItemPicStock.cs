using System;
using System.Collections.Generic;
using System.Text;

namespace WytSky.Mobile.Maui.Skoola.Dtos
{
    public class StItemPicStock : StBase
    {
        public Nullable<long> ItemID { get; set; }
        public string ItemNameEn { get; set; }
        public Nullable<long> PicStockID { get; set; }
        public string PicStockControllername { get; set; }
        public Nullable<long> ItemPicStocksID { get; set; }
        public string ItemNameAr { get; set; }
        public string PicStockPictureFileName { get; set; }
        public string Picurl1 { get { return PicStockControllername + "-" + ItemPicStocksID + "-" + PicStockPictureFileName; } }
        public string ImageUrl { get { return string.IsNullOrEmpty(Picurl1) || Picurl1 == "--" ? "default_image.png" : Services.ApiServices.BaseImage + Picurl1; } }

    }
}
