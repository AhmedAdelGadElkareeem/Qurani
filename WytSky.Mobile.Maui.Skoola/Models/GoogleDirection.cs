
using System.Text.Json.Serialization;

namespace WytSky.Mobile.Maui.Skoola.Models
{
    public class GeocodedWaypoint
    {
        [JsonPropertyName("geocoder_status")]
        public string GeocoderStatus { get; set; }

        [JsonPropertyName("place_id")]
        public string PlaceId { get; set; }

        [JsonPropertyName("types")]
        public IList<string> Types { get; set; }
    }

    public class Northeast
    {

        [JsonPropertyName("lat")]
        public double Lat { get; set; }

        [JsonPropertyName("lng")]
        public double Lng { get; set; }
    }

    public class Southwest
    {

        [JsonPropertyName("lat")]
        public double Lat { get; set; }

        [JsonPropertyName("lng")]
        public double Lng { get; set; }
    }

    public class Bounds
    {

        [JsonPropertyName("northeast")]
        public Northeast Northeast { get; set; }

        [JsonPropertyName("southwest")]
        public Southwest Southwest { get; set; }
    }

    public class DistanceOp
    {

        [JsonPropertyName("text")]
        public string Text { get; set; }

        [JsonPropertyName("value")]
        public int Value { get; set; }
    }

    public class Duration
    {

        [JsonPropertyName("text")]
        public string Text { get; set; }

        [JsonPropertyName("value")]
        public int Value { get; set; }
    }

    public class EndLocation
    {

        [JsonPropertyName("lat")]
        public double Lat { get; set; }

        [JsonPropertyName("lng")]
        public double Lng { get; set; }
    }

    public class StartLocation
    {

        [JsonPropertyName("lat")]
        public double Lat { get; set; }

        [JsonPropertyName("lng")]
        public double Lng { get; set; }
    }

    public class Polyline
    {

        [JsonPropertyName("points")]
        public string Points { get; set; }
    }

    public class Step
    {

        [JsonPropertyName("distance")]
        public DistanceOp Distance { get; set; }

        [JsonPropertyName("duration")]
        public Duration Duration { get; set; }

        [JsonPropertyName("end_location")]
        public EndLocation EndLocation { get; set; }

        [JsonPropertyName("html_instructions")]
        public string HtmlInstructions { get; set; }

        [JsonPropertyName("polyline")]
        public Polyline Polyline { get; set; }

        [JsonPropertyName("start_location")]
        public StartLocation StartLocation { get; set; }

        [JsonPropertyName("travel_mode")]
        public string TravelMode { get; set; }

        [JsonPropertyName("maneuver")]
        public string Maneuver { get; set; }
    }

    public class Leg
    {

        [JsonPropertyName("distance")]
        public DistanceOp Distance { get; set; }

        [JsonPropertyName("duration")]
        public Duration Duration { get; set; }

        [JsonPropertyName("end_address")]
        public string EndAddress { get; set; }

        [JsonPropertyName("end_location")]
        public EndLocation EndLocation { get; set; }

        [JsonPropertyName("start_address")]
        public string StartAddress { get; set; }

        [JsonPropertyName("start_location")]
        public StartLocation StartLocation { get; set; }

        [JsonPropertyName("steps")]
        public IList<Step> Steps { get; set; }

        [JsonPropertyName("traffic_speed_entry")]
        public IList<object> TrafficSpeedEntry { get; set; }

        [JsonPropertyName("via_waypoint")]
        public IList<object> ViaWaypoint { get; set; }
    }

    public class OverviewPolyline
    {

        [JsonPropertyName("points")]
        public string Points { get; set; }
    }

    public class Route
    {

        [JsonPropertyName("bounds")]
        public Bounds Bounds { get; set; }

        [JsonPropertyName("copyrights")]
        public string Copyrights { get; set; }

        [JsonPropertyName("legs")]
        public IList<Leg> Legs { get; set; }

        [JsonPropertyName("overview_polyline")]
        public OverviewPolyline OverviewPolyline { get; set; }

        [JsonPropertyName("summary")]
        public string Summary { get; set; }

        [JsonPropertyName("warnings")]
        public IList<object> Warnings { get; set; }

        [JsonPropertyName("waypoint_order")]
        public IList<object> WaypointOrder { get; set; }
    }

    public class GoogleDirection
    {

        [JsonPropertyName("geocoded_waypoints")]
        public IList<GeocodedWaypoint> GeocodedWaypoints { get; set; }

        [JsonPropertyName("routes")]
        public IList<Route> Routes { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }
    }
}
