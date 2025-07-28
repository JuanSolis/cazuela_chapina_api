using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cazuela_chapina_core.Models;

public class VentaCombo
{
    [Key]
    public int VentaComboID { get; set; }

    [Required]
    public double Precio { get; set; }

    [ForeignKey("ComboID")]
    public int ComboID { get; set; }

    [ForeignKey("VentaID")]
    public int VentaID { get; set; }


}
