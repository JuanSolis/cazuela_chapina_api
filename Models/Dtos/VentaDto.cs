using System;

namespace cazuela_chapina_core.Models.Dtos;

public class VentaDto
{
    public int VentaID { get; set; }
    public DateTime Fecha { get; set; }
    public string Horario { get; set; } = string.Empty;
    public string Tipo { get; set; } = string.Empty;
    public decimal Precio { get; set; }
    public int SucursalID { get; set; }
    public Sucursal? Sucursal { get; set; }
}
