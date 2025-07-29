using System;

namespace cazuela_chapina_core.Models.Results;

public class VentasDiariasResult
{

    public DateTime FechaVenta { get; set; }
    public int TotalVentas { get; set; }
    public decimal TotalIngresos { get; set; }
}
