using System;

namespace cazuela_chapina_core.Models.Results;

public class VentasDeCombosResult
{
    public string Nombre { get; set; } = string.Empty;
    public int VecesVendido { get; set; }
    public double IngresoGenerado { get; set; }

}
