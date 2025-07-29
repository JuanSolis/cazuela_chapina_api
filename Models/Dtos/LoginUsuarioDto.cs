using System;
using System.ComponentModel.DataAnnotations;

namespace cazuela_chapina_core.Models.Dtos;

public class LoginUsuarioDto
{
    [Required(ErrorMessage = "El campo username es requerido")]
    public string? NombreUsuario { get; set; }

    [Required(ErrorMessage = "El campo password es requerido")]
    public string? Password { get; set; }

}
