using System;
using System.Collections.Generic;
using System.Text;

namespace WytSky.Mobile.Maui.Skoola.Models
{
    public class ItemSample : BaseModel
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
        public decimal PriceAfterDiscount { get { return HasDiscount ? Price - Discount : Price; } }
        public bool HasDiscount { get { return Discount > 0; } }
        #endregion

        #region Filde
        public Guid ItemId { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = "";
        public string RateName { get; set; } = "Very Good";
        public string ImageUrl { get; set; } = "IconMenu.png";
        public string Description { get; set; } = "A wonderful serenity has taken possession of my entire soul, like these sweet mornings of spring which I enjoy with my whole heart. I am alone, and feel the charm of existence in this spot, which was created for the bliss of souls like mine.";
        public decimal Price { get; set; } = 0.0m;
        public decimal Discount { get; set; } = 0.0m;
        public decimal RateValue { get; set; } = 3.5m;
        public decimal NumReviews { get; set; } = 3.5m;
        public DateTime OrderDate { get; set; } = DateTime.UtcNow.AddDays(-2);
        public Color BackColor { get; set; } = Colors.Black;
        #endregion
    }
}
