using System;
namespace WytSky.Mobile.Maui.Skoola.Models
{
    public class OrderModel
    {
        public string Id { get; set; }
        public string OrderDate { get; set; }
        public string MapAddress { get; set; }
        public string AddressDetail { get; set; }
        public string MapLatitude { get; set; }
        public string MapLangitude { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Amount { get; set; }
        public string Discount { get; set; }
        public string FinalAmount { get; set; }
        public string Notes { get; set; }
        public string ClientID { get; set; }
    }
}
