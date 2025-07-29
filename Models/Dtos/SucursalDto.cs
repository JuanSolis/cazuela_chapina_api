using System;

namespace cazuela_chapina_core.Models.Dtos;

public class SucursalDto
{
    public int SucursalID { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Ubicacion { get; set; } = string.Empty;
    public DateTime FechaCreacion { get; set; }
    public string Estatus { get; set; } = string.Empty;

}
