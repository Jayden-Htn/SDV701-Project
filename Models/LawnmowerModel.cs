using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Models;

public class LawnmowerModel : ILawnmowerModel
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("brandId")]
    public int brandId { get; set; }

    [Required]
    [StringLength(50)]
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [Required]
    [StringLength(255)]
    [JsonPropertyName("description")]
    public string Description { get; set; }

    [Required]
    [JsonPropertyName("price")]
    public decimal Price { get; set; }

    [Required]
    [JsonPropertyName("quantityInStock")]
    public int QuantityInStock { get; set; }

    [Required]
    [JsonPropertyName("photo")]
    public string? Photo { get; set; }

    [Required]
    [StringLength(100)]
    [JsonPropertyName("fuelDetails")]
    public string FuelDetails { get; set; }

    [Required]
    [JsonPropertyName("lastUpdated")]
    public DateTime LastUpdated { get; set; }

    [Required]
    [JsonPropertyName("brand")]
    public BrandModel Brand { get; set; }
    public ICollection<OrderModel>? Orders { get; set; }

    public LawnmowerModel()
    {
        Orders = new List<OrderModel>();
    }
}