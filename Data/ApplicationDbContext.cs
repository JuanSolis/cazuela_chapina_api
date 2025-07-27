using cazuela_chapina_core.Models;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Sucursal>().ToTable("Sucursales", t => t.ExcludeFromMigrations());
    }
    public DbSet<Sucursal> Sucursales { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
}