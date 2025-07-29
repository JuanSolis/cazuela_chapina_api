using System;
using cazuela_chapina_core.Models;
using cazuela_chapina_core.Models.Dtos;
using cazuela_chapina_core.Repository.IRepository;

namespace cazuela_chapina_core.Repository;

public class VentaRepository : IVentaRepository
{
    private readonly ApplicationDbContext _db;
    public VentaRepository(ApplicationDbContext db)
    {
        _db = db;
    }
    public async Task<Venta?> CrearVenta(CrearVentaDto crearVentaDto)
    {
        var nuevaVenta = new Venta
        {
            Fecha = DateTime.Now,
            Horario = crearVentaDto.Horario,
            Tipo = crearVentaDto.Tipo,
            Precio = crearVentaDto.Precio,
            SucursalID = crearVentaDto.SucursalID,
        };

        _db.Ventas.Add(nuevaVenta);
        await _db.SaveChangesAsync();
        return nuevaVenta;
    }

    public ICollection<Venta> ObtenerVentas()
    {
        return _db.Ventas.OrderBy(venta => venta.VentaID).OrderByDescending(v => v.Fecha).ToList();
    }
}
