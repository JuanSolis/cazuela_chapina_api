using System;

namespace cazuela_chapina_core.Models.Dtos;

public class LoginUsuarioResponseDto
{
    public RegistroUsuarioDto? Usuario { get; set; }
    public string? Token { get; set; }
    public string? Mensajes { get; set; }

}
