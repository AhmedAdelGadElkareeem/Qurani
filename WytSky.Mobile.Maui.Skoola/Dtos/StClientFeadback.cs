using System;
using System.Collections.Generic;
using System.Text;

namespace WytSky.Mobile.Maui.Skoola.Dtos
{
    public class StClientFeadback : StBase
    {
        public Nullable<long> FeadbackQuestionID { get; set; }
        public Nullable<long> OrderItemID { get; set; }
        public Nullable<long> OrderClientID { get; set; }
        public string ClientFullName { get; set; }
        public string FeadbackQuestionEn { get; set; }
        public string FeadbackQuestionAr { get; set; }
        public Nullable<long> OrderID { get; set; }
        public Nullable<double> Rate { get; set; }
        public Nullable<long> ClientFeadbackID { get; set; }
        public string OrderDescription { get; set; }
    }
}
