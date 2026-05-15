using gearzone.domains.Entities;
using Microsoft.EntityFrameworkCore;

namespace gearzone.dataaccess.Data;

public class UserContext : DbContext
{
    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(DbSession.ConnectionStrings);
    }
}
