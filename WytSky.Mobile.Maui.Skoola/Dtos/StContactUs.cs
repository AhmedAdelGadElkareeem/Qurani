using System;
using System.Collections.Generic;
using System.Text;

namespace WytSky.Mobile.Maui.Skoola.Dtos
{
    public class StContactUs : StBase
    {
        public Nullable<long> ContactUsID { get; set; }
        public Nullable<long> ClientID { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public Nullable<bool> IsContact { get; set; }
        public string ClientFullName { get; set; }
    }
}
