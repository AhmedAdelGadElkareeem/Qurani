using System;
using System.Collections.Generic;
using System.Text;

namespace WytSky.Mobile.Maui.Skoola.Models
{
    public class OrderItemModel
    {
        public string OrderID { get; set; }
        public string ItemID { get; set; }
        public string Price { get; set; }
        public string Discount { get; set; }
        public string Quantity { get; set; }
    }
}
