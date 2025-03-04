
using CommunityToolkit.Mvvm.ComponentModel;

namespace WytSky.Mobile.Maui.Skoola.Dtos.Used
{
    public partial class StCourse : StBase
    {
        public string Name { get; set; }
        public string Rate { get; set; }
        public string Category { get; set; }
        public string PriceBefore { get; set; }
        public string PriceAfter { get; set; }
        public string Percentage { get; set; }
        public string NumberOfEnroll { get; set; }
        public bool Isfav { get; set; }
        public bool IsCompleted { get; set; }

        [ObservableProperty]
        public List<StLesson> lessons;

        [ObservableProperty]
        public List<StReview> reviewsCount;

        [ObservableProperty]
        public List<StReview> reviews;

        [ObservableProperty]
        public List<StComment> comments;
    }
}
