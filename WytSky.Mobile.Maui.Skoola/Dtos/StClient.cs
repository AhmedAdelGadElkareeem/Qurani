using System;
using System.Collections.Generic;
using System.Text;

namespace WytSky.Mobile.Maui.Skoola.Dtos
{
    public class StClient : StBase
    {
        public Nullable<long> ClientID { get; set; }
        public Nullable<long> ClientTypeID { get; set; } = 2;
        public Nullable<long> CityID { get; set; }
        public string CityRegionNameAr { get; set; }
        public object PicStockID { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Phone2 { get; set; }
        public string Email { get; set; }
        public string Email2 { get; set; }
        public string FbToken { get; set; }
        public string HasPassword { get; set; }
        public string ConfirmPassword { get; set; }
        public string ClientTypeNameAr { get; set; }
        public string ClientTypeNameEn { get; set; }
        public string PicStockControllername { get; set; }
        public string SocialID { get; set; }
    }

    public class StClientSocial
    {
        public Nullable<long> ClientTypeID { get; set; } = 2;
        public Nullable<long> CityID { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Phone2 { get; set; }
        public string Email { get; set; }
        public string Email2 { get; set; }
        public string FbToken { get; set; }
        public string HasPassword { get; set; }
        public string ConfirmPassword { get; set; }
        public string SocialID { get; set; }
    }
}   
