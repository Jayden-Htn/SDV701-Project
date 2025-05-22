namespace DataAccessLayer.Models;

public class Brand
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public virtual IList<Lawnmower>? Lawnmowers { get; set; }
}