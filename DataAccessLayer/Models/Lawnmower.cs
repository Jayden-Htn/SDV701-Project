namespace DataAccessLayer.Models;

public class Lawnmower
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int QuantityInStock { get; set; }
    public string? Photo { get; set; }
    public string FuelDetails { get; set; }
    public DateTime LastUpdated { get; set; }
    public int BrandId { get; set; }
    public Brand Brand { get; set; }
    public string Type { get; set; }
    public ICollection<Order>? Orders { get; set; }
}