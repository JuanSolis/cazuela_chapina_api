using System;
using cazuela_chapina_core.Models;
using cazuela_chapina_core.Models.Dtos;

namespace cazuela_chapina_core.Repository.IRepository;

public interface IVentaComboRepository
{

    ICollection<VentaCombo> ObtenerCombos();

    Task<VentaCombo?> CrearVentaCombo(CrearVentaComboDto crearVentaComboDto);
}
