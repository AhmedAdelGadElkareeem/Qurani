using System;
using System.Collections.Generic;
using System.Text;
using WytSky.Mobile.Maui.Skoola.Helpers;

namespace WytSky.Mobile.Maui.Skoola.Dtos
{
    public class CatgeoryDto
    {
        public string picsurl { get; set; }
        public object PicStockID { get; set; }
        public Nullable<long> DaitCatgeoryID { get; set; }
        public object PicStocksFkpK { get; set; }
        public object PicStocksControllername { get; set; }
        public string PicStocksPictureFileName { get; set; }
        public object Notes { get; set; }
        public string DaitCatgeoryDesc { get; set; }
        public string DaitCatgeoryDesc1 { get; set; }
        public string ImageUrl { get { return string.IsNullOrEmpty(picsurl) ? "default_image.png" : Services.ApiServices.BaseImage + picsurl; } }
        public string Name { get { return Settings.Language  == "ar" ? DaitCatgeoryDesc : DaitCatgeoryDesc1; } }
        public System.Collections.ObjectModel.ObservableCollection<Dtos.ItemDto> Items { get; set; }
    }
}
