using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WytSky.Mobile.Maui.Skoola.Dtos.Used
{
    public partial class StInterest : StBase
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [ObservableProperty]
        public Color backgroundColor = StringExtensions.ToColorFromResourceKey("White");

        [ObservableProperty]
        public Color textColor = StringExtensions.ToColorFromResourceKey("Gray500");

        [ObservableProperty]
        public string image = "add_interest";

        public List<StInterest> Skills { get; set; }
    }
}
