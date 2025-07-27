using System;
using cazuela_chapina_core.Repository.IRepository;

namespace cazuela_chapina_core.Repository;

public class SucursalRepository : ISucursalRepository
{
    private readonly ApplicationDbContext _db;

    public SucursalRepository(ApplicationDbContext dbContext)
    {
        _db = dbContext;
    }
    public bool CrearSucursal(Sucursal sucursal)
    {
        sucursal.FechaCreacion = DateTime.Now;
        sucursal.Estatus = "Activo";
        _db.Sucursales.Add(sucursal);
        return Guardar();
    }

    public bool ExisteSucursal(int id)
    {
        return _db.Sucursales.Any(sucursal => sucursal.SucursalID == id);
    }

    public bool ExisteSucursal(string nombreSucursal)
    {
        return _db.Sucursales.Any(sucursal => sucursal.Nombre.ToLower().Trim() == nombreSucursal.ToLower().Trim());
    }

    public bool Guardar()
    {
        return _db.SaveChanges() >= 0 ? true : false;
    }

    public Sucursal? ObtenerSucursal(int id)
    {
        return _db.Sucursales.FirstOrDefault(sucursal => sucursal.SucursalID == id);
    }

    public ICollection<Sucursal> ObtenerSucursales()
    {
        return _db.Sucursales.OrderBy(sucursal => sucursal.Nombre).ToList();
    }
}
