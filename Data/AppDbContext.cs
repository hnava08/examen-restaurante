using Microsoft.EntityFrameworkCore;
using Restaurante.Models;

namespace Restaurante.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Categoria> Categorias => Set<Categoria>();
    public DbSet<Plato> Platos => Set<Plato>();
}
