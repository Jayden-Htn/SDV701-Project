using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Models;

public class BrandModel
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [Required]
    [StringLength(20)]
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    [StringLength(255)]
    [JsonPropertyName("description")]
    public required string Description { get; set; }

    [JsonPropertyName("lawnmowers")]
    public IList<LawnmowerModel>? Lawnmowers { get; set; }

    public BrandModel()
    {
        Lawnmowers = new List<LawnmowerModel>();
    }
}