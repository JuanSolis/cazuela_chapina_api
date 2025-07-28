using System;
using System.Collections;
using cazuela_chapina_core.Models;
using cazuela_chapina_core.Models.Results;

namespace cazuela_chapina_core.Repository.IRepository;

public interface IDashboardRepository
{
    ICollection<VentasDiariasResult> VentasDiarias();
    ICollection<VentasPorMesResult> VentasMensuales();
    ICollection<TamalesMasVendidosResult> TamalesMasVendidos();
    ICollection<BebidasPorHorarioResult> BebidaPreferidaPorHorario();
    ICollection<ReportePorSucursalResult> ReportePorSucural();
    ICollection<ProporcionPicanteResult> ProporcionPicantes();
    ICollection TamalPorSucursal();
    ICollection<VentasDeCombosResult> VentasDeCombos();
}
