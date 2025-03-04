using System.Collections.ObjectModel;

namespace WytSky.Mobile.Maui.Skoola.Dtos
{
    public class NearestDto
    {
        public string CategoryName { get; set; }
        public ObservableCollection<StCatgeory> Nearests { get; set; }
    }
}
