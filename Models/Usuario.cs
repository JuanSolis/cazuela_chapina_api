using System;
using System.ComponentModel.DataAnnotations;

namespace cazuela_chapina_core.Models;

public class Usuario
{
    [Key]
    public int UsuarioId { get; set; }
    [Required]
    public string? Nombre { get; set; } = string.Empty;
    [Required]
    public string NombreUsuario { get; set; } = string.Empty;
    [Required]
    public string? Password { get; set; } = string.Empty;
    [Required]
    public string? Role { get; set; } = string.Empty;
}
