using gearzone.dataaccess.Repositories;
using gearzone.domains.Entities;

namespace gearzone.dataaccess.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly List<Product> _products = new();

    public Task<IEnumerable<Product>> GetAllAsync()
    {
        return Task.FromResult<IEnumerable<Product>>(_products);
    }

    public Task<Product?> GetByIdAsync(int id)
    {
        var product = _products.FirstOrDefault(p => p.Id == id);
        return Task.FromResult(product);
    }

    public Task AddAsync(Product product)
    {
        product.Id = _products.Count + 1;
        _products.Add(product);
        return Task.CompletedTask;
    }

    public Task UpdateAsync(Product product)
    {
        var existing = _products.FirstOrDefault(p => p.Id == product.Id);
        if (existing != null)
        {
            _products.Remove(existing);
            _products.Add(product);
        }
        return Task.CompletedTask;
    }

    public Task DeleteAsync(int id)
    {
        var product = _products.FirstOrDefault(p => p.Id == id);
        if (product != null)
        {
            _products.Remove(product);
        }
        return Task.CompletedTask;
    }
}