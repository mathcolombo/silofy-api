using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace Silofy.Infra.Configs.Contexts;

public class SilofyDbContext(DbContextOptions<SilofyDbContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}