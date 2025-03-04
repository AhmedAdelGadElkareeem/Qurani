using CommunityToolkit.Mvvm.ComponentModel;

namespace WytSky.Mobile.Maui.Skoola.Dtos.Used
{
    public partial class StReview : StBase
    {
        public string Number { get; set; }

        [ObservableProperty]
        public bool isSelected;

        public string ReviewerName { get; set; }
        public string Time { get; set; }
        public string Description { get; set; }

    }
}
