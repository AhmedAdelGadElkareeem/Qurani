using System.Text.Json.Serialization;

namespace WytSky.Mobile.Maui.Skoola.Models
{
    public class GooglePlaceAutoCompletePrediction
    {
        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }
        
        [JsonPropertyName("place_id")]
        public string PlaceId { get; set; }

        [JsonPropertyName("reference")]
        public string Reference { get; set; }

        [JsonPropertyName("structured_formatting")]
        public StructuredFormatting StructuredFormatting { get; set; }

    }

    public class StructuredFormatting
    {
        [JsonPropertyName("main_text")]
        public string MainText { get; set; }

        [JsonPropertyName("secondary_text")]
        public string SecondaryText { get; set; }
    }

    public class GooglePlaceAutoCompleteResult
    {
        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("predictions")]
        public List<GooglePlaceAutoCompletePrediction> AutoCompletePlaces { get; set; }
    }
}