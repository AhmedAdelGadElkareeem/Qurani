
using System.Text.Json.Serialization;
using WytSky.Mobile.Maui.Skoola.Helpers;


namespace WytSky.Mobile.Maui.Skoola.Dtos
{
    public class StOrder : StBase
    {
        public Nullable<long> OrderID { get; set; }
        public Nullable<long> CityID { get; set; }
        public Nullable<long> ItemID { get; set; }
        public Nullable<long> CatgeoryID { get; set; }
        public Nullable<long> PromoCodeID { get; set; }
        public Nullable<long> ClientID { get; set; }
        public Nullable<long> OrderStageID { get; set; }
        public Nullable<double> MapLatitude { get; set; }
        public Nullable<double> MapLangitude { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string ProviderNotes { get; set; }
        public Nullable<double> Amount { get; set; }
        public Nullable<double> FinalAmount { get; set; }
        public Nullable<double> Discount { get; set; }
        public Nullable<double> PaidUp { get; set; }
        public Nullable<double> ItemEditHour { get; set; }
        public Nullable<bool> IsCompleted { get; set; }
        public Nullable<bool> IsCanceled { get; set; }
        public string MapAddress { get; set; }
        public string AddressDetail { get; set; }
        public string Address { get { return MapAddress + "   " + AddressDetail; } }
        public string ItemNameAr { get; set; }
        public string ItemNameEn { get; set; }
        public string ItemName { get { return Settings.Language == "ar" ? CatgeoryNameAr + " : " + ItemNameAr : CatgeoryNameEn + " : " + ItemNameEn; } }
        public string PromoCode { get; set; }
        public Nullable<bool> CanEdit { get; set; }
        public Nullable<bool> IsApproval { get; set; }
        public string Approval { get { return IsApproval == true ? AppResources.SharedResources.Text_Approval : AppResources.SharedResources.Text_AwaitingApproval; } }
        public string ClientFullName { get; set; }
        public Nullable<int> OrderStageShowOrder { get; set; }
        public string OrderStageDescriptionEn { get; set; }
        public string OrderStageDescriptionAr { get; set; }
        public string OrderStageDescription { get { return Settings.Language == "ar" ? OrderStageDescriptionAr : OrderStageDescriptionEn; } }
        public string ItemCurrencyNameAr { get; set; }
        public string ItemCurrencyNameEn { get; set; }
        public string CurrencyName { get { return Settings.Language == "ar" ? ItemCurrencyNameAr : ItemCurrencyNameEn; } }
        public string CityNameAr { get; set; }
        public Nullable<DateTime> OrderDate { get; set; }
        public string OrderDateString
        {
            get
            {
                if (OrderDate.HasValue)
                    return OrderDate.Value.ToString("dd MMM, hh:mm tt");
                else return "";
            }
        }
        [JsonPropertyName("ItemCatgeoryNameAr")]
        public string CatgeoryNameAr { get; set; }
        [JsonPropertyName("ItemCatgeoryNameEn")]
        public string CatgeoryNameEn { get; set; }
        public string Status
        {
            get
            {
                if (IsCanceled == true)
                    return AppResources.SharedResources.Text_Canceled;
                else if (IsCompleted == true)
                    return AppResources.SharedResources.Text_Completed;
                else
                    return AppResources.SharedResources.Text_InProcess;
            }
        }

        public bool CanEditOrder { get { return IsCanceled != true && CanEdit == true && (DateTime.Now.AddHours((int)ItemEditHour) < OrderDate?.Date.Add(TimeSpan.FromHours(24))); } }
    }
}
