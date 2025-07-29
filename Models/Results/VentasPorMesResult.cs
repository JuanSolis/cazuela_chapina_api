using System;

namespace cazuela_chapina_core.Models.Results;

public class VentasPorMesResult
{
    public int Año { get; set; }
    public int Mes { get; set; }
    public int TotalVentas { get; set; }
    public decimal TotalIngresos { get; set; }
}
