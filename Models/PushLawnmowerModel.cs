using System.Text.Json.Serialization;

namespace Models;

public class PushLawnmowerModel : LawnmowerModel
{
    [JsonPropertyName("topSpeed")]
    public int TopSpeed { get; set; }
}