using System;
using System.Collections;
using cazuela_chapina_core.Models;
using cazuela_chapina_core.Models.Results;
using cazuela_chapina_core.Repository.IRepository;

namespace cazuela_chapina_core.Repository;

public class DashboardRepository : IDashboardRepository
{
    private readonly ApplicationDbContext _db;

    public DashboardRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public ICollection<VentasDiariasResult> VentasDiarias()
    {
        List<VentasDiariasResult> resumenVentas = _db.Ventas
             .GroupBy(v => v.Fecha.Date)
             .Select(g => new VentasDiariasResult
             {
                 FechaVenta = g.Key,
                 TotalVentas = g.Count(),
                 TotalIngresos = g.Sum(v => v.Precio)
             })
             .OrderBy(r => r.FechaVenta)
             .ToList();

        return resumenVentas;
    }

    public ICollection<VentasPorMesResult> VentasMensuales()
    {
        List<VentasPorMesResult> resumenVentas = _db.Ventas
                .GroupBy(v => new { Año = v.Fecha.Year, Mes = v.Fecha.Month })
                .Select(g => new VentasPorMesResult
                {
                    Año = g.Key.Año,
                    Mes = g.Key.Mes,
                    TotalVentas = g.Count(),
                    TotalIngresos = g.Sum(v => v.Precio)
                })
                .OrderBy(r => r.Año)
                .ThenBy(r => r.Mes)
                .ToList();
        return resumenVentas;
    }

    public ICollection<TamalesMasVendidosResult> TamalesMasVendidos()
    {
        List<TamalesMasVendidosResult> tamalesMasVendidosResults = _db.DetalleTamales
                .GroupBy(dt => dt.Relleno)
                .Select(g => new TamalesMasVendidosResult
                {
                    Relleno = g.Key,
                    TotalVendidos = g.Count()
                })
                .OrderByDescending(r => r.TotalVendidos)
                .ToList();
        return tamalesMasVendidosResults;

    }

    public ICollection<BebidasPorHorarioResult> BebidaPreferidaPorHorario()
    {

        List<BebidasPorHorarioResult> bebidasPorHorario = _db.DetalleBebidas
            .Join(_db.Ventas, d => d.VentaID, v => v.VentaID, (d, v) => new { d, v })
            .GroupBy(x => new { x.v.Horario, x.d.Nombre })
            .Select(g => new BebidasPorHorarioResult
            {
                Horario = g.Key.Horario,
                Bebida = g.Key.Nombre,
                TotalVendidos = g.Count()
            })
            .OrderBy(r => r.Horario)
            .ThenByDescending(r => r.TotalVendidos)
            .ToList();

        return bebidasPorHorario;
    }

    public ICollection<ReportePorSucursalResult> ReportePorSucural()
    {
        List<ReportePorSucursalResult> reporte = _db.Ventas
            .GroupBy(v => v.Sucursal.Nombre)
            .Select(g => new ReportePorSucursalResult
            {
                Sucursal = g.Key,
                TotalVentas = g.Count(),
                TotalIngresos = g.Sum(v => v.Precio)
            })
            .OrderBy(r => r.Sucursal)
            .ToList();

        return reporte;
    }

    public ICollection TamalPorSucursal()
    {
        throw new NotImplementedException();
    }

    public ICollection CombosPorMes()
    {
        throw new NotImplementedException();
    }

    public ICollection<ProporcionPicanteResult> ProporcionPicantes()
    {
        List<ProporcionPicanteResult> proporcionPicanteResults = _db.DetalleTamales
               .GroupBy(d => d.Picante)
               .Select(g => new ProporcionPicanteResult
               {
                   Picante = g.Key,
                   Cantidad = g.Count()
               })
               .ToList();
        return proporcionPicanteResults;

    }
}
