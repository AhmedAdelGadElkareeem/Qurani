using WytSky.Mobile.Maui.Skoola.AppResources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WytSky.Mobile.Maui.Skoola.Dtos.Used
{
    public class StPayment : StBase
    {
        public string Name { get; set; }
        public string Status
        {
            get
            {
                if (IsConnected)
                    return SharedResources.Text_Connected;
                return SharedResources.Text_NotConnected;
            }
        }
        public string Image { get; set; }

        private bool isConnected;
        public bool IsConnected
        {
            get { return isConnected; }
            set { isConnected = value; OnPropertyChanged(); }
        }
    }
}
