﻿namespace Models;

public interface ILawnmowerModel
{
    public int Id { get; set; }
    public int BrandId { get; set; }
    public string Name { get; set; }

    public string Description { get; set; }
    public decimal Price { get; set; }
    public int QuantityInStock { get; set; }
    public string? Photo { get; set; }
    public string FuelDetails { get; set; }
    public DateTime LastUpdated { get; set; }
    public string Type { get; set; }
    public BrandModel Brand { get; set; }
    public ICollection<OrderModel>? Orders { get; set; }
}