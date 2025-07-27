using System;

namespace cazuela_chapina_core.Models.Dtos;

public class RegistroUsuarioDto
{
    public string? UsuarioId { get; set; }
    public string? Nombre { get; set; } = string.Empty;
    public required string NombreUsuario { get; set; } = string.Empty;
    public required string Password { get; set; } = string.Empty;

    public string? Role { get; set; } = string.Empty;
}
