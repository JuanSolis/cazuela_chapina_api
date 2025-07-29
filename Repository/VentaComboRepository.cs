using System;
using cazuela_chapina_core.Models;
using cazuela_chapina_core.Models.Dtos;
using cazuela_chapina_core.Repository.IRepository;

namespace cazuela_chapina_core.Repository;

public class VentaComboRepository : IVentaComboRepository
{
    private readonly ApplicationDbContext _db;
    public VentaComboRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<VentaCombo?> CrearVentaCombo(CrearVentaComboDto crearVentaComboDto)
    {
        var nuevaVentaCombo = new VentaCombo
        {
            Precio = crearVentaComboDto.Precio,
            ComboID = crearVentaComboDto.ComboID,
            VentaID = crearVentaComboDto.VentaID,
        };

        _db.VentasCombos.Add(nuevaVentaCombo);
        await _db.SaveChangesAsync();
        return nuevaVentaCombo;
    }

    public ICollection<VentaCombo> ObtenerCombos()
    {
        return _db.VentasCombos.OrderBy(ventaCombo => ventaCombo.VentaID).ToList();
    }
}
