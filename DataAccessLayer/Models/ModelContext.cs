using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DataAccessLayer;

public partial class ModelContext : DbContext
{
    public ModelContext()
    {
    }

    public ModelContext(DbContextOptions<ModelContext> options) : base(options)
    {
    }

    public virtual DbSet<Brand> Brands { get; set; }
    public virtual DbSet<Lawnmower> Lawnmowers { get; set; }
    public virtual DbSet<RideOnLawnmower> RideOnLawnmowers { get; set; }
    public virtual DbSet<PushLawnmower> PushLawnmowers { get; set; }
    public virtual DbSet<Order> Orders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Lawnmower>(entity =>
        {
            entity.ToTable("Lawnmower");
            entity.Property(e => e.Id);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(50);
            entity.Property(e => e.Description).IsRequired().HasMaxLength(255);
            entity.Property(e => e.Price).HasColumnType("decimal(8, 2)");
            entity.Property(e => e.QuantityInStock);
            entity.Property(e => e.Photo).HasColumnType("blob");
            entity.Property(e => e.FuelDetails);
            entity.Property(e => e.LastUpdated).HasColumnType("datetime");
            entity.Property(e => e.BrandId);
            entity.HasDiscriminator(b => b.Type)
                .HasValue<Lawnmower>("Base")
                .HasValue<RideOnLawnmower>("RideOn")
                .HasValue<PushLawnmower>("Push");
            entity.HasOne(l => l.Brand)
                .WithMany(b => b.Lawnmowers)
                .HasForeignKey(l => l.BrandId);


            modelBuilder.Entity<RideOnLawnmower>(entity =>
            {
                entity.Property(e => e.TopSpeed);
            });

            modelBuilder.Entity<PushLawnmower>(entity =>
            {
                entity.Property(e => e.Weight);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");
                entity.Property(e => e.Id);
                entity.Property(e => e.Quantity);
                entity.Property(e => e.TimeCreated).HasColumnType("datetime");
                entity.Property(e => e.ItemPrice).HasColumnType("decimal(8, 2)");
                entity.Property(e => e.CustomerName).IsRequired().HasMaxLength(50);
                entity.Property(e => e.CustomerEmail).IsRequired().HasMaxLength(50);
                entity.Property(e => e.CustomerPhone).IsRequired().HasMaxLength(20);
                entity.Property(e => e.Completed).HasColumnType("bit");
                entity.Property(e => e.ProductId);
                entity.HasOne(o => o.Product)
                .WithMany(p => p.Orders)
                .HasForeignKey(o => o.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Brand>(entity =>
            {
                entity.ToTable("Brand");
                entity.Property(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(20);
                entity.Property(e => e.Description).IsRequired().HasMaxLength(255);
            });

            OnModelCreatingPartial(modelBuilder);
        });
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}