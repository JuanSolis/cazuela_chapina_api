using cazuela_chapina_core.Models;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Sucursal>().ToTable("Sucursales");
        modelBuilder.Entity<Usuario>().ToTable("Usuarios");
        modelBuilder.Entity<Venta>().ToTable("Ventas");
        modelBuilder.Entity<DetalleTamal>().ToTable("DetalleTamales");
        modelBuilder.Entity<DetalleBebida>().ToTable("DetalleBebidas");
        modelBuilder.Entity<Combo>().ToTable("Combos");
    }
    public DbSet<Sucursal> Sucursales { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Venta> Ventas { get; set; }
    public DbSet<DetalleTamal> DetalleTamales { get; set; }
    public DbSet<DetalleBebida> DetalleBebidas { get; set; }
    public DbSet<Combo> Combos { get; set; }
}