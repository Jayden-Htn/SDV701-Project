namespace DataAccessLayer.Models;

public class Lawnmower
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public decimal Price { get; set; }
    public int QuantityInStock { get; set; }
    public string? Photo { get; set; }
    public required string FuelDetails { get; set; }
    public DateTime LastUpdated { get; set; }
    public int BrandId { get; set; }
    public required Brand Brand { get; set; }
    public ICollection<Order>? Orders { get; set; }
}