using System.Text.Json.Serialization;

namespace Models;

public class PushLawnmowerModel : LawnmowerModel
{
    [JsonPropertyName("weight")]
    public int Weight { get; set; }
}