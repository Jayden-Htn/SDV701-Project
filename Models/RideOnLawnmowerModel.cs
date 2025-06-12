using System.Text.Json.Serialization;

namespace Models;

public class RideOnLawnmowerModel : LawnmowerModel
{
    [JsonPropertyName("topSpeed")]
    public int TopSpeed { get; set; }
}