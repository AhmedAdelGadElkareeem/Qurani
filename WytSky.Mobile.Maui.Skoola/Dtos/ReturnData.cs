using System;
using System.Collections.Generic;
using System.Text;

namespace WytSky.Mobile.Maui.Skoola.Dtos
{
    public class ReturnData
    {
        public Nullable<int> rowsAffected { get; set; }
        public string clientScript { get; set; }
        public Nullable<long> OrderID { get; set; }
        public Nullable<long> OrderStageBaseID { get; set; }
    }
}
