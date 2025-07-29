using System;
using System.ComponentModel.DataAnnotations;

namespace cazuela_chapina_core.Models.Dtos;

public class CrearUsuarioDto
{
    [Required(ErrorMessage = "El campo NombreUsuario es requerido")]
    public string? NombreUsuario { get; set; }
    [Required(ErrorMessage = "El campo Nombre es requerido")]
    public string? Nombre { get; set; }
    [Required(ErrorMessage = "El campo password es requerido")]
    public string? Password { get; set; }
    [Required(ErrorMessage = "El campo role es requerido")]
    public string? Role { get; set; }
}
