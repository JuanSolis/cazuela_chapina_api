using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cazuela_chapina_core.Models;

public class Venta
{
    [Key]
    public int VentaID { get; set; }
    [Required]
    public DateTime Fecha { get; set; }
    [Required]
    public string Horario { get; set; } = string.Empty;
    [Required]
    public string Tipo { get; set; } = string.Empty;
    [Required]
    public decimal Precio { get; set; }

    // Relación con el modelo Sucursal
    public int SucursalID { get; set; }
    [ForeignKey("SucursalID")]
    public required Sucursal Sucursal { get; set; }

}


