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
        modelBuilder.Entity<Sucursal>().ToTable("Usuarios", t => t.ExcludeFromMigrations());
        modelBuilder.Entity<Sucursal>().ToTable("Ventas", t => t.ExcludeFromMigrations());
        modelBuilder.Entity<Sucursal>().ToTable("DetalleTamales", t => t.ExcludeFromMigrations());
        modelBuilder.Entity<Sucursal>().ToTable("DetalleBebidas", t => t.ExcludeFromMigrations());
    }
    public DbSet<Sucursal> Sucursales { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Venta> Ventas { get; set; }
    public DbSet<DetalleTamal> DetalleTamales { get; set; }
    public DbSet<DetalleBebida> DetalleBebidas { get; set; }
}