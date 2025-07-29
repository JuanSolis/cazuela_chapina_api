using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cazuela_chapina_core.Models;

public class DetalleBebida
{
    [Key]
    public int BebidaID { get; set; }

    [Required]
    public string Nombre { get; set; } = string.Empty;
    [Required]
    public string Endulzante { get; set; } = string.Empty;
    [Required]
    public string Topping { get; set; } = string.Empty;

    public int VentaID { get; set; }
    [ForeignKey("VentaID")]
    public required Venta Venta { get; set; }


}
