using Microsoft.EntityFrameworkCore;
using gearzone.domains.Entities;

namespace gearzone.dataaccess.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Product>()
            .Property(p => p.Price)
            .HasPrecision(18, 2);

        modelBuilder.Entity<Product>()
            .Property(p => p.OldPrice)
            .HasPrecision(18, 2);

        modelBuilder.Entity<Product>().HasData(
            new Product { Id = 1, Name = "Razer Viper V3 Pro", Brand = "Razer", Price = 15990, OldPrice = 17990, Category = "Мыши", ImageUrl = "https://example.com/razer-viper.jpg", Rating = 5, Reviews = 124, Badge = "Bestseller", InStock = true, Description = "Флагманская игровая мышь Razer Viper V3 Pro." },
            new Product { Id = 2, Name = "Logitech G Pro X Superlight", Brand = "Logitech", Price = 12990, OldPrice = null, Category = "Мыши", ImageUrl = "https://example.com/logitech-gpro.jpg", Rating = 5, Reviews = 89, Badge = null, InStock = true, Description = "Лёгкая игровая мышь Logitech G Pro X Superlight." }
        );
    }
}