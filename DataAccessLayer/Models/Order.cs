namespace DataAccessLayer.Models;

public class Order
{
    public int Id { get; set; }
    public int Quantity { get; set; }
    public DateTime TimeCreated { get; set; }
    public decimal ItemPrice { get; set; }
    public required string CustomerName { get; set; }
    public required string CustomerEmail { get; set; }
    public required string CustomerPhone { get; set; }
    public int ProductId { get; set; }
    public bool Completed { get; set; }
    public required Lawnmower Product { get; set; }
}