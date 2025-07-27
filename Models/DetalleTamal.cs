using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cazuela_chapina_core.Models;

public class DetalleTamal
{
    [Key]
    public int TamalID { get; set; }

    [Required]
    public string Masa { get; set; } = string.Empty;
    [Required]
    public string Relleno { get; set; } = string.Empty;
    [Required]
    public string Envoltura { get; set; } = string.Empty;
    [Required]
    public string Picante { get; set; } = string.Empty;

    public int VentaID { get; set; }
    [ForeignKey("VentaID")]
    public required Venta Venta { get; set; }

}
