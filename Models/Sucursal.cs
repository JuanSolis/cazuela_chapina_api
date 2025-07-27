using System.ComponentModel.DataAnnotations;

public class Sucursal
{
    [Key]
    public int SucursalID { get; set; }
    [Required]
    public string Nombre { get; set; } = string.Empty;
    [Required]
    public string Ubicacion { get; set; } = string.Empty;

}