namespace gearzone.domains.Entities;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Brand { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public decimal? OldPrice { get; set; }
    public string Category { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public int Rating { get; set; }
    public int Reviews { get; set; }
    public string? Badge { get; set; }
    public bool InStock { get; set; } = true;
    public string Description { get; set; } = string.Empty;
    public int Stock { get; set; } = 0;
}