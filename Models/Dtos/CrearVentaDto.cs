using System;

namespace cazuela_chapina_core.Models.Dtos;

public class CrearVentaDto
{

    public string Horario { get; set; } = string.Empty;
    public string Tipo { get; set; } = string.Empty;
    public decimal Precio { get; set; }
    public int SucursalID { get; set; }
}
