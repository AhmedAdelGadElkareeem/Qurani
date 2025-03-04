using WytSky.Mobile.Maui.Skoola.Helpers;
using WytSky.Mobile.Maui.Skoola.Models;

namespace WytSky.Mobile.Maui.Skoola.Dtos
{
    public class ItemDto : BaseModel
    {
        #region PrivateField
        private string _FavoriteImage = "IFHeartGray.png";
        private bool _IsFavorite = false;
        private int _Quantity = 0;
        #endregion

        #region Properties
        public bool IsFavorite
        {
            get => _IsFavorite;
            set => SetProperty(ref _IsFavorite, value);
        }
        public string FavoriteImage
        {
            get => _FavoriteImage;
            set => SetProperty(ref _FavoriteImage, value);
        }
        public int Quantity
        {
            get => _Quantity;
            set => SetProperty(ref _Quantity, value);
        }
        public string ImageUrl { get { return string.IsNullOrEmpty(picsurl) ? "default_image.png" : Services.ApiServices.BaseImage + picsurl; } }
        #endregion

        public string picsurl { get; set; }
        public string DaitItem { get; set; }
        public string DaitIteme { get; set; }
        public string Name { get { return Settings.Language == "ar" ? DaitItem : DaitIteme; } }
        public string ItmSalPrice { get; set; }
        public Nullable<int> DaitCatgeoryID { get; set; }
        public object Notes { get; set; }
        public object Wid { get; set; }
        public object Thickness { get; set; }
        public object Barcodu { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<DateTime> ModifiedOn { get; set; }
        public object CreatedBy { get; set; }
        public object CreatedOn { get; set; }
        public object DaitidUser { get; set; }
        public Nullable<int> DaitidComp { get; set; }
        public string DaitCatgeoryItemsDaitCatgeoryDesc { get; set; }
        public string DaitCatgeoryItemsDaitCatgeoryDesc1 { get; set; }
        public string PicStocks1PictureFileName { get; set; }
        public string picsurl1 { get; set; }

        public decimal PriceAfterDiscount { get; set; } = 52.7m;
        public decimal RateValue { get; set; } = 52.7m;
        public decimal NumReviews { get; set; } = 52;
        public DateTime OrderDate { get; set; } = DateTime.UtcNow.AddDays(-2);
        public string RateName { get; set; } = "Very Good";
        public string Description { get; set; } = "A wonderful serenity has taken possession of my entire soul, like these sweet mornings of spring which I enjoy with my whole heart. I am alone, and feel the charm of existence in this spot, which was created for the bliss of souls like mine.";

    }
}
