using System;

namespace cazuela_chapina_core.Models.Dtos;

public class UsuarioDto
{
    public int UsuarioId { get; set; }
    public string? Nombre { get; set; } = string.Empty;
    public string? NombreUsuario { get; set; } = string.Empty;
    public string? Password { get; set; } = string.Empty;
    public string? Role { get; set; } = string.Empty;
}
