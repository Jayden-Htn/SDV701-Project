namespace DataAccessLayer.Models;

public class Order
{
    public int Id { get; set; }
    public int Quantity { get; set; }
    public DateTime TimeCreated { get; set; }
    public decimal ItemPrice { get; set; }
    public string CustomerName { get; set; }
    public string CustomerEmail { get; set; }
    public string CustomerPhone { get; set; }
    public int ProductId { get; set; }
    public bool Completed { get; set; }
    public Lawnmower Product { get; set; }
}