using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Models;

public class OrderModel
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("quantity")]
    public int Quantity { get; set; }

    [JsonPropertyName("timeCreated")]
    public DateTime TimeCreated { get; set; }

    [JsonPropertyName("itemPrice")]
    public decimal ItemPrice { get; set; }

    [Required]
    [StringLength(50)]
    [JsonPropertyName("customerName")]
    public string CustomerName { get; set; }

    [StringLength(50)]
    [JsonPropertyName("customerEmail")]
    public string CustomerEmail { get; set; }

    [StringLength(20)]
    [JsonPropertyName("customerPhone")]
    public string CustomerPhone { get; set; }

    [JsonPropertyName("productId")]
    public int ProductId { get; set; }

    [JsonPropertyName("completed")]
    public bool Completed { get; set; }

    [JsonPropertyName("product")]
    public LawnmowerModel? Product { get; set; }
}