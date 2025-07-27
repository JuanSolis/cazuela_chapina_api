using System;

namespace cazuela_chapina_core.Models.Results;

public class ReportePorSucursalResult
{
    public string Sucursal { get; set; } = string.Empty;
    public int TotalVentas { get; set; }
    public decimal TotalIngresos { get; set; }
}
