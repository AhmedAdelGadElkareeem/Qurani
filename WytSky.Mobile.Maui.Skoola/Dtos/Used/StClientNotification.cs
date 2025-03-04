using System;
using System.Collections.Generic;
using System.Text;
using WytSky.Mobile.Maui.Skoola.Helpers;

namespace WytSky.Mobile.Maui.Skoola.Dtos.Used
{
    public class StClientNotification : StBase
    {
        #region PrivateField
        private Color _BackgroundColor;
        private Nullable<bool> _IsRead = false;
        #endregion

        #region Properties
        public Color BackgroundColor
        {
            get => _BackgroundColor;
            set => SetProperty(ref _BackgroundColor, value);
        }
        public Nullable<bool> IsRead
        {
            get => _IsRead;
            set
            {
                SetProperty(ref _IsRead, value);
                BackgroundColor = (value == true) ? Color.FromRgba("#FFFFFF") : Color.FromRgba("#2F994612");
            }
        }
        #endregion

        public Nullable<long> ClientNotificationID { get; set; }
        public Nullable<long> ClientID { get; set; }
        public Nullable<long> PicStockID { get; set; }
        public string SubjectAr { get; set; }
        public string SubjectEn { get; set; }
        public string Subject { get { return Settings.Language == "ar" ? SubjectAr : SubjectEn; } }
        public string ContentAr { get; set; }
        public string ContentEn { get; set; }
        public string Content { get { return Settings.Language == "ar" ? ContentAr : ContentEn; } }
        public Nullable<DateTime> ExpiryDate { get; set; }
        public string TechnicalFullName { get; set; }
        public string PicStockControllername { get; set; }
        public string CreatedOnString { get { return CreatedOn.ToString(); } set { value = CreatedOn.ToString(); } }
    }
}
