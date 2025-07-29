using System;
using System.ComponentModel.DataAnnotations;

namespace cazuela_chapina_core.Models;

public class Combo
{
    [Key]
    public int ComboID { get; set; }
    [Required]
    public string Nombre { get; set; } = string.Empty;
    [Required]
    public string Tipo { get; set; } = string.Empty;
    [Required]
    public string Descripcion { get; set; } = string.Empty;
    [Required]
    public DateTime DisponibleDesde { get; set; }
    [Required]
    public DateTime DisponibleHasta { get; set; }
    [Required]
    public Boolean Activo { get; set; }
    [Required]
    public int Precio { get; set; }
}
